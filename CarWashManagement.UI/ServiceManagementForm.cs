using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CarWashManagement.Core;
using CarWashManagement.Core.Managers;
using CarWashManagement.Core.Enums;

namespace CarWashManagement.UI
{
    public partial class ServiceManagementForm : BaseForm
    {
        private readonly CarManager carManager;
        private readonly User loggedInUser;

        public ServiceManagementForm(User loggedInUser, CarManager carManager)
        {
            this.loggedInUser = loggedInUser;
            this.carManager = carManager;

            InitializeComponent();
            LoadServiceList();
            InitializePricingTypeComboBox();
        }

        // Initialize the pricing type combo box with enum values
        private void InitializePricingTypeComboBox()
        {
            cmbPricingType.Items.Clear();
            cmbPricingType.Items.Add(ServicePricingType.FixedPrice);
            cmbPricingType.Items.Add(ServicePricingType.ManualInput);
            cmbPricingType.Items.Add(ServicePricingType.VehicleBaseFeeMultiplier);
            cmbPricingType.SelectedIndex = 0;
        }

        // Method to load services into the ListView.
        private void LoadServiceList()
        {
            lsvServices.Items.Clear();

            List<Service> services = carManager.GetServices();

            foreach (Service service in services)
            {
                ListViewItem row = new ListViewItem(service.Name);
                row.SubItems.Add(service.PricingType.ToString());
                row.SubItems.Add(service.PricingType == ServicePricingType.FixedPrice ? service.Fee.ToString("N2") : "N/A");
                row.SubItems.Add(service.PricingType == ServicePricingType.VehicleBaseFeeMultiplier ? service.Multiplier.ToString() : "N/A");
                row.Tag = service.Name;
                lsvServices.Items.Add(row);
            }
            ClearForm();
        }

        // Method to clear input fields in the form and set the default status of the buttons.
        private void ClearForm()
        {
            lsvServices.SelectedItems.Clear();
            txtName.Clear();
            cmbPricingType.SelectedIndex = 0;
            txtFee.Text = "0.00";
            txtMultiplier.Text = "1";

            txtName.ReadOnly = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            UpdateFieldVisibility();
        }

        // Method to show/hide Fee or Multiplier fields based on PricingType.
        private void UpdateFieldVisibility()
        {
            if (cmbPricingType.SelectedItem == null) return;

            ServicePricingType selectedType = (ServicePricingType)cmbPricingType.SelectedItem;

            lblFee.Visible = (selectedType == ServicePricingType.FixedPrice);
            txtFee.Visible = (selectedType == ServicePricingType.FixedPrice);

            lblMultiplier.Visible = (selectedType == ServicePricingType.VehicleBaseFeeMultiplier);
            txtMultiplier.Visible = (selectedType == ServicePricingType.VehicleBaseFeeMultiplier);
        }

        // Method to validate inputs in the textboxes before creating/updating the new service object.
        private bool ValidateInput(out Service service)
        {
            service = null;
            string name = txtName.Text.Trim();

            if (cmbPricingType.SelectedItem == null)
            {
                MessageBox.Show("Please select a pricing type.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            ServicePricingType type = (ServicePricingType)cmbPricingType.SelectedItem;
            decimal fee = 0m;
            int multiplier = 1;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Service Name is required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (type == ServicePricingType.FixedPrice)
            {
                if (!decimal.TryParse(txtFee.Text, out fee) || fee <= 0)
                {
                    MessageBox.Show("Fee must be a valid number greater than 0.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else if (type == ServicePricingType.VehicleBaseFeeMultiplier)
            {
                if (!int.TryParse(txtMultiplier.Text, out multiplier) || multiplier <= 0)
                {
                    MessageBox.Show("Multiplier must be a valid integer greater than 0.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            service = new Service
            {
                Name = name,
                PricingType = type,
                Fee = fee,
                Multiplier = multiplier
            };
            return true;
        }

        // Event handler when the user selects a pricing type in the ComboBox.
        private void cmbPricingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFieldVisibility();
        }

        // Event handler when the user selects a new item in the ListView.
        private void lsvServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Unselects an item in the ListView.
            if (lsvServices.SelectedItems.Count == 0)
            {
                ClearForm();
                return;
            }

            ListViewItem selectedRow = lsvServices.SelectedItems[0];
            string serviceName = selectedRow.Tag as string;
            Service service = carManager.GetServiceByName(serviceName);

            if (service != null)
            {
                txtName.Text = service.Name;
                cmbPricingType.SelectedItem = service.PricingType;
                txtFee.Text = service.Fee.ToString("N2");
                txtMultiplier.Text = service.Multiplier.ToString();

                txtName.ReadOnly = true; // Cannot change the service name when editing.
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;

                UpdateFieldVisibility(); // Show correct fields.
            }
        }

        // Event handler when the Clear Button is clicked.
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        // Event handler when the Add Button is clicked.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out Service newService))
            {
                return; // Invalid inputs.
            }
            ;

            bool success = carManager.AddService(newService, loggedInUser.Username);

            if (success)
            {
                MessageBox.Show("Service added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadServiceList();
            }
            else
            {
                MessageBox.Show("A service with this name already exists.", "Creation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler when the Update Button is clicked.
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out Service updatedService))
            {
                return; // Invalid inputs.
            }

            carManager.UpdateService(updatedService, loggedInUser.Username);
            MessageBox.Show("Service updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadServiceList();
        }

        // Event handler when the Delete Button is clicked.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string serviceName = txtName.Text;
            var result = MessageBox.Show($"Are you sure you want to delete '{serviceName}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                carManager.DeleteService(serviceName, loggedInUser.Username);
                MessageBox.Show("Service deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadServiceList();
            }
        }
    }
}