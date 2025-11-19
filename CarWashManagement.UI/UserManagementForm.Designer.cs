using System.Drawing;
using System.Windows.Forms;

namespace CarWashManagement.UI
{
    partial class UserManagementForm
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
            this.lsvUsers = new System.Windows.Forms.ListView();
            this.columnUsername = new System.Windows.Forms.ColumnHeader();
            this.columnFullName = new System.Windows.Forms.ColumnHeader();
            this.columnRole = new System.Windows.Forms.ColumnHeader();
            this.columnStatus = new System.Windows.Forms.ColumnHeader();
            this.columnFailedAttempts = new System.Windows.Forms.ColumnHeader();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.btnCreateUser = new System.Windows.Forms.Button();
            this.btnToggleStatus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lsvUsers
            // 
            this.lsvUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnUsername,
            this.columnFullName,
            this.columnRole,
            this.columnStatus,
            this.columnFailedAttempts});
            this.lsvUsers.FullRowSelect = true;
            this.lsvUsers.Location = new System.Drawing.Point(15, 15);
            this.lsvUsers.Name = "lsvUsers";
            this.lsvUsers.Size = new System.Drawing.Size(550, 200);
            this.lsvUsers.TabIndex = 0;
            this.lsvUsers.UseCompatibleStateImageBehavior = false;
            this.lsvUsers.View = System.Windows.Forms.View.Details;
            // 
            // columnUsername
            // 
            this.columnUsername.Text = "Username";
            this.columnUsername.Width = 100;
            // 
            // columnFullName
            // 
            this.columnFullName.Text = "Full Name";
            this.columnFullName.Width = 150;
            // 
            // columnRole
            // 
            this.columnRole.Text = "Role";
            this.columnRole.Width = 80;
            // 
            // columnStatus
            // 
            this.columnStatus.Text = "Status";
            this.columnStatus.Width = 80;
            // 
            // columnFailedAttempts
            // 
            this.columnFailedAttempts.Text = "Failed Attempts";
            this.columnFailedAttempts.Width = 110;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(15, 230);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(80, 227);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(120, 20);
            this.txtUsername.TabIndex = 1;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(215, 230);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(280, 227);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(120, 20);
            this.txtPassword.TabIndex = 2;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(15, 260);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(57, 13);
            this.lblFullName.TabIndex = 5;
            this.lblFullName.Text = "Full Name:";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(80, 257);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(120, 20);
            this.txtFullName.TabIndex = 3;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(215, 260);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(32, 13);
            this.lblRole.TabIndex = 7;
            this.lblRole.Text = "Role:";
            // 
            // cmbRole
            // 
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Items.AddRange(new object[] {
            "Admin",
            "Recorder"});
            this.cmbRole.Location = new System.Drawing.Point(280, 257);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(120, 21);
            this.cmbRole.TabIndex = 4;
            // 
            // btnCreateUser
            // 
            this.btnCreateUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnCreateUser.FlatAppearance.BorderSize = 0;
            this.btnCreateUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateUser.ForeColor = System.Drawing.Color.White;
            this.btnCreateUser.Location = new System.Drawing.Point(420, 227);
            this.btnCreateUser.Name = "btnCreateUser";
            this.btnCreateUser.Size = new System.Drawing.Size(140, 30);
            this.btnCreateUser.TabIndex = 5;
            this.btnCreateUser.Text = "Create User";
            this.btnCreateUser.UseVisualStyleBackColor = false;
            this.btnCreateUser.Click += new System.EventHandler(this.btnCreateUser_Click);
            // 
            // btnToggleStatus
            // 
            this.btnToggleStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnToggleStatus.FlatAppearance.BorderSize = 0;
            this.btnToggleStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleStatus.ForeColor = System.Drawing.Color.White;
            this.btnToggleStatus.Location = new System.Drawing.Point(420, 257);
            this.btnToggleStatus.Name = "btnToggleStatus";
            this.btnToggleStatus.Size = new System.Drawing.Size(140, 30);
            this.btnToggleStatus.TabIndex = 6;
            this.btnToggleStatus.Text = "Activate / Deactivate Selected";
            this.btnToggleStatus.UseVisualStyleBackColor = false;
            this.btnToggleStatus.Click += new System.EventHandler(this.btnToggleStatus_Click);
            // 
            // UserManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 311);
            this.Controls.Add(this.btnToggleStatus);
            this.Controls.Add(this.btnCreateUser);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lsvUsers);
            this.Name = "UserManagementForm";
            this.Text = "User Management";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView lsvUsers;
        private ColumnHeader columnUsername;
        private ColumnHeader columnFullName;
        private ColumnHeader columnRole;
        private ColumnHeader columnStatus;
        private ColumnHeader columnFailedAttempts;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblRole;
        private ComboBox cmbRole;
        private Button btnCreateUser;
        private Button btnToggleStatus;
    }
}