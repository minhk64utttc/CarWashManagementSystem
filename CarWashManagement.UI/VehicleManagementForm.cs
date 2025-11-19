using CarWashManagement.Core;
using CarWashManagement.Core.Managers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace CarWashManagement.UI
{
    // Form that allows admin to manage vehicle types and their pricing.
    public partial class VehicleManagementForm : BaseForm
    {
        private readonly CarManager carManager;
        private readonly User loggedInUser;

        public VehicleManagementForm(User loggedInUser, CarManager carManager)
        {
            this.loggedInUser = loggedInUser;
            this.carManager = carManager;

            InitializeComponent();
            LoadVehicleList();
        }

        // Method to load all the vehicles from the vehicles.txt file into the ListView.
        private void LoadVehicleList()
        {
            lsvVehicles.Items.Clear();

            List<Vehicle> vehicles = carManager.GetVehicleTypes();

            foreach (Vehicle vehicle in vehicles)
            {
                ListViewItem row = new ListViewItem(vehicle.Type);
                row.SubItems.Add(vehicle.BaseFee.ToString("C", CultureInfo.GetCultureInfo("en-PH")));
                row.SubItems.Add(vehicle.OwnerShare.ToString("C", CultureInfo.GetCultureInfo("en-PH")));
                row.SubItems.Add(vehicle.EmployeeShare.ToString("C", CultureInfo.GetCultureInfo("en-PH")));

                // Store the type in the tag property of each rows.
                // This is use to know which vehicle type to perform an operation to.
                row.Tag = vehicle.Type;
                lsvVehicles.Items.Add(row);
            }
            ClearForm();
        }

        // Method to clear the form fields and reset the button states.
        private void ClearForm()
        {
            lsvVehicles.SelectedItems.Clear();
            txtType.Clear();
            txtBaseFee.Clear();
            txtOwnerShare.Clear();
            txtEmployeeShare.Clear();

            txtType.ReadOnly = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        // Method to validate input fields before adding or updating a vehicle.
        private bool ValidateInput(out Vehicle vehicle)
        {
            vehicle = null;

            if (string.IsNullOrWhiteSpace(txtType.Text) ||
               string.IsNullOrWhiteSpace(txtBaseFee.Text) ||
               string.IsNullOrWhiteSpace(txtOwnerShare.Text) ||
               string.IsNullOrWhiteSpace(txtEmployeeShare.Text))
            {
                MessageBox.Show("All fields are required", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtBaseFee.Text, out decimal baseFee) || baseFee <= 0 ||
                !decimal.TryParse(txtOwnerShare.Text, out decimal ownerShare) || ownerShare < 0 ||
                !decimal.TryParse(txtEmployeeShare.Text, out decimal employeeShare) || employeeShare <= 0)
            {
                MessageBox.Show("Fees and shares must be valid positive numbers.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (baseFee != (ownerShare + employeeShare))
            {
                MessageBox.Show("The sum of Owner Share and Employee Share must equal the Base Fee.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            vehicle = new Vehicle
            {
                Type = txtType.Text.Trim(),
                BaseFee = baseFee,
                OwnerShare = ownerShare,
                EmployeeShare = employeeShare
            };
            return true;
        }

        // Event handler when the selected item in the vehicle ListView is changed.
        private void lsvVehicles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvVehicles.SelectedItems.Count == 0)
            {
                ClearForm();
                return;
            }

            ListViewItem selectedRow = lsvVehicles.SelectedItems[0];
            string vehicleType = selectedRow.Tag as string;
            Vehicle vehicle = carManager.GetVehicleByType(vehicleType);

            if (vehicle != null)
            {
                txtType.Text = vehicle.Type;
                txtBaseFee.Text = vehicle.BaseFee.ToString("N2");
                txtOwnerShare.Text = vehicle.OwnerShare.ToString("N2");
                txtEmployeeShare.Text = vehicle.EmployeeShare.ToString("N2");

                txtType.ReadOnly = true; // Vehicle type should not be changed when updating.
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
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
            if (!ValidateInput(out Vehicle newVehicle))
            {
                return; // Validation failed.
            }

            bool success = carManager.AddVehicle(newVehicle, loggedInUser.Username);

            if (success)
            {
                MessageBox.Show("Vehicle added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadVehicleList();
            }
            else
            {
                MessageBox.Show("A vehicle with this type already exists.", "Creation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler when the Update Button is clicked.
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out Vehicle updatedVehicle))
            {
                return; // Validation failed.
            }

            carManager.UpdateVehicle(updatedVehicle, loggedInUser.Username);
            MessageBox.Show("Vehicle updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadVehicleList();
        }

        // Event handler when the Delete Button is clicked.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string vehicleType = txtType.Text;
            DialogResult result = MessageBox.Show($"Are you sure you want to delete '{vehicleType}'? This action cannot be undone.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                carManager.DeleteVehicle(vehicleType, loggedInUser.Username);
                MessageBox.Show("Vehicle deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadVehicleList();
            }
        }
    }
}