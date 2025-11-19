using System;
using System.Drawing;
using System.Windows.Forms;
using CarWashManagement.Core.FileHandlers;
using CarWashManagement.Core.Managers;
using CarWashManagement.Core;
using CarWashManagement.UI.Properties;

namespace CarWashManagement.UI
{
    public partial class LoginForm : BaseForm
    {
        private readonly AccountManager accountManager;

        public LoginForm()
        {
            UserFileHandler userFileHandler = new UserFileHandler();
            AuditFileHandler auditFileHandler = new AuditFileHandler();

            accountManager = new AccountManager(userFileHandler, auditFileHandler);

            InitializeComponent();
        }

        // Method that is executed when the login button is clicked.
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Get the text from the text boxes.
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all required fields before proceeding.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Call the account manager to try to login using the given credentials.
                // It will return the loggedInUser object if successful.
                string loginResult = accountManager.Login(username, password, out User loggedInUser);

                if (loginResult == "SUCCESS")
                {
                    // Create the new dashboard and pass in the logged-in user.
                    DashboardForm dashboard = new DashboardForm(loggedInUser);
                    dashboard.Show();

                    // Hide the login form.
                    Hide();
                }
                else
                {
                    MessageBox.Show(loginResult, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occured: {ex.Message}", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        public void ClearFields()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtPassword.UseSystemPasswordChar = false;
            eyeIcon.Image = Resources.eye_hide;
            txtUsername.Focus();
        }

        private void eyeIcon_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            eyeIcon.Image = txtPassword.UseSystemPasswordChar ? Resources.eye_show : Resources.eye_hide;
        }

        // Form closed event handler
        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Check if the application is still running forms
            // Only exit the entire application if no other forms are running.
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
        }
    }
}