using CarWashManagement.Core;
using CarWashManagement.Core.FileHandlers;
using CarWashManagement.Core.Managers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace CarWashManagement.UI
{
    public enum ReportMode { Monthly, Yearly }

    // Form to generate report based on the inputted month-year.
    public partial class ReportForm : BaseForm
    {
        private ReportMode currentReportMode = ReportMode.Monthly; // Default report mode.

        private readonly TransactionManager transactionManager;
        private readonly ExpenseManager expenseManager;

        public ReportForm()
        {
            transactionManager = new TransactionManager(new TransactionFileHandler(), new AuditFileHandler());
            expenseManager = new ExpenseManager(new ExpenseFileHandler(), new AuditFileHandler());

            InitializeComponent();
        }

        // Event handler when the monthly toggle button is clicked.
        private void btnMonthlyToggle_Click(object sender, EventArgs e)
        {
            currentReportMode = ReportMode.Monthly;
            lblSelectMonth.Text = "Select Month:";
            dtpReportDate.CustomFormat = "MMMM yyyy";

            btnMonthlyToggle.BackColor = Color.FromArgb(41, 128, 185);
            btnMonthlyToggle.ForeColor = Color.White;
            btnYearlyToggle.BackColor = Color.White;
            btnYearlyToggle.ForeColor = Color.FromArgb(41, 128, 185);

            // Clear all textboxes in the report panel.
            foreach (Control ctrl in pnlReport.Controls)
            {
                if (ctrl is TextBox txt) { txt.Clear(); }
            }
            // Clear entry list.
            lsvMonthlyEntries.Items.Clear();
            lsvMonthlyEntries.Groups.Clear();
        }

        // Event handler when the yearly toggle button is clicked.
        private void btnYearlyToggle_Click(object sender, EventArgs e)
        {
            currentReportMode = ReportMode.Yearly;
            lblSelectMonth.Text = "Select Year:";
            dtpReportDate.CustomFormat = "yyyy";

            btnYearlyToggle.BackColor = Color.FromArgb(41, 128, 185);
            btnYearlyToggle.ForeColor = Color.White;
            btnMonthlyToggle.BackColor = Color.White;
            btnMonthlyToggle.ForeColor = Color.FromArgb(41, 128, 185);

            // Clear all textboxes in the report panel.
            foreach (Control ctrl in pnlReport.Controls)
            {
                if (ctrl is TextBox txt) { txt.Clear(); }
            }
            // Clear entry list.
            lsvMonthlyEntries.Items.Clear();
            lsvMonthlyEntries.Groups.Clear();
        }

        // Event handler when the Generate Button is clicked.
        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            // Run the correct report based on the report mode.
            if (currentReportMode == ReportMode.Monthly)
            {
                GenerateMonthlyReport();
            }
            else
            {
                GenerateYearlyReport();
            }
        }

        // Method to generate a monthly financial/statistic report.
        private void GenerateMonthlyReport()
        {
            DateTime selectedDate = dtpReportDate.Value;
            int year = selectedDate.Year;
            int month = selectedDate.Month;

            // Get all transactions for the month.
            List<Transaction> transactions = transactionManager.GetTransactionsForMonth(year, month);

            // Get all Paid transactions for the month.
            List<Transaction> paidTransactions = transactions
                .Where(txn => txn.IsPaid)
                .ToList();

            // Get all expenses for the month.
            List<Expense> expenses = expenseManager.GetExpensesForMonth(year, month);

            // Calculations.
            decimal totalRevenue = paidTransactions.Sum(txn => txn.TotalAmount);
            decimal totalOwnerShare = paidTransactions.Sum(txn => txn.OwnerShare);
            decimal totalEmployeeShare = paidTransactions.Sum(txn => txn.EmployeeShare);
            int totalWashes = paidTransactions.Count();

            decimal totalExpenses = expenses.Sum(exp => exp.Amount);
            decimal netProfit = totalOwnerShare - totalExpenses;

            // Get Most Washed Vehicle.
            string mostWashed = "N/A";
            if (paidTransactions.Any())
            {
                mostWashed = paidTransactions
                    .GroupBy(txn => txn.VehicleType)
                    .OrderByDescending(g => g.Count())
                    .Select(g => g.Key)
                    .FirstOrDefault() ?? "N/A";
            }

            // Get Most Availed service.
            var allServices = paidTransactions.SelectMany(txn => txn.AdditionalServices);
            string mostService = "N/A";
            if (paidTransactions.Any())
            {
                mostService = allServices
                    .GroupBy(s => s.Name)
                    .OrderByDescending(g => g.Count())
                    .Select(g => g.Key)
                    .FirstOrDefault() ?? "N/A";
            }

            // Highest Revenue Day
            string highestDay = "N/A (0.00)";
            if (paidTransactions.Any())
            {
                var dailyRevenue = paidTransactions
                    .GroupBy(txn => txn.Timestamp.Date)
                    .Select(g => new { Date = g.Key, Total = g.Sum(txn => txn.TotalAmount) })
                    .OrderByDescending(d => d.Total)
                    .FirstOrDefault();

                if (dailyRevenue != null)
                {
                    highestDay = $"{dailyRevenue.Date:MMMM dd} ({dailyRevenue.Total:N2})";
                }
            }

            txtReportTotalRevenue.Text = totalRevenue.ToString("C", CultureInfo.GetCultureInfo("en-PH"));
            txtReportOwnerShare.Text = totalOwnerShare.ToString("C", CultureInfo.GetCultureInfo("en-PH"));
            txtReportEmpShare.Text = totalEmployeeShare.ToString("C", CultureInfo.GetCultureInfo("en-PH"));
            txtReportTotalWashes.Text = totalWashes.ToString();
            txtReportMostWashed.Text = mostWashed;
            txtReportMostService.Text = mostService;
            lblReportHighestDay.Text = "Highest Revenue Day:";
            txtReportHighestDay.Text = highestDay;
            txtReportTotalExpenses.Text = totalExpenses.ToString("C", CultureInfo.GetCultureInfo("en-PH"));
            txtReportNetProfit.Text = netProfit.ToString("C", CultureInfo.GetCultureInfo("en-PH"));

            lblEntries.Enabled = true;
            lsvMonthlyEntries.Enabled = true;

            // Group all transactions by date.
            var groupedByDay = transactions
                .OrderBy(txn => txn.Timestamp)
                .GroupBy(txn => txn.Timestamp.Date);

            foreach (var dayGroup in groupedByDay)
            {
                // Create a group for the day.
                string groupHeader = dayGroup.Key.ToString("MMMM dd, yyyy");
                ListViewGroup group = new ListViewGroup(groupHeader);
                lsvMonthlyEntries.Groups.Add(group);

                // Add each transaction from that day to the group.
                foreach (Transaction txn in dayGroup)
                {
                    ListViewItem row = new ListViewItem(txn.Timestamp.ToString("HH:mm"));
                    row.SubItems.Add(txn.VehicleType);
                    row.SubItems.Add(txn.EmployeeName);
                    row.SubItems.Add(txn.OwnerShare.ToString("C", CultureInfo.GetCultureInfo("en-PH")));
                    row.SubItems.Add(txn.EmployeeShare.ToString("C", CultureInfo.GetCultureInfo("en-PH")));
                    row.SubItems.Add(txn.IsPaid ? "Paid" : "Unpaid");
                    row.Group = group; // Assign the item to the day's group.

                    lsvMonthlyEntries.Items.Add(row);
                }
            }
        }

        // Method to generate yearly financial/statistic report.
        private void GenerateYearlyReport()
        {
            int year = dtpReportDate.Value.Year;

            List<Transaction> transactions = transactionManager.GetTransactionsForYear(year);
            List<Transaction> paidTransactions = transactions
                .Where(txn => txn.IsPaid)
                .ToList();
            List<Expense> expenses = expenseManager.GetExpensesForYear(year);

            // Calculations.
            decimal totalRevenue = paidTransactions.Sum(txn => txn.TotalAmount);
            decimal totalOwnerShare = paidTransactions.Sum(txn => txn.OwnerShare);
            decimal totalEmployeeShare = paidTransactions.Sum(txn => txn.EmployeeShare);
            int totalWashes = paidTransactions.Count();

            decimal totalExpenses = expenses.Sum(exp => exp.Amount);
            decimal netProfit = totalOwnerShare - totalExpenses;

            // Get Most Washed Vehicle.
            string mostWashed = "N/A";
            if (paidTransactions.Any())
            {
                mostWashed = paidTransactions
                    .GroupBy(txn => txn.VehicleType)
                    .OrderByDescending(g => g.Count())
                    .Select(g => g.Key)
                    .FirstOrDefault() ?? "N/A";
            }

            // Get Most Availed service.
            var allServices = paidTransactions.SelectMany(txn => txn.AdditionalServices);
            string mostService = "N/A";
            if (paidTransactions.Any())
            {
                mostService = allServices
                    .GroupBy(s => s.Name)
                    .OrderByDescending(g => g.Count())
                    .Select(g => g.Key)
                    .FirstOrDefault() ?? "N/A";
            }

            // Highest Revenue Day
            string highestMonth = "N/A (0.00)";
            if (paidTransactions.Any())
            {
                var monthlyRevenue = paidTransactions
                    .GroupBy(txn => txn.Timestamp.Month)
                    .Select(g => new {
                        Month = g.Key,
                        Total = g.Sum(txn => txn.TotalAmount)
                    })
                    .OrderByDescending(m => m.Total)
                    .FirstOrDefault();

                if (monthlyRevenue != null)
                {
                    // Convert month number to month name.
                    string monthName = new DateTime(year, monthlyRevenue.Month, 1).ToString("MMMM");
                    highestMonth = $"{monthName} ({monthlyRevenue.Total:N2})";
                }
            }

            txtReportTotalRevenue.Text = totalRevenue.ToString("C", CultureInfo.GetCultureInfo("en-PH"));
            txtReportOwnerShare.Text = totalOwnerShare.ToString("C", CultureInfo.GetCultureInfo("en-PH"));
            txtReportEmpShare.Text = totalEmployeeShare.ToString("C", CultureInfo.GetCultureInfo("en-PH"));
            txtReportTotalWashes.Text = totalWashes.ToString();
            txtReportMostWashed.Text = mostWashed;
            txtReportMostService.Text = mostService;
            lblReportHighestDay.Text = "Highest Revenue Month:";
            txtReportHighestDay.Text = highestMonth;
            txtReportTotalExpenses.Text = totalExpenses.ToString("C", CultureInfo.GetCultureInfo("en-PH"));
            txtReportNetProfit.Text = netProfit.ToString("C", CultureInfo.GetCultureInfo("en-PH"));

            lblEntries.Enabled = false;
            lsvMonthlyEntries.Enabled = false;
        }
    }
}