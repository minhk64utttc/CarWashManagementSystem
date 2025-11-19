using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CarWashManagement.Core;
using CarWashManagement.Core.Managers;
using CarWashManagement.Core.FileHandlers;

namespace CarWashManagement.UI
{
    // Form that allows admin to create, unlock, activate, and deactivate accounts.
    public partial class UserManagementForm : BaseForm
    {
        private readonly AccountManager accountManager;

        public UserManagementForm()
        {
            accountManager = new AccountManager(
                new UserFileHandler(),
                new AuditFileHandler()
                );

            InitializeComponent();
            LoadUserList();
            InitializeRoleComboBox();
        }

        // Initialize the role combo box with default selection
        private void InitializeRoleComboBox()
        {
            cmbRole.SelectedIndex = 1; // Default to Recorder
        }

        // Method to load all users using the account manager into the ListView.
        public void LoadUserList()
        {
            lsvUsers.Items.Clear();

            List<User> users = accountManager.GetAllUsers();

            foreach (User user in users)
            {
                ListViewItem row = new ListViewItem(user.Username);
                row.SubItems.Add(user.FullName);
                row.SubItems.Add(user.Role);
                row.SubItems.Add(user.Status);
                row.SubItems.Add(user.FailedLoginAttempts.ToString());
                row.Tag = user;

                lsvUsers.Items.Add(row);
            }
        }

        // Method to create a new user when the "Create User" button is clicked.
        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string fullName = txtFullName.Text.Trim();

            if (cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Please select a role.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string role = cmbRole.SelectedItem.ToString().ToUpper();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrEmpty(fullName))
            {
                MessageBox.Show("Please fill in all fields.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = accountManager.CreateUser(username, password, role, fullName);

            if (success)
            {
                MessageBox.Show("User created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUserList(); // Refresh the list

                // Clear input fields
                txtUsername.Clear();
                txtPassword.Clear();
                txtFullName.Clear();
                cmbRole.SelectedIndex = 1;
            }
            else
            {
                MessageBox.Show("A user with this username already exists.", "Account Creation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to toggle account status of the user when the button is clicked.
        private void btnToggleStatus_Click(object sender, EventArgs e)
        {
            if (lsvUsers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a user from the list.", "No User Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            User selectedUser = lsvUsers.SelectedItems[0].Tag as User;

            if (selectedUser.Username.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("The default admin account cannot be deactivated.", "Action Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (selectedUser.Status == "ACTIVE")
            {
                accountManager.DeactivateUser(selectedUser.Username);
                MessageBox.Show($"User '{selectedUser.Username}' has been deactivated.", "User Deactivated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string originalStatus = selectedUser.Status;

                accountManager.ActivateUser(selectedUser.Username);

                if (originalStatus == "LOCKED")
                {
                    MessageBox.Show($"User '{selectedUser.Username}' has been unlocked and activated.", "User Unlocked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"User '{selectedUser.Username}' has been activated.", "User Activated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            LoadUserList(); // Refresh the list
        }
    }
}