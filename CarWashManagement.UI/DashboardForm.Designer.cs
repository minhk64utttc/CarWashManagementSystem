using System.Drawing;
using System.Windows.Forms;

namespace CarWashManagement.UI
{
    partial class DashboardForm
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
            this.headerPanel = new System.Windows.Forms.Panel();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.logoutButton = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.adminMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageVehiclesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageServicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageExpensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthlyYearlyReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.washEntryPanel = new System.Windows.Forms.Panel();
            this.btnAddTransaction = new System.Windows.Forms.Button();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.cmbDiscount = new System.Windows.Forms.ComboBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.chkWashStatus = new System.Windows.Forms.CheckBox();
            this.chkIsPaid = new System.Windows.Forms.CheckBox();
            this.txtServiceEmpShare = new System.Windows.Forms.TextBox();
            this.lblServiceEmpShare = new System.Windows.Forms.Label();
            this.txtServiceOwnerShare = new System.Windows.Forms.TextBox();
            this.lblServiceOwnerShare = new System.Windows.Forms.Label();
            this.txtTotalServiceFee = new System.Windows.Forms.TextBox();
            this.lblTotalServiceFee = new System.Windows.Forms.Label();
            this.servicePanel = new System.Windows.Forms.Panel();
            this.lblAdditionalServices = new System.Windows.Forms.Label();
            this.txtEmployeeShare = new System.Windows.Forms.TextBox();
            this.lblEmployeeShare = new System.Windows.Forms.Label();
            this.txtOwnerShare = new System.Windows.Forms.TextBox();
            this.lblOwnerShare = new System.Windows.Forms.Label();
            this.txtBaseFee = new System.Windows.Forms.TextBox();
            this.lblBaseFee = new System.Windows.Forms.Label();
            this.cmbVehicleType = new System.Windows.Forms.ComboBox();
            this.lblVehicleType = new System.Windows.Forms.Label();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.todaysEntriesPanel = new System.Windows.Forms.Panel();
            this.lsvTodayEntries = new System.Windows.Forms.ListView();
            this.columnTime = new System.Windows.Forms.ColumnHeader();
            this.columnVehicle = new System.Windows.Forms.ColumnHeader();
            this.columnEmployee = new System.Windows.Forms.ColumnHeader();
            this.columnTotal = new System.Windows.Forms.ColumnHeader();
            this.columnPaid = new System.Windows.Forms.ColumnHeader();
            this.columnWashStatus = new System.Windows.Forms.ColumnHeader();
            this.lsvContextMenu = new System.Windows.Forms.ContextMenuStrip();
            this.togglePaidStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleWashStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailySummaryPanel = new System.Windows.Forms.Panel();
            this.txtSummaryMostWashedVehicle = new System.Windows.Forms.TextBox();
            this.lblSummaryMostWashedVehicle = new System.Windows.Forms.Label();
            this.txtSummaryTotalWashes = new System.Windows.Forms.TextBox();
            this.lblSummaryTotalWashes = new System.Windows.Forms.Label();
            this.txtSummaryTotalEmpShare = new System.Windows.Forms.TextBox();
            this.lblSummaryTotalEmpShare = new System.Windows.Forms.Label();
            this.txtSummaryTotalOwnerShare = new System.Windows.Forms.TextBox();
            this.lblSummaryTotalOwnerShare = new System.Windows.Forms.Label();
            this.txtSummaryTotalRevenue = new System.Windows.Forms.TextBox();
            this.lblSummaryTotalRevenue = new System.Windows.Forms.Label();
            this.lblDailySummary = new System.Windows.Forms.Label();
            this.headerPanel.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.washEntryPanel.SuspendLayout();
            this.todaysEntriesPanel.SuspendLayout();
            this.lsvContextMenu.SuspendLayout();
            this.dailySummaryPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.headerPanel.Controls.Add(this.welcomeLabel);
            this.headerPanel.Controls.Add(this.logoutButton);
            this.headerPanel.Controls.Add(this.btnChangePassword);
            this.headerPanel.Controls.Add(this.mainMenu);
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(785, 40);
            this.headerPanel.TabIndex = 0;
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.BackColor = System.Drawing.Color.White;
            this.welcomeLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.welcomeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.welcomeLabel.Location = new System.Drawing.Point(10, 10);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(52, 20);
            this.welcomeLabel.TabIndex = 0;
            this.welcomeLabel.Text = "label1";
            // 
            // logoutButton
            // 
            this.logoutButton.BackColor = System.Drawing.Color.White;
            this.logoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.logoutButton.Location = new System.Drawing.Point(700, 5);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(75, 30);
            this.logoutButton.TabIndex = 2;
            this.logoutButton.Text = "Logout";
            this.logoutButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.logoutButton.UseVisualStyleBackColor = false;
            this.logoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.BackColor = System.Drawing.Color.White;
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnChangePassword.Location = new System.Drawing.Point(570, 5);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(125, 30);
            this.btnChangePassword.TabIndex = 1;
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnChangePassword.UseVisualStyleBackColor = false;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // mainMenu
            // 
            this.mainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.mainMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.mainMenu.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.mainMenu.ForeColor = System.Drawing.Color.White;
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 15);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(56, 25);
            this.mainMenu.TabIndex = 3;
            // 
            // adminMenuItem
            // 
            this.adminMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.adminMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageUsersToolStripMenuItem,
            this.manageVehiclesToolStripMenuItem,
            this.manageServicesToolStripMenuItem,
            this.manageExpensesToolStripMenuItem,
            this.monthlyYearlyReportToolStripMenuItem});
            this.adminMenuItem.Name = "adminMenuItem";
            this.adminMenuItem.Size = new System.Drawing.Size(48, 21);
            this.adminMenuItem.Text = "•••";
            this.adminMenuItem.Visible = false;
            // 
            // manageUsersToolStripMenuItem
            // 
            this.manageUsersToolStripMenuItem.Name = "manageUsersToolStripMenuItem";
            this.manageUsersToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.manageUsersToolStripMenuItem.Text = "Manage Users";
            this.manageUsersToolStripMenuItem.Click += new System.EventHandler(this.ManageUsers_Click);
            // 
            // manageVehiclesToolStripMenuItem
            // 
            this.manageVehiclesToolStripMenuItem.Name = "manageVehiclesToolStripMenuItem";
            this.manageVehiclesToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.manageVehiclesToolStripMenuItem.Text = "Manage Vehicles";
            this.manageVehiclesToolStripMenuItem.Click += new System.EventHandler(this.ManageVehicles_Click);
            // 
            // manageServicesToolStripMenuItem
            // 
            this.manageServicesToolStripMenuItem.Name = "manageServicesToolStripMenuItem";
            this.manageServicesToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.manageServicesToolStripMenuItem.Text = "Manage Services";
            this.manageServicesToolStripMenuItem.Click += new System.EventHandler(this.ManageServices_Click);
            // 
            // manageExpensesToolStripMenuItem
            // 
            this.manageExpensesToolStripMenuItem.Name = "manageExpensesToolStripMenuItem";
            this.manageExpensesToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.manageExpensesToolStripMenuItem.Text = "Manage Expenses";
            this.manageExpensesToolStripMenuItem.Click += new System.EventHandler(this.ManageExpenses_Click);
            // 
            // monthlyYearlyReportToolStripMenuItem
            // 
            this.monthlyYearlyReportToolStripMenuItem.Name = "monthlyYearlyReportToolStripMenuItem";
            this.monthlyYearlyReportToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.monthlyYearlyReportToolStripMenuItem.Text = "Monthly/Yearly Report";
            this.monthlyYearlyReportToolStripMenuItem.Click += new System.EventHandler(this.ShowMonthlyReport_Click);
            // 
            // washEntryPanel
            // 
            this.washEntryPanel.BackColor = System.Drawing.Color.White;
            this.washEntryPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.washEntryPanel.Controls.Add(this.btnAddTransaction);
            this.washEntryPanel.Controls.Add(this.txtTotalAmount);
            this.washEntryPanel.Controls.Add(this.lblTotalAmount);
            this.washEntryPanel.Controls.Add(this.cmbDiscount);
            this.washEntryPanel.Controls.Add(this.lblDiscount);
            this.washEntryPanel.Controls.Add(this.chkWashStatus);
            this.washEntryPanel.Controls.Add(this.chkIsPaid);
            this.washEntryPanel.Controls.Add(this.txtServiceEmpShare);
            this.washEntryPanel.Controls.Add(this.lblServiceEmpShare);
            this.washEntryPanel.Controls.Add(this.txtServiceOwnerShare);
            this.washEntryPanel.Controls.Add(this.lblServiceOwnerShare);
            this.washEntryPanel.Controls.Add(this.txtTotalServiceFee);
            this.washEntryPanel.Controls.Add(this.lblTotalServiceFee);
            this.washEntryPanel.Controls.Add(this.servicePanel);
            this.washEntryPanel.Controls.Add(this.lblAdditionalServices);
            this.washEntryPanel.Controls.Add(this.txtEmployeeShare);
            this.washEntryPanel.Controls.Add(this.lblEmployeeShare);
            this.washEntryPanel.Controls.Add(this.txtOwnerShare);
            this.washEntryPanel.Controls.Add(this.lblOwnerShare);
            this.washEntryPanel.Controls.Add(this.txtBaseFee);
            this.washEntryPanel.Controls.Add(this.lblBaseFee);
            this.washEntryPanel.Controls.Add(this.cmbVehicleType);
            this.washEntryPanel.Controls.Add(this.lblVehicleType);
            this.washEntryPanel.Controls.Add(this.txtEmployeeName);
            this.washEntryPanel.Controls.Add(this.lblEmployee);
            this.washEntryPanel.Location = new System.Drawing.Point(10, 60);
            this.washEntryPanel.Name = "washEntryPanel";
            this.washEntryPanel.Size = new System.Drawing.Size(300, 590);
            this.washEntryPanel.TabIndex = 1;
            // 
            // btnAddTransaction
            // 
            this.btnAddTransaction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnAddTransaction.FlatAppearance.BorderSize = 0;
            this.btnAddTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTransaction.ForeColor = System.Drawing.Color.White;
            this.btnAddTransaction.Location = new System.Drawing.Point(10, 550);
            this.btnAddTransaction.Name = "btnAddTransaction";
            this.btnAddTransaction.Size = new System.Drawing.Size(270, 30);
            this.btnAddTransaction.TabIndex = 23;
            this.btnAddTransaction.Text = "Add Entry";
            this.btnAddTransaction.UseVisualStyleBackColor = false;
            this.btnAddTransaction.Click += new System.EventHandler(this.btnAddTransaction_Click);
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.BackColor = System.Drawing.Color.White;
            this.txtTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalAmount.Location = new System.Drawing.Point(120, 512);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(160, 20);
            this.txtTotalAmount.TabIndex = 22;
            this.txtTotalAmount.Text = "0.00";
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTotalAmount.Location = new System.Drawing.Point(10, 515);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(104, 19);
            this.lblTotalAmount.TabIndex = 21;
            this.lblTotalAmount.Text = "Total Amount:";
            // 
            // cmbDiscount
            // 
            this.cmbDiscount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbDiscount.FormattingEnabled = true;
            this.cmbDiscount.Items.AddRange(new object[] {
            "N/A",
            "PWD",
            "Senior"});
            this.cmbDiscount.Location = new System.Drawing.Point(220, 450);
            this.cmbDiscount.Name = "cmbDiscount";
            this.cmbDiscount.Size = new System.Drawing.Size(60, 21);
            this.cmbDiscount.TabIndex = 20;
            this.cmbDiscount.SelectedIndexChanged += new System.EventHandler(this.cmbDiscount_SelectedIndexChanged);
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(160, 453);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(52, 13);
            this.lblDiscount.TabIndex = 19;
            this.lblDiscount.Text = "Discount:";
            // 
            // chkWashStatus
            // 
            this.chkWashStatus.AutoSize = true;
            this.chkWashStatus.Location = new System.Drawing.Point(10, 480);
            this.chkWashStatus.Name = "chkWashStatus";
            this.chkWashStatus.Size = new System.Drawing.Size(119, 17);
            this.chkWashStatus.TabIndex = 18;
            this.chkWashStatus.Text = "Mark as Completed";
            this.chkWashStatus.UseVisualStyleBackColor = true;
            // 
            // chkIsPaid
            // 
            this.chkIsPaid.AutoSize = true;
            this.chkIsPaid.Location = new System.Drawing.Point(10, 453);
            this.chkIsPaid.Name = "chkIsPaid";
            this.chkIsPaid.Size = new System.Drawing.Size(106, 17);
            this.chkIsPaid.TabIndex = 17;
            this.chkIsPaid.Text = "Paid by Employee";
            this.chkIsPaid.UseVisualStyleBackColor = true;
            // 
            // txtServiceEmpShare
            // 
            this.txtServiceEmpShare.BackColor = System.Drawing.Color.White;
            this.txtServiceEmpShare.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtServiceEmpShare.Location = new System.Drawing.Point(190, 420);
            this.txtServiceEmpShare.Name = "txtServiceEmpShare";
            this.txtServiceEmpShare.ReadOnly = true;
            this.txtServiceEmpShare.Size = new System.Drawing.Size(80, 20);
            this.txtServiceEmpShare.TabIndex = 16;
            this.txtServiceEmpShare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblServiceEmpShare
            // 
            this.lblServiceEmpShare.AutoSize = true;
            this.lblServiceEmpShare.Location = new System.Drawing.Point(190, 400);
            this.lblServiceEmpShare.Name = "lblServiceEmpShare";
            this.lblServiceEmpShare.Size = new System.Drawing.Size(97, 13);
            this.lblServiceEmpShare.TabIndex = 15;
            this.lblServiceEmpShare.Text = "Employee Share:";
            // 
            // txtServiceOwnerShare
            // 
            this.txtServiceOwnerShare.BackColor = System.Drawing.Color.White;
            this.txtServiceOwnerShare.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtServiceOwnerShare.Location = new System.Drawing.Point(100, 420);
            this.txtServiceOwnerShare.Name = "txtServiceOwnerShare";
            this.txtServiceOwnerShare.ReadOnly = true;
            this.txtServiceOwnerShare.Size = new System.Drawing.Size(80, 20);
            this.txtServiceOwnerShare.TabIndex = 14;
            this.txtServiceOwnerShare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblServiceOwnerShare
            // 
            this.lblServiceOwnerShare.AutoSize = true;
            this.lblServiceOwnerShare.Location = new System.Drawing.Point(100, 400);
            this.lblServiceOwnerShare.Name = "lblServiceOwnerShare";
            this.lblServiceOwnerShare.Size = new System.Drawing.Size(77, 13);
            this.lblServiceOwnerShare.TabIndex = 13;
            this.lblServiceOwnerShare.Text = "Owner Share:";
            // 
            // txtTotalServiceFee
            // 
            this.txtTotalServiceFee.BackColor = System.Drawing.Color.White;
            this.txtTotalServiceFee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalServiceFee.Location = new System.Drawing.Point(10, 420);
            this.txtTotalServiceFee.Name = "txtTotalServiceFee";
            this.txtTotalServiceFee.ReadOnly = true;
            this.txtTotalServiceFee.Size = new System.Drawing.Size(80, 20);
            this.txtTotalServiceFee.TabIndex = 12;
            this.txtTotalServiceFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalServiceFee
            // 
            this.lblTotalServiceFee.AutoSize = true;
            this.lblTotalServiceFee.Location = new System.Drawing.Point(10, 400);
            this.lblTotalServiceFee.Name = "lblTotalServiceFee";
            this.lblTotalServiceFee.Size = new System.Drawing.Size(80, 13);
            this.lblTotalServiceFee.TabIndex = 11;
            this.lblTotalServiceFee.Text = "Service/s Fee:";
            // 
            // servicePanel
            // 
            this.servicePanel.AutoScroll = true;
            this.servicePanel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.servicePanel.Location = new System.Drawing.Point(10, 195);
            this.servicePanel.Name = "servicePanel";
            this.servicePanel.Size = new System.Drawing.Size(280, 200);
            this.servicePanel.TabIndex = 10;
            // 
            // lblAdditionalServices
            // 
            this.lblAdditionalServices.AutoSize = true;
            this.lblAdditionalServices.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAdditionalServices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblAdditionalServices.Location = new System.Drawing.Point(10, 175);
            this.lblAdditionalServices.Name = "lblAdditionalServices";
            this.lblAdditionalServices.Size = new System.Drawing.Size(143, 20);
            this.lblAdditionalServices.TabIndex = 9;
            this.lblAdditionalServices.Text = "Additional Services:";
            // 
            // txtEmployeeShare
            // 
            this.txtEmployeeShare.BackColor = System.Drawing.Color.White;
            this.txtEmployeeShare.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmployeeShare.Location = new System.Drawing.Point(190, 135);
            this.txtEmployeeShare.Name = "txtEmployeeShare";
            this.txtEmployeeShare.ReadOnly = true;
            this.txtEmployeeShare.Size = new System.Drawing.Size(80, 20);
            this.txtEmployeeShare.TabIndex = 8;
            this.txtEmployeeShare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblEmployeeShare
            // 
            this.lblEmployeeShare.AutoSize = true;
            this.lblEmployeeShare.Location = new System.Drawing.Point(190, 115);
            this.lblEmployeeShare.Name = "lblEmployeeShare";
            this.lblEmployeeShare.Size = new System.Drawing.Size(91, 13);
            this.lblEmployeeShare.TabIndex = 7;
            this.lblEmployeeShare.Text = "Employee Share:";
            // 
            // txtOwnerShare
            // 
            this.txtOwnerShare.BackColor = System.Drawing.Color.White;
            this.txtOwnerShare.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOwnerShare.Location = new System.Drawing.Point(100, 135);
            this.txtOwnerShare.Name = "txtOwnerShare";
            this.txtOwnerShare.ReadOnly = true;
            this.txtOwnerShare.Size = new System.Drawing.Size(80, 20);
            this.txtOwnerShare.TabIndex = 6;
            this.txtOwnerShare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblOwnerShare
            // 
            this.lblOwnerShare.AutoSize = true;
            this.lblOwnerShare.Location = new System.Drawing.Point(100, 115);
            this.lblOwnerShare.Name = "lblOwnerShare";
            this.lblOwnerShare.Size = new System.Drawing.Size(74, 13);
            this.lblOwnerShare.TabIndex = 5;
            this.lblOwnerShare.Text = "Owner Share:";
            // 
            // txtBaseFee
            // 
            this.txtBaseFee.BackColor = System.Drawing.Color.White;
            this.txtBaseFee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBaseFee.Location = new System.Drawing.Point(10, 135);
            this.txtBaseFee.Name = "txtBaseFee";
            this.txtBaseFee.ReadOnly = true;
            this.txtBaseFee.Size = new System.Drawing.Size(80, 20);
            this.txtBaseFee.TabIndex = 4;
            this.txtBaseFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBaseFee
            // 
            this.lblBaseFee.AutoSize = true;
            this.lblBaseFee.Location = new System.Drawing.Point(10, 115);
            this.lblBaseFee.Name = "lblBaseFee";
            this.lblBaseFee.Size = new System.Drawing.Size(56, 13);
            this.lblBaseFee.TabIndex = 3;
            this.lblBaseFee.Text = "Base Fee:";
            // 
            // cmbVehicleType
            // 
            this.cmbVehicleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVehicleType.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cmbVehicleType.FormattingEnabled = true;
            this.cmbVehicleType.Location = new System.Drawing.Point(110, 75);
            this.cmbVehicleType.Name = "cmbVehicleType";
            this.cmbVehicleType.Size = new System.Drawing.Size(170, 21);
            this.cmbVehicleType.TabIndex = 2;
            this.cmbVehicleType.SelectedIndexChanged += new System.EventHandler(this.cmbVehicleType_SelectedIndexChanged);
            // 
            // lblVehicleType
            // 
            this.lblVehicleType.AutoSize = true;
            this.lblVehicleType.Location = new System.Drawing.Point(10, 78);
            this.lblVehicleType.Name = "lblVehicleType";
            this.lblVehicleType.Size = new System.Drawing.Size(74, 13);
            this.lblVehicleType.TabIndex = 1;
            this.lblVehicleType.Text = "Vehicle Type:";
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(110, 12);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(170, 20);
            this.txtEmployeeName.TabIndex = 1;
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(10, 15);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(87, 13);
            this.lblEmployee.TabIndex = 0;
            this.lblEmployee.Text = "Employee Name:";
            // 
            // todaysEntriesPanel
            // 
            this.todaysEntriesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.todaysEntriesPanel.Controls.Add(this.lsvTodayEntries);
            this.todaysEntriesPanel.Location = new System.Drawing.Point(320, 60);
            this.todaysEntriesPanel.Name = "todaysEntriesPanel";
            this.todaysEntriesPanel.Size = new System.Drawing.Size(455, 380);
            this.todaysEntriesPanel.TabIndex = 2;
            // 
            // lsvTodayEntries
            // 
            this.lsvTodayEntries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnTime,
            this.columnVehicle,
            this.columnEmployee,
            this.columnTotal,
            this.columnPaid,
            this.columnWashStatus});
            this.lsvTodayEntries.ContextMenuStrip = this.lsvContextMenu;
            this.lsvTodayEntries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvTodayEntries.FullRowSelect = true;
            this.lsvTodayEntries.GridLines = true;
            this.lsvTodayEntries.Location = new System.Drawing.Point(0, 0);
            this.lsvTodayEntries.Name = "lsvTodayEntries";
            this.lsvTodayEntries.Size = new System.Drawing.Size(453, 378);
            this.lsvTodayEntries.TabIndex = 0;
            this.lsvTodayEntries.UseCompatibleStateImageBehavior = false;
            this.lsvTodayEntries.View = System.Windows.Forms.View.Details;
            // 
            // columnTime
            // 
            this.columnTime.Text = "Time";
            this.columnTime.Width = 50;
            // 
            // columnVehicle
            // 
            this.columnVehicle.Text = "Vehicle";
            this.columnVehicle.Width = 80;
            // 
            // columnEmployee
            // 
            this.columnEmployee.Text = "Employee";
            this.columnEmployee.Width = 90;
            // 
            // columnTotal
            // 
            this.columnTotal.Text = "Total";
            this.columnTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnTotal.Width = 70;
            // 
            // columnPaid
            // 
            this.columnPaid.Text = "Paid";
            this.columnPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnPaid.Width = 50;
            // 
            // columnWashStatus
            // 
            this.columnWashStatus.Text = "Wash Status";
            this.columnWashStatus.Width = 85;
            // 
            // lsvContextMenu
            // 
            this.lsvContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.togglePaidStatusToolStripMenuItem,
            this.toggleWashStatusToolStripMenuItem});
            this.lsvContextMenu.Name = "lsvContextMenu";
            this.lsvContextMenu.Size = new System.Drawing.Size(181, 70);
            // 
            // togglePaidStatusToolStripMenuItem
            // 
            this.togglePaidStatusToolStripMenuItem.Name = "togglePaidStatusToolStripMenuItem";
            this.togglePaidStatusToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.togglePaidStatusToolStripMenuItem.Text = "Toggle Paid Status";
            this.togglePaidStatusToolStripMenuItem.Click += new System.EventHandler(this.TogglePaidStatus_Click);
            // 
            // toggleWashStatusToolStripMenuItem
            // 
            this.toggleWashStatusToolStripMenuItem.Name = "toggleWashStatusToolStripMenuItem";
            this.toggleWashStatusToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.toggleWashStatusToolStripMenuItem.Text = "Toggle Wash Status";
            this.toggleWashStatusToolStripMenuItem.Click += new System.EventHandler(this.ToggleWashStatus_Click);
            // 
            // dailySummaryPanel
            // 
            this.dailySummaryPanel.BackColor = System.Drawing.Color.White;
            this.dailySummaryPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dailySummaryPanel.Controls.Add(this.txtSummaryMostWashedVehicle);
            this.dailySummaryPanel.Controls.Add(this.lblSummaryMostWashedVehicle);
            this.dailySummaryPanel.Controls.Add(this.txtSummaryTotalWashes);
            this.dailySummaryPanel.Controls.Add(this.lblSummaryTotalWashes);
            this.dailySummaryPanel.Controls.Add(this.txtSummaryTotalEmpShare);
            this.dailySummaryPanel.Controls.Add(this.lblSummaryTotalEmpShare);
            this.dailySummaryPanel.Controls.Add(this.txtSummaryTotalOwnerShare);
            this.dailySummaryPanel.Controls.Add(this.lblSummaryTotalOwnerShare);
            this.dailySummaryPanel.Controls.Add(this.txtSummaryTotalRevenue);
            this.dailySummaryPanel.Controls.Add(this.lblSummaryTotalRevenue);
            this.dailySummaryPanel.Controls.Add(this.lblDailySummary);
            this.dailySummaryPanel.Location = new System.Drawing.Point(320, 450);
            this.dailySummaryPanel.Name = "dailySummaryPanel";
            this.dailySummaryPanel.Size = new System.Drawing.Size(455, 200);
            this.dailySummaryPanel.TabIndex = 3;
            // 
            // txtSummaryMostWashedVehicle
            // 
            this.txtSummaryMostWashedVehicle.BackColor = System.Drawing.Color.White;
            this.txtSummaryMostWashedVehicle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSummaryMostWashedVehicle.Location = new System.Drawing.Point(265, 160);
            this.txtSummaryMostWashedVehicle.Name = "txtSummaryMostWashedVehicle";
            this.txtSummaryMostWashedVehicle.ReadOnly = true;
            this.txtSummaryMostWashedVehicle.Size = new System.Drawing.Size(180, 20);
            this.txtSummaryMostWashedVehicle.TabIndex = 10;
            this.txtSummaryMostWashedVehicle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSummaryMostWashedVehicle
            // 
            this.lblSummaryMostWashedVehicle.AutoSize = true;
            this.lblSummaryMostWashedVehicle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSummaryMostWashedVehicle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblSummaryMostWashedVehicle.Location = new System.Drawing.Point(265, 140);
            this.lblSummaryMostWashedVehicle.Name = "lblSummaryMostWashedVehicle";
            this.lblSummaryMostWashedVehicle.Size = new System.Drawing.Size(134, 15);
            this.lblSummaryMostWashedVehicle.TabIndex = 9;
            this.lblSummaryMostWashedVehicle.Text = "Most Washed Vehicle:";
            // 
            // txtSummaryTotalWashes
            // 
            this.txtSummaryTotalWashes.BackColor = System.Drawing.Color.White;
            this.txtSummaryTotalWashes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSummaryTotalWashes.Location = new System.Drawing.Point(15, 160);
            this.txtSummaryTotalWashes.Name = "txtSummaryTotalWashes";
            this.txtSummaryTotalWashes.ReadOnly = true;
            this.txtSummaryTotalWashes.Size = new System.Drawing.Size(180, 20);
            this.txtSummaryTotalWashes.TabIndex = 8;
            this.txtSummaryTotalWashes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSummaryTotalWashes
            // 
            this.lblSummaryTotalWashes.AutoSize = true;
            this.lblSummaryTotalWashes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSummaryTotalWashes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblSummaryTotalWashes.Location = new System.Drawing.Point(15, 140);
            this.lblSummaryTotalWashes.Name = "lblSummaryTotalWashes";
            this.lblSummaryTotalWashes.Size = new System.Drawing.Size(83, 15);
            this.lblSummaryTotalWashes.TabIndex = 7;
            this.lblSummaryTotalWashes.Text = "Total Washes:";
            // 
            // txtSummaryTotalEmpShare
            // 
            this.txtSummaryTotalEmpShare.BackColor = System.Drawing.Color.White;
            this.txtSummaryTotalEmpShare.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSummaryTotalEmpShare.Location = new System.Drawing.Point(265, 110);
            this.txtSummaryTotalEmpShare.Name = "txtSummaryTotalEmpShare";
            this.txtSummaryTotalEmpShare.ReadOnly = true;
            this.txtSummaryTotalEmpShare.Size = new System.Drawing.Size(180, 20);
            this.txtSummaryTotalEmpShare.TabIndex = 6;
            this.txtSummaryTotalEmpShare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSummaryTotalEmpShare
            // 
            this.lblSummaryTotalEmpShare.AutoSize = true;
            this.lblSummaryTotalEmpShare.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSummaryTotalEmpShare.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblSummaryTotalEmpShare.Location = new System.Drawing.Point(265, 90);
            this.lblSummaryTotalEmpShare.Name = "lblSummaryTotalEmpShare";
            this.lblSummaryTotalEmpShare.Size = new System.Drawing.Size(127, 15);
            this.lblSummaryTotalEmpShare.TabIndex = 5;
            this.lblSummaryTotalEmpShare.Text = "Total Employee Share:";
            // 
            // txtSummaryTotalOwnerShare
            // 
            this.txtSummaryTotalOwnerShare.BackColor = System.Drawing.Color.White;
            this.txtSummaryTotalOwnerShare.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSummaryTotalOwnerShare.Location = new System.Drawing.Point(15, 110);
            this.txtSummaryTotalOwnerShare.Name = "txtSummaryTotalOwnerShare";
            this.txtSummaryTotalOwnerShare.ReadOnly = true;
            this.txtSummaryTotalOwnerShare.Size = new System.Drawing.Size(180, 20);
            this.txtSummaryTotalOwnerShare.TabIndex = 4;
            this.txtSummaryTotalOwnerShare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSummaryTotalOwnerShare
            // 
            this.lblSummaryTotalOwnerShare.AutoSize = true;
            this.lblSummaryTotalOwnerShare.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSummaryTotalOwnerShare.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblSummaryTotalOwnerShare.Location = new System.Drawing.Point(15, 90);
            this.lblSummaryTotalOwnerShare.Name = "lblSummaryTotalOwnerShare";
            this.lblSummaryTotalOwnerShare.Size = new System.Drawing.Size(114, 15);
            this.lblSummaryTotalOwnerShare.TabIndex = 3;
            this.lblSummaryTotalOwnerShare.Text = "Total Owner Share:";
            // 
            // txtSummaryTotalRevenue
            // 
            this.txtSummaryTotalRevenue.BackColor = System.Drawing.Color.White;
            this.txtSummaryTotalRevenue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSummaryTotalRevenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtSummaryTotalRevenue.Location = new System.Drawing.Point(15, 60);
            this.txtSummaryTotalRevenue.Name = "txtSummaryTotalRevenue";
            this.txtSummaryTotalRevenue.ReadOnly = true;
            this.txtSummaryTotalRevenue.Size = new System.Drawing.Size(180, 20);
            this.txtSummaryTotalRevenue.TabIndex = 2;
            this.txtSummaryTotalRevenue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSummaryTotalRevenue
            // 
            this.lblSummaryTotalRevenue.AutoSize = true;
            this.lblSummaryTotalRevenue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSummaryTotalRevenue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblSummaryTotalRevenue.Location = new System.Drawing.Point(15, 40);
            this.lblSummaryTotalRevenue.Name = "lblSummaryTotalRevenue";
            this.lblSummaryTotalRevenue.Size = new System.Drawing.Size(91, 15);
            this.lblSummaryTotalRevenue.TabIndex = 1;
            this.lblSummaryTotalRevenue.Text = "Total Revenue:";
            // 
            // lblDailySummary
            // 
            this.lblDailySummary.AutoSize = true;
            this.lblDailySummary.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDailySummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblDailySummary.Location = new System.Drawing.Point(15, 10);
            this.lblDailySummary.Name = "lblDailySummary";
            this.lblDailySummary.Size = new System.Drawing.Size(114, 20);
            this.lblDailySummary.TabIndex = 0;
            this.lblDailySummary.Text = "Daily Summary";
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 700);
            this.Controls.Add(this.dailySummaryPanel);
            this.Controls.Add(this.todaysEntriesPanel);
            this.Controls.Add(this.washEntryPanel);
            this.Controls.Add(this.headerPanel);
            this.Name = "DashboardForm";
            this.Text = "Car Wash Management - Daily Dashboard";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DashboardForm_FormClosed);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.washEntryPanel.ResumeLayout(false);
            this.washEntryPanel.PerformLayout();
            this.todaysEntriesPanel.ResumeLayout(false);
            this.lsvContextMenu.ResumeLayout(false);
            this.dailySummaryPanel.ResumeLayout(false);
            this.dailySummaryPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel headerPanel;
        private Label welcomeLabel;
        private Button logoutButton;
        private Button btnChangePassword;
        private MenuStrip mainMenu;
        private ToolStripMenuItem adminMenuItem;
        private ToolStripMenuItem manageUsersToolStripMenuItem;
        private ToolStripMenuItem manageVehiclesToolStripMenuItem;
        private ToolStripMenuItem manageServicesToolStripMenuItem;
        private ToolStripMenuItem manageExpensesToolStripMenuItem;
        private ToolStripMenuItem monthlyYearlyReportToolStripMenuItem;
        private Panel washEntryPanel;
        private TextBox txtEmployeeName;
        private Label lblEmployee;
        private ComboBox cmbVehicleType;
        private Label lblVehicleType;
        private TextBox txtBaseFee;
        private Label lblBaseFee;
        private TextBox txtEmployeeShare;
        private Label lblEmployeeShare;
        private TextBox txtOwnerShare;
        private Label lblOwnerShare;
        private Panel servicePanel;
        private Label lblAdditionalServices;
        private TextBox txtServiceEmpShare;
        private Label lblServiceEmpShare;
        private TextBox txtServiceOwnerShare;
        private Label lblServiceOwnerShare;
        private TextBox txtTotalServiceFee;
        private Label lblTotalServiceFee;
        private CheckBox chkIsPaid;
        private CheckBox chkWashStatus;
        private ComboBox cmbDiscount;
        private Label lblDiscount;
        private TextBox txtTotalAmount;
        private Label lblTotalAmount;
        private Button btnAddTransaction;
        private Panel todaysEntriesPanel;
        private ListView lsvTodayEntries;
        private ColumnHeader columnTime;
        private ColumnHeader columnVehicle;
        private ColumnHeader columnEmployee;
        private ColumnHeader columnTotal;
        private ColumnHeader columnPaid;
        private ColumnHeader columnWashStatus;
        private ContextMenuStrip lsvContextMenu;
        private ToolStripMenuItem togglePaidStatusToolStripMenuItem;
        private ToolStripMenuItem toggleWashStatusToolStripMenuItem;
        private Panel dailySummaryPanel;
        private TextBox txtSummaryMostWashedVehicle;
        private Label lblSummaryMostWashedVehicle;
        private TextBox txtSummaryTotalWashes;
        private Label lblSummaryTotalWashes;
        private TextBox txtSummaryTotalEmpShare;
        private Label lblSummaryTotalEmpShare;
        private TextBox txtSummaryTotalOwnerShare;
        private Label lblSummaryTotalOwnerShare;
        private TextBox txtSummaryTotalRevenue;
        private Label lblSummaryTotalRevenue;
        private Label lblDailySummary;
    }
}