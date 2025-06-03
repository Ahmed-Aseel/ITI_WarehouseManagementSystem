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
    public partial class ItemForm : Form
    {
        private readonly WarehouseContext _context;

        public ItemForm(WarehouseContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                var items = _context.Items
                                    .Select(i => new
                                    {
                                        i.ItemCode,
                                        i.ItemName,
                                        i.UnitOfMeasurement
                                    })
                                    .ToList();
                dataGridView1.DataSource = items;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tbCode.Text) ||
                    string.IsNullOrWhiteSpace(tbName.Text) ||
                    string.IsNullOrWhiteSpace(tbUnit.Text))
                {
                    MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var item = new Item()
                {
                    ItemCode = tbCode.Text,
                    ItemName = tbName.Text,
                    UnitOfMeasurement = tbUnit.Text
                };

                _context.Items.Add(item);
                _context.SaveChanges();
                tbCode.Text = tbName.Text = tbUnit.Text = string.Empty; // Clear input fields
                btnDisplay_Click(sender, e); // Refresh the display
                MessageBox.Show("Item added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate input fields
                if (string.IsNullOrWhiteSpace(tbName.Text) &&
                    string.IsNullOrWhiteSpace(tbUnit.Text))
                {
                    MessageBox.Show("Please fill in any field to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedRow = dataGridView1.SelectedRows[0];
                var itemCode = selectedRow.Cells["ItemCode"].Value.ToString();

                var item = _context.Items.FirstOrDefault(i => i.ItemCode == itemCode);
                if (item == null)
                {
                    MessageBox.Show("Item not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update only the fields that are not empty
                if (!string.IsNullOrWhiteSpace(tbName.Text))
                    item.ItemName = tbName.Text;
                if (!string.IsNullOrWhiteSpace(tbUnit.Text))
                    item.UnitOfMeasurement = tbUnit.Text;
                // Save changes to the database
                _context.SaveChanges();
                tbCode.Text = tbName.Text = tbUnit.Text = string.Empty; // Clear input fields
                btnDisplay_Click(sender, e); // Refresh the display
                MessageBox.Show("Item updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                tbCode.Text = selectedRow.Cells["ItemCode"].Value.ToString();
                tbName.Text = selectedRow.Cells["ItemName"].Value.ToString();
                tbUnit.Text = selectedRow.Cells["UnitOfMeasurement"].Value.ToString();
                tbCode.ReadOnly = true; // Make ItemCode read-only when an item is selected
                btnAdd.Enabled = false; // Disable Add button when an item is selected
            }
            else
            {
                tbCode.Text = tbName.Text = tbUnit.Text = string.Empty; // Clear input fields if no selection
                tbCode.ReadOnly = false; // Allow editing of ItemCode when no selection
                btnAdd.Enabled = true; // Enable Add button when no item is selected
            }
        }
    }
}
