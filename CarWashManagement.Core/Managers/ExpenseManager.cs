using CarWashManagement.Core.FileHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashManagement.Core.Managers
{
    public class ExpenseManager
    {
        private readonly IFileHandler<Expense> expenseFileHandler;
        private readonly AuditFileHandler auditFileHandler;
        private List<Expense> expenses;

        public ExpenseManager(IFileHandler<Expense> expenseFileHandler, AuditFileHandler auditFileHandler)
        {
            this.expenseFileHandler = expenseFileHandler;
            this.auditFileHandler = auditFileHandler;
            expenses = expenseFileHandler.Load(); // Load existing expenses from expenses.txt file
        }

        // Method to create a new expense and save it to the expenses.txt file
        public void CreateExpense(DateTime date, string description, decimal amount, string loggedInUsername)
        {
            Expense newExpense = new Expense
            {
                Date = date,
                Description = description,
                Amount = amount
            };

            expenses.Add(newExpense);
            expenseFileHandler.Save(expenses); // Save updated expenses list to expenses.txt file

            auditFileHandler.LogEvent($"EXPENSE: User '{loggedInUsername}' added expense '{description}' for {amount:N2} (Date: {date:yyyy-MM-dd}).");
        }

        // Method to get all expenses for a specific month.
        public List<Expense> GetExpensesForMonth(int year, int month)
        {
            return expenses
                .Where(e => e.Date.Year == year && e.Date.Month == month)
                .ToList();
        }

        // Method to get all expenses for a specific year.
        public List<Expense> GetExpensesForYear(int year)
        {
            return expenses
                .Where(e => e.Date.Year == year)
                .ToList();
        }

        // Method to get all expenses
        public List<Expense> GetAllExpenses()
        {
            return expenses
                .OrderByDescending(e => e.Date)
                .ToList();
        }
    }
}
