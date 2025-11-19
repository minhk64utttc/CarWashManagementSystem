using System.Drawing;
using System.Windows.Forms;

namespace CarWashManagement.UI
{
    partial class VehicleManagementForm
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
            this.lsvVehicles = new System.Windows.Forms.ListView();
            this.columnVehicleType = new System.Windows.Forms.ColumnHeader();
            this.columnBaseFee = new System.Windows.Forms.ColumnHeader();
            this.columnOwnerShare = new System.Windows.Forms.ColumnHeader();
            this.columnEmployeeShare = new System.Windows.Forms.ColumnHeader();
            this.lblType = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.lblBaseFee = new System.Windows.Forms.Label();
            this.txtBaseFee = new System.Windows.Forms.TextBox();
            this.lblOwnerShare = new System.Windows.Forms.Label();
            this.txtOwnerShare = new System.Windows.Forms.TextBox();
            this.lblEmployeeShare = new System.Windows.Forms.Label();
            this.txtEmployeeShare = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lsvVehicles
            // 
            this.lsvVehicles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnVehicleType,
            this.columnBaseFee,
            this.columnOwnerShare,
            this.columnEmployeeShare});
            this.lsvVehicles.FullRowSelect = true;
            this.lsvVehicles.GridLines = true;
            this.lsvVehicles.Location = new System.Drawing.Point(15, 15);
            this.lsvVehicles.Name = "lsvVehicles";
            this.lsvVehicles.Size = new System.Drawing.Size(550, 200);
            this.lsvVehicles.TabIndex = 0;
            this.lsvVehicles.UseCompatibleStateImageBehavior = false;
            this.lsvVehicles.View = System.Windows.Forms.View.Details;
            this.lsvVehicles.SelectedIndexChanged += new System.EventHandler(this.lsvVehicles_SelectedIndexChanged);
            // 
            // columnVehicleType
            // 
            this.columnVehicleType.Text = "Vehicle Type";
            this.columnVehicleType.Width = 150;
            // 
            // columnBaseFee
            // 
            this.columnBaseFee.Text = "Base Fee";
            this.columnBaseFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnBaseFee.Width = 120;
            // 
            // columnOwnerShare
            // 
            this.columnOwnerShare.Text = "Owner Share";
            this.columnOwnerShare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnOwnerShare.Width = 120;
            // 
            // columnEmployeeShare
            // 
            this.columnEmployeeShare.Text = "Employee Share";
            this.columnEmployeeShare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnEmployeeShare.Width = 120;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(15, 240);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(72, 13);
            this.lblType.TabIndex = 1;
            this.lblType.Text = "Vehicle Type:";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(120, 237);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(120, 20);
            this.txtType.TabIndex = 1;
            // 
            // lblBaseFee
            // 
            this.lblBaseFee.AutoSize = true;
            this.lblBaseFee.Location = new System.Drawing.Point(15, 275);
            this.lblBaseFee.Name = "lblBaseFee";
            this.lblBaseFee.Size = new System.Drawing.Size(55, 13);
            this.lblBaseFee.TabIndex = 3;
            this.lblBaseFee.Text = "Base Fee:";
            // 
            // txtBaseFee
            // 
            this.txtBaseFee.Location = new System.Drawing.Point(120, 272);
            this.txtBaseFee.Name = "txtBaseFee";
            this.txtBaseFee.Size = new System.Drawing.Size(150, 20);
            this.txtBaseFee.TabIndex = 2;
            // 
            // lblOwnerShare
            // 
            this.lblOwnerShare.AutoSize = true;
            this.lblOwnerShare.Location = new System.Drawing.Point(15, 310);
            this.lblOwnerShare.Name = "lblOwnerShare";
            this.lblOwnerShare.Size = new System.Drawing.Size(73, 13);
            this.lblOwnerShare.TabIndex = 5;
            this.lblOwnerShare.Text = "Owner Share:";
            // 
            // txtOwnerShare
            // 
            this.txtOwnerShare.Location = new System.Drawing.Point(120, 307);
            this.txtOwnerShare.Name = "txtOwnerShare";
            this.txtOwnerShare.Size = new System.Drawing.Size(150, 20);
            this.txtOwnerShare.TabIndex = 3;
            // 
            // lblEmployeeShare
            // 
            this.lblEmployeeShare.AutoSize = true;
            this.lblEmployeeShare.Location = new System.Drawing.Point(15, 345);
            this.lblEmployeeShare.Name = "lblEmployeeShare";
            this.lblEmployeeShare.Size = new System.Drawing.Size(90, 13);
            this.lblEmployeeShare.TabIndex = 7;
            this.lblEmployeeShare.Text = "Employee Share:";
            // 
            // txtEmployeeShare
            // 
            this.txtEmployeeShare.Location = new System.Drawing.Point(120, 342);
            this.txtEmployeeShare.Name = "txtEmployeeShare";
            this.txtEmployeeShare.Size = new System.Drawing.Size(150, 20);
            this.txtEmployeeShare.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(300, 237);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 30);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add New";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnUpdate.Enabled = false;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(435, 237);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(120, 30);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update Selected";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(435, 317);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 30);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete Selected";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(300, 277);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 30);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear Form";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // VehicleManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtEmployeeShare);
            this.Controls.Add(this.lblEmployeeShare);
            this.Controls.Add(this.txtOwnerShare);
            this.Controls.Add(this.lblOwnerShare);
            this.Controls.Add(this.txtBaseFee);
            this.Controls.Add(this.lblBaseFee);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lsvVehicles);
            this.Name = "VehicleManagementForm";
            this.Text = "Vehicle Management";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView lsvVehicles;
        private ColumnHeader columnVehicleType;
        private ColumnHeader columnBaseFee;
        private ColumnHeader columnOwnerShare;
        private ColumnHeader columnEmployeeShare;
        private Label lblType;
        private TextBox txtType;
        private Label lblBaseFee;
        private TextBox txtBaseFee;
        private Label lblOwnerShare;
        private TextBox txtOwnerShare;
        private Label lblEmployeeShare;
        private TextBox txtEmployeeShare;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
    }
}