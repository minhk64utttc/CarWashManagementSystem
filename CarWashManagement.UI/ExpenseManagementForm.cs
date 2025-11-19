using CarWashManagement.Core;
using CarWashManagement.Core.FileHandlers;
using CarWashManagement.Core.Managers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace CarWashManagement.UI
{
    // Form that allows admin to manage expenses.
    public partial class ExpenseManagementForm : BaseForm
    {
        private readonly User loggedInUser;
        private readonly ExpenseManager expenseManager;

        public ExpenseManagementForm(User loggedInUser)
        {
            this.loggedInUser = loggedInUser;

            expenseManager = new ExpenseManager(
                new ExpenseFileHandler(),
                new AuditFileHandler()
                );

            InitializeComponent();
            LoadExpenseList();
        }

        // Load all expenses from the manager into the ListView.
        private void LoadExpenseList()
        {
            lsvExpenses.Items.Clear();

            List<Expense> expenses = expenseManager.GetAllExpenses();

            foreach (Expense expense in expenses)
            {
                ListViewItem row = new ListViewItem(expense.Date.ToString("yyyy-MM-dd"));
                row.SubItems.Add(expense.Description);
                row.SubItems.Add(expense.Amount.ToString("C", CultureInfo.GetCultureInfo("en-PH"))); // Format as currency (PHP)
                lsvExpenses.Items.Add(row);
            }
        }

        // Event handler for adding a new expense.
        private void btnAddExpense_Click(object sender, EventArgs e)
        {
            string description = txtDescription.Text.Trim();
            string amountStr = txtAmount.Text.Trim();
            DateTime date = dtpExpenseDate.Value;

            if (string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Please enter a description for the expense.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(amountStr, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid positive amount for the expense.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Call the manager to create and save the expense.
            expenseManager.CreateExpense(date, description, amount, loggedInUser.Username);

            MessageBox.Show("Expense added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadExpenseList();

            // Clear input fields.
            txtDescription.Clear();
            txtAmount.Clear();
            dtpExpenseDate.Value = DateTime.Now;
        }
    }
}