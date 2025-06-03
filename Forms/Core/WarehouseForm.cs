using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseManagementSystem.Data.Contexts;
using WarehouseManagementSystem.Data.Entities.Core;

namespace WarehouseManagementSystem.Forms.Core
{
    public partial class WarehouseForm : Form
    {
        private readonly WarehouseContext _context;

        public WarehouseForm(WarehouseContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                var warehouses = _context.Warehouses
                                         .Select(w => new
                                         {
                                             w.WarehouseID,
                                             w.WarehouseName,
                                             w.Location,
                                             w.ManagerName
                                         })
                                         .ToList();

                dataGridView1.DataSource = warehouses;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying warehouses: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input fields
                if (string.IsNullOrWhiteSpace(tbWhName.Text) ||
                    string.IsNullOrWhiteSpace(tbWhLoc.Text) ||
                    string.IsNullOrWhiteSpace(tbMgrName.Text))
                {
                    MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var warehouse = new Warehouse()
                {
                    WarehouseName = tbWhName.Text,
                    Location = tbWhLoc.Text,
                    ManagerName = tbMgrName.Text
                };

                _context.Warehouses.Add(warehouse);
                // Save changes to the database
                _context.SaveChanges();
                // Clear the input fields after adding
                tbWhName.Text = tbWhLoc.Text = tbMgrName.Text = string.Empty;
                btnDisplay_Click(sender, e); // Refresh the display
                MessageBox.Show("Warehouse added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding warehouse: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if there is a selected row in the DataGridView
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a warehouse to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate input fields
                if (string.IsNullOrWhiteSpace(tbWhName.Text) &&
                    string.IsNullOrWhiteSpace(tbWhLoc.Text) &&
                    string.IsNullOrWhiteSpace(tbMgrName.Text))
                {
                    MessageBox.Show("Please fill in any field to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get the selected warehouse ID from the DataGridView
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                int warehouseId = (int)dataGridView1.Rows[selectedRowIndex].Cells["WarehouseID"].Value;

                // Retrieve the warehouse from the context
                var warehouse = _context.Warehouses.FirstOrDefault(w => w.WarehouseID == warehouseId);
                if (warehouse == null)
                {
                    MessageBox.Show("Selected warehouse not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update the warehouse properties only if the text boxes are not empty
                if (!string.IsNullOrWhiteSpace(tbWhName.Text))
                    warehouse.WarehouseName = tbWhName.Text;

                if (!string.IsNullOrWhiteSpace(tbWhLoc.Text))
                    warehouse.Location = tbWhLoc.Text;

                if (!string.IsNullOrWhiteSpace(tbMgrName.Text))
                    warehouse.ManagerName = tbMgrName.Text;

                _context.SaveChanges();
                // Clear the input fields after updating
                tbWhName.Text = tbWhLoc.Text = tbMgrName.Text = string.Empty;
                btnDisplay_Click(sender, e); // Refresh the display
                MessageBox.Show("Warehouse updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating warehouse: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // Check if there is a selected row in the DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected row index
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                // Populate the text boxes with the selected warehouse data
                tbWhName.Text = dataGridView1.Rows[selectedRowIndex].Cells["WarehouseName"].Value.ToString();
                tbWhLoc.Text = dataGridView1.Rows[selectedRowIndex].Cells["Location"].Value.ToString();
                tbMgrName.Text = dataGridView1.Rows[selectedRowIndex].Cells["ManagerName"].Value.ToString();
                btnAdd.Enabled = false; // Disable Add button when a row is selected
            }
            else
            {
                // Clear the text boxes if no row is selected
                tbWhName.Text = tbWhLoc.Text = tbMgrName.Text = string.Empty;
                btnAdd.Enabled = true; // Enable Add button when no row is selected
            }
        }
    }
}
