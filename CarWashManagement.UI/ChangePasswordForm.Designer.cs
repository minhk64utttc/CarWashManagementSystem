using System.Drawing;
using System.Windows.Forms;

namespace CarWashManagement.UI
{
    partial class ChangePasswordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblOldPassword = new System.Windows.Forms.Label();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelPasswordStrength = new System.Windows.Forms.Panel();
            this.lblPasswordStrength = new System.Windows.Forms.Label();
            this.progressStrength = new System.Windows.Forms.ProgressBar();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelPasswordStrength.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblOldPassword
            // 
            this.lblOldPassword.AutoSize = true;
            this.lblOldPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblOldPassword.Location = new System.Drawing.Point(25, 85);
            this.lblOldPassword.Name = "lblOldPassword";
            this.lblOldPassword.Size = new System.Drawing.Size(82, 15);
            this.lblOldPassword.TabIndex = 0;
            this.lblOldPassword.Text = "Old Password:";
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.BackColor = System.Drawing.Color.White;
            this.txtOldPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOldPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldPassword.Location = new System.Drawing.Point(28, 103);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.Size = new System.Drawing.Size(280, 23);
            this.txtOldPassword.TabIndex = 1;
            this.txtOldPassword.UseSystemPasswordChar = true;
            this.txtOldPassword.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtOldPassword.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNewPassword.Location = new System.Drawing.Point(25, 140);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(88, 15);
            this.lblNewPassword.TabIndex = 2;
            this.lblNewPassword.Text = "New Password:";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.BackColor = System.Drawing.Color.White;
            this.txtNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPassword.Location = new System.Drawing.Point(28, 158);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(280, 23);
            this.txtNewPassword.TabIndex = 2;
            this.txtNewPassword.UseSystemPasswordChar = true;
            this.txtNewPassword.TextChanged += new System.EventHandler(this.txtNewPassword_TextChanged);
            this.txtNewPassword.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtNewPassword.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblConfirmPassword.Location = new System.Drawing.Point(25, 195);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(107, 15);
            this.lblConfirmPassword.TabIndex = 4;
            this.lblConfirmPassword.Text = "Confirm Password:";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BackColor = System.Drawing.Color.White;
            this.txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPassword.Location = new System.Drawing.Point(28, 213);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(280, 23);
            this.txtConfirmPassword.TabIndex = 3;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            this.txtConfirmPassword.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtConfirmPassword.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(118)))), ((int)(((byte)(175)))));
            this.btnSubmit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(138)))), ((int)(((byte)(195)))));
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(153, 290);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 32);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btnSubmit.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(233, 290);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 32);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btnCancel.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.pictureBox1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(334, 60);
            this.panelHeader.TabIndex = 8;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(50, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(142, 21);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Change Password";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CarWashManagement.UI.Properties.Resources.security_icon;
            this.pictureBox1.Location = new System.Drawing.Point(15, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelPasswordStrength
            // 
            this.panelPasswordStrength.Controls.Add(this.lblPasswordStrength);
            this.panelPasswordStrength.Controls.Add(this.progressStrength);
            this.panelPasswordStrength.Location = new System.Drawing.Point(28, 240);
            this.panelPasswordStrength.Name = "panelPasswordStrength";
            this.panelPasswordStrength.Size = new System.Drawing.Size(280, 40);
            this.panelPasswordStrength.TabIndex = 9;
            this.panelPasswordStrength.Visible = false;
            // 
            // lblPasswordStrength
            // 
            this.lblPasswordStrength.AutoSize = true;
            this.lblPasswordStrength.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordStrength.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPasswordStrength.Location = new System.Drawing.Point(3, 3);
            this.lblPasswordStrength.Name = "lblPasswordStrength";
            this.lblPasswordStrength.Size = new System.Drawing.Size(102, 13);
            this.lblPasswordStrength.TabIndex = 1;
            this.lblPasswordStrength.Text = "Password Strength:";
            // 
            // progressStrength
            // 
            this.progressStrength.Location = new System.Drawing.Point(3, 19);
            this.progressStrength.Maximum = 4;
            this.progressStrength.Name = "progressStrength";
            this.progressStrength.Size = new System.Drawing.Size(274, 10);
            this.progressStrength.Step = 1;
            this.progressStrength.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressStrength.TabIndex = 0;
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(334, 341);
            this.Controls.Add(this.panelPasswordStrength);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.txtOldPassword);
            this.Controls.Add(this.lblOldPassword);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Password";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelPasswordStrength.ResumeLayout(false);
            this.panelPasswordStrength.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblOldPassword;
        private TextBox txtOldPassword;
        private Label lblNewPassword;
        private TextBox txtNewPassword;
        private Label lblConfirmPassword;
        private TextBox txtConfirmPassword;
        private Button btnSubmit;
        private Button btnCancel;
        private Panel panelHeader;
        private Label lblTitle;
        private PictureBox pictureBox1;
        private Panel panelPasswordStrength;
        private Label lblPasswordStrength;
        private ProgressBar progressStrength;
    }
}