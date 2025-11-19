using CarWashManagement.Core;
using CarWashManagement.Core.FileHandlers;
using CarWashManagement.Core.Managers;
using CarWashManagement.UI.Properties;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CarWashManagement.UI
{
    public partial class ChangePasswordForm : BaseForm
    {
        private readonly AccountManager accountManager;
        private readonly User loggedInUser;

        // Color scheme
        private readonly Color primaryColor = Color.FromArgb(41, 128, 185);
        private readonly Color successColor = Color.FromArgb(46, 204, 113);
        private readonly Color warningColor = Color.FromArgb(231, 76, 60);
        private readonly Color weakColor = Color.FromArgb(231, 76, 60);
        private readonly Color mediumColor = Color.FromArgb(241, 196, 15);
        private readonly Color strongColor = Color.FromArgb(46, 204, 113);

        public ChangePasswordForm(User user)
        {
            loggedInUser = user;

            accountManager = new AccountManager(
                new UserFileHandler(),
                new AuditFileHandler()
            );

            InitializeComponent();
            InitializeAnimations();
        }

        private void InitializeAnimations()
        {
            // Set initial states for animations
            this.Opacity = 0;
            this.panelPasswordStrength.Visible = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Fade-in animation
            Timer fadeInTimer = new Timer();
            fadeInTimer.Interval = 10;
            fadeInTimer.Tick += (s, args) =>
            {
                if (this.Opacity < 1)
                    this.Opacity += 0.05;
                else
                    fadeInTimer.Stop();
            };
            fadeInTimer.Start();
        }

        // TextBox enter/leave animations
        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                textBox.BackColor = Color.FromArgb(240, 248, 255); // Light blue
                textBox.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                textBox.BackColor = Color.White;
                textBox.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        // Button hover animations
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                button.Font = new Font(button.Font, FontStyle.Bold);
                button.Cursor = Cursors.Hand;
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                button.Font = new Font(button.Font, FontStyle.Regular);
                button.Cursor = Cursors.Default;
            }
        }

        // Password strength checker
        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            string password = txtNewPassword.Text;

            if (string.IsNullOrEmpty(password))
            {
                panelPasswordStrength.Visible = false;
                return;
            }

            panelPasswordStrength.Visible = true;
            UpdatePasswordStrength(password);
        }

        private void UpdatePasswordStrength(string password)
        {
            int strength = 0;
            string strengthText = "";
            Color strengthColor = weakColor;

            // Check criteria
            if (password.Length >= 8) strength++;
            if (password.Any(char.IsUpper)) strength++;
            if (password.Any(char.IsLower)) strength++;
            if (password.Any(char.IsDigit)) strength++;
            if (password.Any(ch => !char.IsLetterOrDigit(ch))) strength++;

            // Update progress bar and label
            progressStrength.Value = strength;

            switch (strength)
            {
                case 0:
                case 1:
                    strengthText = "Very Weak";
                    strengthColor = weakColor;
                    break;
                case 2:
                    strengthText = "Weak";
                    strengthColor = weakColor;
                    break;
                case 3:
                    strengthText = "Medium";
                    strengthColor = mediumColor;
                    break;
                case 4:
                    strengthText = "Strong";
                    strengthColor = strongColor;
                    break;
                case 5:
                    strengthText = "Very Strong";
                    strengthColor = successColor;
                    break;
            }

            progressStrength.ForeColor = strengthColor;
            lblPasswordStrength.Text = $"Password Strength: {strengthText}";
            lblPasswordStrength.ForeColor = strengthColor;

            // Animate progress bar color change
            AnimateProgressBarColor(strengthColor);
        }

        private void AnimateProgressBarColor(Color targetColor)
        {
            Timer colorTimer = new Timer();
            colorTimer.Interval = 50;
            int steps = 10;
            int currentStep = 0;

            Color currentColor = progressStrength.ForeColor;

            colorTimer.Tick += (s, args) =>
            {
                if (currentStep >= steps)
                {
                    colorTimer.Stop();
                    return;
                }

                int r = currentColor.R + (targetColor.R - currentColor.R) * currentStep / steps;
                int g = currentColor.G + (targetColor.G - currentColor.G) * currentStep / steps;
                int b = currentColor.B + (targetColor.B - currentColor.B) * currentStep / steps;

                progressStrength.ForeColor = Color.FromArgb(r, g, b);
                currentStep++;
            };

            colorTimer.Start();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string oldPassword = txtOldPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Add button click animation
            AnimateButtonClick(btnSubmit);

            // Validation with visual feedback
            if (!ValidateInputs(oldPassword, newPassword, confirmPassword))
                return;

            bool success = accountManager.ChangePassword(loggedInUser.Username, oldPassword, newPassword);

            if (success)
            {
                ShowSuccessMessage();
            }
            else
            {
                ShowErrorMessage();
            }
        }

        private bool ValidateInputs(string oldPassword, string newPassword, string confirmPassword)
        {
            bool isValid = true;

            // Reset all textbox borders
            ResetTextBoxBorders();

            if (string.IsNullOrWhiteSpace(oldPassword))
            {
                HighlightError(txtOldPassword);
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                HighlightError(txtNewPassword);
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(confirmPassword))
            {
                HighlightError(txtConfirmPassword);
                isValid = false;
            }

            if (!isValid)
            {
                MessageBox.Show("All fields are required.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check password requirements
            bool hasUpper = newPassword.Any(char.IsUpper);
            bool hasLower = newPassword.Any(char.IsLower);
            bool hasDigit = newPassword.Any(char.IsDigit);

            if (newPassword.Length < 8 || !hasUpper || !hasLower || !hasDigit)
            {
                string message = "Password must meet the following requirements:\n" +
                                 "• At least 8 characters long\n" +
                                 "• Contains at least one uppercase letter\n" +
                                 "• Contains at least one lowercase letter\n" +
                                 "• Contains at least one digit\n";

                MessageBox.Show(message, "Password Requirements",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                HighlightError(txtNewPassword);
                return false;
            }

            // Check password match
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("The new passwords do not match.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                HighlightError(txtConfirmPassword);
                return false;
            }

            return true;
        }

        private void ResetTextBoxBorders()
        {
            txtOldPassword.BorderStyle = BorderStyle.FixedSingle;
            txtNewPassword.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
        }

        private void HighlightError(TextBox textBox)
        {
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.BackColor = Color.FromArgb(255, 240, 240); // Light red

            // Shake animation for error
            ShakeControl(textBox);
        }

        private void ShakeControl(Control control)
        {
            Timer shakeTimer = new Timer();
            shakeTimer.Interval = 50;
            int shakeCount = 0;
            Point originalLocation = control.Location;

            shakeTimer.Tick += (s, args) =>
            {
                if (shakeCount >= 6)
                {
                    control.Location = originalLocation;
                    shakeTimer.Stop();
                    return;
                }

                int offset = (shakeCount % 2 == 0) ? 3 : -3;
                control.Location = new Point(originalLocation.X + offset, originalLocation.Y);
                shakeCount++;
            };

            shakeTimer.Start();
        }

        private void AnimateButtonClick(Button button)
        {
            Color originalColor = button.BackColor;
            button.BackColor = Color.FromArgb(
                Math.Max(originalColor.R - 20, 0),
                Math.Max(originalColor.G - 20, 0),
                Math.Max(originalColor.B - 20, 0)
            );

            Timer resetTimer = new Timer();
            resetTimer.Interval = 100;
            resetTimer.Tick += (s, args) =>
            {
                button.BackColor = originalColor;
                resetTimer.Stop();
            };
            resetTimer.Start();
        }

        private void ShowSuccessMessage()
        {
            // Visual feedback for success
            btnSubmit.BackColor = successColor;
            btnSubmit.Text = "✓ Success!";

            Timer messageTimer = new Timer();
            messageTimer.Interval = 1500;
            messageTimer.Tick += (s, args) =>
            {
                MessageBox.Show("Password changed successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                messageTimer.Stop();
                this.Close();
            };
            messageTimer.Start();
        }

        private void ShowErrorMessage()
        {
            MessageBox.Show("The 'Old Password' was incorrect. Please try again.",
                "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            txtOldPassword.Clear();
            txtOldPassword.Focus();

            // Visual feedback for error
            HighlightError(txtOldPassword);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Fade-out animation
            Timer fadeOutTimer = new Timer();
            fadeOutTimer.Interval = 10;
            fadeOutTimer.Tick += (s, args) =>
            {
                if (this.Opacity > 0)
                    this.Opacity -= 0.05;
                else
                {
                    fadeOutTimer.Stop();
                    this.Close();
                }
            };
            fadeOutTimer.Start();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            // Clean up any timers
            foreach (Control control in this.Controls)
            {
                var timers = control.Tag as Timer;
                timers?.Dispose();
            }
        }
    }
}