using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWashManagement.Core.FileHandlers;

namespace CarWashManagement.Core.Managers
{
    public class TransactionManager
    {
        private readonly TransactionFileHandler txnFileHandler;
        private readonly AuditFileHandler auditFileHandler;
        private List<Transaction> transactions;
        private int nextTransactionNumber;

        public TransactionManager(TransactionFileHandler txnFileHandler, AuditFileHandler auditFileHandler)
        {
            this.txnFileHandler = txnFileHandler;
            this.auditFileHandler = auditFileHandler;
            transactions = txnFileHandler.LoadAllTransactions();

            // Determine the next transaction number based on existing transactions.
            if (transactions.Count == 0)
            {
                nextTransactionNumber = 1; // Start from 1 if no transactions exist.
            }
            else
            {
                // Get the ID of the last transaction.
                string lastID = transactions.Last().ID;
                int lastNumber = int.Parse(lastID.Substring(3));
                nextTransactionNumber = lastNumber + 1;
            }

            this.auditFileHandler = auditFileHandler;
        }

        // Method to create a new transaction object and saves it to the transactions.txt file.
        public Transaction CreateTransaction(string employeeName, Vehicle vehicle, List<Service> services, bool isPaid, string washStatus, decimal discountPercentage, string loggedInUsername)
        {
            Transaction txn = new Transaction
            {
                ID = $"TXN{nextTransactionNumber:D6}",
                Timestamp = DateTime.Now,
                EmployeeName = employeeName,
                VehicleType = vehicle.Type,
                BaseFee = vehicle.BaseFee,
                IsPaid = isPaid,
                AdditionalServices = services,
                WashStatus = washStatus,
                DiscountPercentage = discountPercentage,
                ServiceTotal = services.Sum(s => s.Fee)
            };

            decimal servicesTotal = txn.ServiceTotal;
            decimal serviceOwnerShare = servicesTotal * 0.50m;
            decimal serviceEmployeeShare = servicesTotal * 0.50m;

            decimal subTotal = txn.BaseFee + servicesTotal;

            decimal discountAmount = subTotal * discountPercentage;
            decimal discountLossOwner = discountAmount * 0.50m; // 50% of the loss to owner.
            decimal discountLossEmployee = discountAmount * 0.50m; // 50% of the loss to employee.

            // Calculate combined shares from vehicle base fee and services.
            txn.OwnerShare = (vehicle.OwnerShare + serviceOwnerShare) - discountLossOwner;
            txn.EmployeeShare = (vehicle.EmployeeShare + serviceEmployeeShare) - discountLossEmployee;


            txn.TotalAmount = subTotal - discountAmount;  

            // Save transaction to file.
            txnFileHandler.SaveTransaction(txn);

            auditFileHandler.LogEvent($"TRANSACTION: {txn.ID} created by user '{loggedInUsername}' for Employee: {txn.EmployeeName}. Amount: {txn.TotalAmount:N2}.");

            // Add to in-memory list.
            transactions.Add(txn);
            
            nextTransactionNumber++;

            return txn;
        }

        // Method to get all transactions made today, ordered by most recent first.
        public List<Transaction> GetTodaysTransactions()
        {
            return transactions
                .Where(txn => txn.Timestamp.Date == DateTime.Today)
                .OrderByDescending(txn => txn.Timestamp)
                .ToList();
        }

        // Method to get all transactions for a specific month.
        public List<Transaction> GetTransactionsForMonth(int year, int month)
        {
            return transactions
                .Where(txn => txn.Timestamp.Year == year && txn.Timestamp.Month == month)
                .ToList();
        }

        // Method to get all transactions for a specific year.
        public List<Transaction> GetTransactionsForYear(int year)
        {
            return transactions
                .Where(txn => txn.Timestamp.Year == year)
                .ToList();
        }

        // Method to get a transaction by its ID.
        public Transaction GetTransactionByID(string id)
        {
            return transactions.FirstOrDefault(txn => txn.ID == id);
        }

        // Method to save the entire in-memory list of transactions to the transactions.txt file.
        // This method assumes the transaction object was already updated in memory before this was called.
        public void UpdateTransaction()
        {
            txnFileHandler.SaveAllTransactions(transactions);
        }      
    }
}
