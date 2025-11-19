using System.Drawing;
using System.Windows.Forms;

namespace CarWashManagement.UI
{
    partial class LoginForm
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
            this.loginPicture = new System.Windows.Forms.PictureBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.eyeIcon = new System.Windows.Forms.PictureBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.loginPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eyeIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // loginPicture
            // 
            this.loginPicture.Image = global::CarWashManagement.UI.Properties.Resources.login_image;
            this.loginPicture.Location = new System.Drawing.Point(0, 0);
            this.loginPicture.Name = "loginPicture";
            this.loginPicture.Size = new System.Drawing.Size(300, 530);
            this.loginPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.loginPicture.TabIndex = 0;
            this.loginPicture.TabStop = false;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblLogin.Location = new System.Drawing.Point(340, 100);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(189, 25);
            this.lblLogin.TabIndex = 1;
            this.lblLogin.Text = "Login to your account";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblUsername.Location = new System.Drawing.Point(340, 160);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(84, 21);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Username:";
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtUsername.Location = new System.Drawing.Point(340, 190);
            this.txtUsername.Multiline = true;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(270, 30);
            this.txtUsername.TabIndex = 1;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblPassword.Location = new System.Drawing.Point(340, 230);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(79, 21);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPassword.Location = new System.Drawing.Point(340, 260);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(270, 30);
            this.txtPassword.TabIndex = 2;
            // 
            // eyeIcon
            // 
            this.eyeIcon.Image = global::CarWashManagement.UI.Properties.Resources.eye_hide;
            this.eyeIcon.Location = new System.Drawing.Point(620, 260);
            this.eyeIcon.Name = "eyeIcon";
            this.eyeIcon.Size = new System.Drawing.Size(30, 30);
            this.eyeIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.eyeIcon.TabIndex = 6;
            this.eyeIcon.TabStop = false;
            this.eyeIcon.Click += new System.EventHandler(this.eyeIcon_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(340, 320);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(100, 40);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblInfo.Location = new System.Drawing.Point(340, 420);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(300, 100);
            this.lblInfo.TabIndex = 8;
            this.lblInfo.Text = "No account yet? Ask an administrator to create an account for you.";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 560);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.eyeIcon);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.loginPicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LoginForm";
            this.Text = "Car Wash Management - Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.loginPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eyeIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox loginPicture;
        private Label lblLogin;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private PictureBox eyeIcon;
        private Button btnLogin;
        private Label lblInfo;
    }
}