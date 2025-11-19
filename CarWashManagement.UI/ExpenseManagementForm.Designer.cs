using System.Drawing;
using System.Windows.Forms;

namespace CarWashManagement.UI
{
    partial class ExpenseManagementForm
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
            this.lsvExpenses = new System.Windows.Forms.ListView();
            this.columnDate = new System.Windows.Forms.ColumnHeader();
            this.columnDescription = new System.Windows.Forms.ColumnHeader();
            this.columnAmount = new System.Windows.Forms.ColumnHeader();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpExpenseDate = new System.Windows.Forms.DateTimePicker();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnAddExpense = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lsvExpenses
            // 
            this.lsvExpenses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnDate,
            this.columnDescription,
            this.columnAmount});
            this.lsvExpenses.FullRowSelect = true;
            this.lsvExpenses.GridLines = true;
            this.lsvExpenses.Location = new System.Drawing.Point(15, 15);
            this.lsvExpenses.Name = "lsvExpenses";
            this.lsvExpenses.Size = new System.Drawing.Size(450, 200);
            this.lsvExpenses.TabIndex = 0;
            this.lsvExpenses.UseCompatibleStateImageBehavior = false;
            this.lsvExpenses.View = System.Windows.Forms.View.Details;
            // 
            // columnDate
            // 
            this.columnDate.Text = "Date";
            this.columnDate.Width = 100;
            // 
            // columnDescription
            // 
            this.columnDescription.Text = "Description";
            this.columnDescription.Width = 230;
            // 
            // columnAmount
            // 
            this.columnAmount.Text = "Amount";
            this.columnAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnAmount.Width = 100;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(15, 230);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(33, 13);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Date:";
            // 
            // dtpExpenseDate
            // 
            this.dtpExpenseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpenseDate.Location = new System.Drawing.Point(15, 250);
            this.dtpExpenseDate.Name = "dtpExpenseDate";
            this.dtpExpenseDate.Size = new System.Drawing.Size(200, 20);
            this.dtpExpenseDate.TabIndex = 1;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(15, 280);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(15, 300);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(300, 20);
            this.txtDescription.TabIndex = 2;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(330, 230);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(46, 13);
            this.lblAmount.TabIndex = 5;
            this.lblAmount.Text = "Amount:";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(330, 250);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(135, 20);
            this.txtAmount.TabIndex = 3;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnAddExpense
            // 
            this.btnAddExpense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnAddExpense.FlatAppearance.BorderSize = 0;
            this.btnAddExpense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddExpense.ForeColor = System.Drawing.Color.White;
            this.btnAddExpense.Location = new System.Drawing.Point(330, 300);
            this.btnAddExpense.Name = "btnAddExpense";
            this.btnAddExpense.Size = new System.Drawing.Size(135, 30);
            this.btnAddExpense.TabIndex = 4;
            this.btnAddExpense.Text = "Add Expense";
            this.btnAddExpense.UseVisualStyleBackColor = false;
            this.btnAddExpense.Click += new System.EventHandler(this.btnAddExpense_Click);
            // 
            // ExpenseManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.btnAddExpense);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.dtpExpenseDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lsvExpenses);
            this.Name = "ExpenseManagementForm";
            this.Text = "Expense Management";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView lsvExpenses;
        private ColumnHeader columnDate;
        private ColumnHeader columnDescription;
        private ColumnHeader columnAmount;
        private Label lblDate;
        private DateTimePicker dtpExpenseDate;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblAmount;
        private TextBox txtAmount;
        private Button btnAddExpense;
    }
}