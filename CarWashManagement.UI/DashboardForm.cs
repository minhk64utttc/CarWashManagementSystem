using CarWashManagement.Core;
using CarWashManagement.Core.Enums;
using CarWashManagement.Core.FileHandlers;
using CarWashManagement.Core.Managers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CarWashManagement.UI
{
    public partial class DashboardForm : BaseForm
    {
        private readonly User loggedInUser;

        // Declaration of manager instances.
        private readonly CarManager carManager;
        private readonly TransactionManager transactionManager;

        // Declaration of data lists.
        private List<Vehicle> vehicleTypes;
        private List<Service> services;

        // To hold created service checkboxes and fee textboxes.
        private List<Control> serviceControls = new List<Control>();

        public DashboardForm(User loggedInUser)
        {
            this.loggedInUser = loggedInUser;

            // Initialize manager instances.
            carManager = new CarManager(
                new VehicleFileHandler(),
                new ServiceFileHandler(),
                new AuditFileHandler()
                );
            transactionManager = new TransactionManager(
                new TransactionFileHandler(),
                new AuditFileHandler()
                );

            InitializeComponent();

            // Load data lists.
            vehicleTypes = carManager.GetVehicleTypes();
            services = carManager.GetServices();

            LoadVehicleComboBox();
            LoadServiceControls();
            RefreshTodaysEntries();

            // Set welcome label text
            welcomeLabel.Text = $"Welcome, {loggedInUser.FullName} ({loggedInUser.Role})";

            // Adjust button positions for admin
            if (loggedInUser.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                adminMenuItem.Visible = true;
                btnChangePassword.Location = new System.Drawing.Point(535, 5);
                logoutButton.Location = new System.Drawing.Point(665, 5);
            }
        }

        // Method to load the vehicle types in the dropdown combo box.
        private void LoadVehicleComboBox()
        {
            // ComboBox configuration
            cmbVehicleType.DataSource = null; // Reset the DataSource.
            cmbVehicleType.DataSource = vehicleTypes;
            cmbVehicleType.DisplayMember = "Type";
            cmbVehicleType.ValueMember = "Type";
            cmbVehicleType.SelectedIndex = -1; // Start with no selection.
        }

        // Method to load the service controls.
        private void LoadServiceControls()
        {
            int currentY = 10;

            foreach (Control c in serviceControls)
            {
                servicePanel.Controls.Remove(c);
            }
            serviceControls.Clear();

            foreach (Service service in services)
            {
                // Create the CheckBox.
                CheckBox chk = new CheckBox();
                chk.Text = service.Name;
                chk.Location = new System.Drawing.Point(10, currentY);
                chk.AutoSize = true;
                chk.Tag = service; // Store the service object in the tag.
                chk.CheckedChanged += ServiceCheckbox_CheckedChanged;
                servicePanel.Controls.Add(chk);
                serviceControls.Add(chk);

                // Create the Textbox
                TextBox txt = new TextBox();
                txt.Location = new System.Drawing.Point(180, currentY - 3);
                txt.Size = new System.Drawing.Size(80, 23);
                txt.Enabled = false;
                txt.BorderStyle = BorderStyle.FixedSingle;
                txt.BackColor = Color.White;
                txt.Tag = service; // Store the service object in the tag.
                servicePanel.Controls.Add(txt);
                serviceControls.Add(txt);

                if (service.PricingType == ServicePricingType.ManualInput)
                {
                    txt.Text = "0.00";
                    txt.ReadOnly = false; // Allow user input.
                    txt.Enabled = false; // Initially disabled until checkbox is checked.
                    txt.TextChanged += ServiceTextBox_TextChanged;
                    txt.TextAlign = HorizontalAlignment.Right;

                }
                else if (service.PricingType == ServicePricingType.FixedPrice)
                {
                    txt.Text = service.Fee.ToString("N2");
                    txt.ReadOnly = true;
                    txt.Enabled = false; // Initially disabled until checkbox is checked.
                    txt.TextAlign = HorizontalAlignment.Right;
                }
                else if (service.PricingType == ServicePricingType.VehicleBaseFeeMultiplier)
                {
                    txt.Text = "0.00"; // Will be calculated based on vehicle base fee.
                    txt.ReadOnly = true;
                    txt.Enabled = false; // Initially disabled until checkbox is checked.
                    txt.TextAlign = HorizontalAlignment.Right;
                }

                currentY += 30;
            }
        }

        // Method to update the total amount based on selected services and vehicle type.
        private void UpdateTotalAmount()
        {
            // Get the base fee from the selected vehicle.
            Vehicle selectedVehicle = cmbVehicleType.SelectedItem as Vehicle;
            decimal baseFee = (selectedVehicle != null) ? selectedVehicle.BaseFee : 0.00m;

            // Initialize total services fee.
            decimal servicesTotal = 0.00m;

            // Iterate through service controls to calculate total.
            foreach (Control control in serviceControls)
            {
                // Only process checked services.
                if (control is CheckBox chk && chk.Checked)
                {
                    Service service = chk.Tag as Service;
                    if (service == null) { continue; }

                    // Find the corresponding textbox for this service.
                    TextBox txt = serviceControls.FirstOrDefault(c => c is TextBox && c.Tag == service) as TextBox;

                    switch (service.PricingType)
                    {
                        case ServicePricingType.FixedPrice:
                            servicesTotal += service.Fee;
                            break;
                        case ServicePricingType.ManualInput:
                            if (txt != null && decimal.TryParse(txt.Text, out decimal manualFee))
                            {
                                servicesTotal += manualFee;
                            }
                            break;
                        case ServicePricingType.VehicleBaseFeeMultiplier:
                            decimal multiplierServiceFee = baseFee * service.Multiplier;
                            txt.Text = multiplierServiceFee.ToString("N2");
                            servicesTotal += multiplierServiceFee;
                            break;
                    }
                }
            }

            // Calculate shares for services (50% each).
            decimal serviceOwnerShare = servicesTotal * 0.5m;
            decimal serviceEmployeeShare = servicesTotal * 0.5m;

            // Update the service fee textboxes.
            txtTotalServiceFee.Text = servicesTotal.ToString("N2");
            txtServiceOwnerShare.Text = serviceOwnerShare.ToString("N2");
            txtServiceEmpShare.Text = serviceEmployeeShare.ToString("N2");

            decimal subTotal = baseFee + servicesTotal;
            decimal discountPercentage = 0.00m;

            if (cmbDiscount.SelectedItem.ToString() == "PWD" || cmbDiscount.SelectedItem.ToString() == "Senior")
            {
                discountPercentage = 0.20m; // 20% discount
            }

            decimal discountAmount = subTotal * discountPercentage;

            decimal totalAmount = subTotal - discountAmount;
            txtTotalAmount.Text = totalAmount.ToString("N2");
        }

        private void UpdateDailySummary()
        {
            List<Transaction> todaysTransaction = transactionManager.GetTodaysTransactions()
                .Where(txn => txn.WashStatus == "Completed")
                .ToList();

            decimal totalRevenue = todaysTransaction.Sum(txn => txn.TotalAmount);
            decimal totalOwnerShare = todaysTransaction.Sum(txn => txn.OwnerShare);
            decimal totalEmpShare = todaysTransaction.Sum(txn => txn.EmployeeShare);
            int totalWashes = todaysTransaction.Count();

            string mostWashedVehicle = "N/A";

            if (totalWashes > 0)
            {
                mostWashedVehicle = todaysTransaction
                    .GroupBy(txn => txn.VehicleType) // Group by vehicle type.
                    .OrderByDescending(group => group.Count()) // Order groups by count (descending).
                    .Select(group => group.Key) // Select the vehicle type (key) of the group.
                    .FirstOrDefault(); // Get the first element in the ordered list.
            }

            txtSummaryTotalRevenue.Text = totalRevenue.ToString("N2");
            txtSummaryTotalOwnerShare.Text = totalOwnerShare.ToString("N2");
            txtSummaryTotalEmpShare.Text = totalEmpShare.ToString("N2");
            txtSummaryTotalWashes.Text = totalWashes.ToString();
            txtSummaryMostWashedVehicle.Text = mostWashedVehicle;
        }

        // Method to refresh today's entries in the ListView.
        private void RefreshTodaysEntries()
        {
            // Clear existing items.
            lsvTodayEntries.Items.Clear();

            // Get today's transactions from the manager.
            List<Transaction> todaysTransactions = transactionManager.GetTodaysTransactions();

            foreach (Transaction txn in todaysTransactions)
            {
                // Create a new row (ListViewItem)
                ListViewItem row = new ListViewItem(txn.Timestamp.ToString("HH:mm"));

                // Store transaction ID in the Tag for reference when updating the Paid and Status properties.
                row.Tag = txn.ID;

                // Add the other columns (sub-items).
                row.SubItems.Add(txn.VehicleType);
                row.SubItems.Add(txn.EmployeeName);
                row.SubItems.Add(txn.TotalAmount.ToString("N2"));
                row.SubItems.Add(txn.IsPaid ? "Yes" : "No");
                row.SubItems.Add(txn.WashStatus);

                // Add the completed row to the list view.
                lsvTodayEntries.Items.Add(row);
            }

            // Update the summary panel when the transaction list is refreshed.
            UpdateDailySummary();
        }

        // Method to reset the wash entry form after adding a transaction.
        private void ResetWashEntryForm()
        {
            txtEmployeeName.Clear();
            cmbVehicleType.SelectedIndex = -1; // Triggers the SelectedIndexChanged event to clear fees
            cmbVehicleType.SelectedIndex = -1; // There is a bug in setting SelectedIndex = -1 with data-bound ComboBoxes. The work-around is to set the property twice.
            cmbDiscount.SelectedIndex = 0;

            foreach (Control control in serviceControls)
            {
                if (control is CheckBox chk)
                {
                    chk.Checked = false; // Triggers Checkbox_CheckedChanged to reset state
                }
                // Textboxes for ManualInput will be cleared by the Checkbox_CheckedChanged event.
                // Textboxes for Fixed/Multiplier will be cleared by the cmbVehicleType_SelectedIndexChanged event (since SelectedIndex = -1).
            }

            chkIsPaid.Checked = false;
            txtTotalServiceFee.Clear();
            txtServiceOwnerShare.Clear();
            txtServiceEmpShare.Clear();
            txtTotalAmount.Text = "0.00";
        }

        // Method to reload all vehicle and service data and refreshes the UI controls.
        private void RefreshCarManagerData()
        {
            // Get the data again from the manager to reflect changes made.
            vehicleTypes = carManager.GetVehicleTypes();
            services = carManager.GetServices();

            // Reload the controls.
            LoadVehicleComboBox();
            LoadServiceControls();
        }

        // Method that opens the change password form.
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordForm changePasswordForm = new ChangePasswordForm(loggedInUser);
            changePasswordForm.ShowDialog();
        }

        // Method that opens the Manage Users form (Admin Only).
        private void ManageUsers_Click(object sender, EventArgs e)
        {
            UserManagementForm userManagementForm = new UserManagementForm();
            userManagementForm.ShowDialog();
        }

        // Method that opens the Manage Vehicles form (Admin Only).
        private void ManageVehicles_Click(object sender, EventArgs e)
        {
            VehicleManagementForm vehicleManagementForm = new VehicleManagementForm(loggedInUser, carManager);
            vehicleManagementForm.ShowDialog();

            // After the Vehicle Management Form closes, refresh the dashboard's data in case there are changes.
            RefreshCarManagerData();
        }

        // Method that opens the Manage Services form (Admin Only).
        private void ManageServices_Click(object sender, EventArgs e)
        {
            ServiceManagementForm serviceManagementForm = new ServiceManagementForm(loggedInUser, carManager);
            serviceManagementForm.ShowDialog();

            // Refresh the dashboard data in case services were changed
            RefreshCarManagerData();
        }

        // Method that opens the Manage Expenses form (Admin Only).
        private void ManageExpenses_Click(object sender, EventArgs e)
        {
            ExpenseManagementForm expenseManagementForm = new ExpenseManagementForm(loggedInUser);
            expenseManagementForm.ShowDialog();

            // Refresh daily summary to reflect any changes in expenses (in case I add the expenses in the daily summary in the future).
            UpdateDailySummary();
        }

        // Method that opens the Monthly Report dashboard form (Admin Only)
        private void ShowMonthlyReport_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm();
            reportForm.ShowDialog();
        }

        // Method that allow users to logout from the main dashboard.
        private void LogoutButton_Click(object sender, EventArgs e)
        {
            DialogResult isLogout = MessageBox.Show("Are you sure you want to log out?", "Logout?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (isLogout == DialogResult.Yes)
            {
                Form loginForm = Application.OpenForms["LoginForm"];

                if (loginForm != null)
                {
                    // Clear textboxes on login form.
                    ((LoginForm)loginForm).ClearFields();
                    loginForm.Show();

                    Close();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        // Method to handle toggling paid status of a transaction from the context menu.
        private void TogglePaidStatus_Click(object sender, EventArgs e)
        {
            // Check if any item is selected in the ListView.
            if (lsvTodayEntries.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a transaction row to toggle its Paid Status.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get all the selected items from the ListView.
            ListView.SelectedListViewItemCollection selectedRows = lsvTodayEntries.SelectedItems;

            // Iterate through each selected row to toggle the IsPaid property.
            foreach (ListViewItem selectedRow in selectedRows)
            {
                string transactionID = selectedRow.Tag as string;

                Transaction txnToUpdate = transactionManager.GetTransactionByID(transactionID);

                if (txnToUpdate == null)
                {
                    MessageBox.Show("Transaction not found. Please refresh the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                txnToUpdate.IsPaid = !txnToUpdate.IsPaid; // Toggle the IsPaid property.
            }

            // Save the modified list of transactions back to the file. 
            transactionManager.UpdateTransaction();

            RefreshTodaysEntries();
        }

        // Method to handle toggling wash status of a transaction from the context menu.
        private void ToggleWashStatus_Click(object sender, EventArgs e)
        {
            if (lsvTodayEntries.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a transaction row to toggle its Wash Status.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListView.SelectedListViewItemCollection selectedRows = lsvTodayEntries.SelectedItems;

            foreach (ListViewItem row in selectedRows)
            {
                string transactionID = row.Tag as string;

                Transaction txnToUpdate = transactionManager.GetTransactionByID(transactionID);

                if (txnToUpdate == null)
                {
                    MessageBox.Show("Transaction not found. Please refresh the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                txnToUpdate.WashStatus = (txnToUpdate.WashStatus == "Ongoing") ? "Completed" : "Ongoing"; // Toggle the wash status.
            }

            transactionManager.UpdateTransaction();
            RefreshTodaysEntries();
        }

        // Method to handle when the "Add Entry" button is clicked.
        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            if (txtEmployeeName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the employee name.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbVehicleType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a vehicle type.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (Control control in serviceControls)
            {
                if (control is CheckBox chk && chk.Checked)
                {
                    Service service = chk.Tag as Service;
                    if (service != null && service.PricingType == ServicePricingType.ManualInput)
                    {
                        TextBox txt = serviceControls.FirstOrDefault(c => c is TextBox && c.Tag == service) as TextBox;

                        if (txt == null || !decimal.TryParse(txt.Text, out decimal manualFee) || manualFee <= 0)
                        {
                            MessageBox.Show($"Please enter a valid fee for the service: {service.Name}", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }

            Vehicle selectedVehicle = cmbVehicleType.SelectedItem as Vehicle;
            string employeeName = txtEmployeeName.Text.Trim();
            bool isPaid = chkIsPaid.Checked;
            string washStatus = chkWashStatus.Checked ? "Completed" : "Ongoing";
            decimal discountPercentage = (cmbDiscount.SelectedItem.ToString() == "PWD" || cmbDiscount.SelectedItem.ToString() == "Senior") ? 0.20m : 0.00m;
            List<Service> selectedServices = new List<Service>();

            // Gather selected services and get their final fees.
            foreach (Control control in serviceControls)
            {
                // Only process checked services.
                if (control is CheckBox chk && chk.Checked)
                {
                    Service service = chk.Tag as Service;
                    TextBox txt = serviceControls.FirstOrDefault(c => c is TextBox && c.Tag == service) as TextBox;

                    // Get the final service fee from the textbox (it's either fixed, calculated, or manual input).
                    decimal.TryParse(txt.Text, out decimal serviceFee);

                    // Add to selected services list.
                    selectedServices.Add(new Service
                    {
                        Name = service.Name,
                        Fee = serviceFee,
                        PricingType = service.PricingType,
                        Multiplier = service.Multiplier
                    });
                }
            }

            if (!decimal.TryParse(txtTotalAmount.Text, out decimal totalAmount) || totalAmount <= 0)
            {
                MessageBox.Show("Total amount must be greater than zero. Please check vehicle selection and services.", "Invalid Transaction", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Transaction newTransaction = transactionManager.CreateTransaction(
                    employeeName,
                    selectedVehicle,
                    selectedServices,
                    isPaid,
                    washStatus,
                    discountPercentage,
                    loggedInUser.Username
                    );

                MessageBox.Show($"Transaction {newTransaction.ID} added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ResetWashEntryForm();
                RefreshTodaysEntries();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the transaction: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to handle vehicle type selection change.
        private void cmbVehicleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Vehicle selectedVehicle = cmbVehicleType.SelectedItem as Vehicle;
            decimal baseFee = 0.00m;

            if (selectedVehicle != null)
            {
                baseFee = selectedVehicle.BaseFee;
                txtBaseFee.Text = selectedVehicle.BaseFee.ToString("N2");
                txtOwnerShare.Text = selectedVehicle.OwnerShare.ToString("N2");
                txtEmployeeShare.Text = selectedVehicle.EmployeeShare.ToString("N2");
            }
            else
            {
                // Clear the fee textboxes if no vehicle is selected.
                txtBaseFee.Clear();
                txtOwnerShare.Clear();
                txtEmployeeShare.Clear();
            }

            foreach (Control control in serviceControls)
            {
                if (control is TextBox txt)
                {
                    Service service = txt.Tag as Service;
                    if (service != null && service.PricingType == ServicePricingType.VehicleBaseFeeMultiplier)
                    {
                        decimal serviceFee = baseFee * service.Multiplier;
                        txt.Text = serviceFee.ToString("N2");
                    }
                }
            }

            // Recalculate total if the selected vehicle is changed.
            // Because services with pricing type "VehicleBaseFeeMultiplier" depends on the vehicle's base fee. 
            UpdateTotalAmount();
        }

        // Method to handle services checkbox state changes.
        private void ServiceCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            Service service = chk.Tag as Service;

            // Find the corresponding textbox for this service.
            TextBox txt = serviceControls.FirstOrDefault(c => c is TextBox && c.Tag == service) as TextBox;

            if (service.PricingType == ServicePricingType.ManualInput)
            {
                txt.Enabled = chk.Checked;
                if (!chk.Checked)
                {
                    txt.Text = "0.00";
                }
            }
            else if (service.PricingType == ServicePricingType.VehicleBaseFeeMultiplier)
            {
                txt.Enabled = chk.Checked;

            }
            else if (service.PricingType == ServicePricingType.ManualInput)
            {
                txt.Enabled = chk.Checked;
            }

            // Recalculate total amount whenever a service checkbox is ticked.
            UpdateTotalAmount();
        }

        // Method to update the total amount when the text changes in a service textbox manual input.
        private void ServiceTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateTotalAmount();
        }

        // Event handler for discount combo box
        private void cmbDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTotalAmount();
        }

        // Form closed event handler
        private void DashboardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form loginForm = Application.OpenForms["LoginForm"];

            if (loginForm != null)
            {
                // Clear textboxes on login form.
                ((LoginForm)loginForm).ClearFields();
                loginForm.Show();
            }

            Console.WriteLine("Car Wash Management System\nMiccael Jasper Tayas\nFinal Project Requirement\nCIS202 - Object Oriented Programming\nNovember 2025\n\nThank you for using the system!");
        }
    }
}