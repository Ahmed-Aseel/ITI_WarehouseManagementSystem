using Microsoft.EntityFrameworkCore;
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
using WarehouseManagementSystem.Data.Entities.Inventory;
using WarehouseManagementSystem.Data.Entities.Permissions;

namespace WarehouseManagementSystem.Forms.Permissions
{
    public partial class SupplyPermissionForm : Form
    {
        private readonly WarehouseContext _context;
        // Collection of permissionItems to be added to the permission
        private List<PermissionItem> _permItems;
        // Current supply permission being edited or created
        private SupplyPermission _currPerm;

        public SupplyPermissionForm(WarehouseContext context)
        {
            InitializeComponent();
            _context = context;
            _permItems = new List<PermissionItem>();
            _currPerm = new SupplyPermission();
            _currPerm.Permission.PermissionItems = _permItems;

            cbWarehouse.DataSource = _context.Warehouses.ToList();
            cbWarehouse.DisplayMember = "WarehouseName";
            cbWarehouse.ValueMember = "WarehouseID";
            cbWarehouse.SelectedIndex = -1; // No selection by default

            cbSupplier.DataSource = _context.BusinessPartners
                                            .Where(bp => bp.Type == PartnerType.Supplier)
                                            .ToList();
            cbSupplier.DisplayMember = "Name";
            cbSupplier.ValueMember = "PartnerID";
            cbSupplier.SelectedIndex = -1; // No selection by default

            cbItem.DataSource = _context.Items.ToList();
            cbItem.DisplayMember = "ItemName";
            cbItem.ValueMember = "ItemCode";
            cbItem.SelectedIndex = -1; // No selection by default

            // Set date pickers to today's date and restrict future dates
            PermDate.MaxDate = DateTime.Today.Date;
            ProdDate.MaxDate = DateTime.Today.Date;
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = _context.SupplyPermissions
                                                   .Select(sp => new
                                                   {
                                                       sp.PermissionNumber,
                                                       sp.Permission.PermissionDate,
                                                       Warehouse = sp.Permission.MainWarehouse.WarehouseName,
                                                       Supplier = sp.Supplier.Name,
                                                   })
                                                   .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying supply permissions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                // Retrieve the selected supply permission
                var permissionNumber = selectedRow.Cells["PermissionNumber"].Value.ToString();

                dataGridView2.DataSource = _context.PermissionItems
                                                   .Where(pi => pi.PermissionNumber == permissionNumber)
                                                   .Select(pi => new
                                                   {
                                                       ID = pi.PermItemID,
                                                       pi.ItemCode,
                                                       pi.ProductionDate,
                                                       pi.ExpiryDuration,
                                                       pi.Quantity
                                                   })
                                                   .ToList();
                // Populate the permission number and date fields
                tbPermNum.Text = permissionNumber;
                PermDate.Value = (DateTime)selectedRow.Cells["PermissionDate"].Value;
                cbWarehouse.SelectedValue = _context.SupplyPermissions
                                                    .Where(sp => sp.PermissionNumber == permissionNumber)
                                                    .Select(sp => sp.Permission.MainWarehouseID)
                                                    .FirstOrDefault();
                cbSupplier.SelectedValue = _context.SupplyPermissions
                                                    .Where(sp => sp.PermissionNumber == permissionNumber)
                                                    .Select(sp => sp.SupplierID)
                                                    .FirstOrDefault();
            }
            else
            {
                dataGridView2.DataSource = null; // Clear the items grid if no selection
                tbPermNum.Clear();
                PermDate.Value = DateTime.Today.Date; // Reset to today's date
                cbWarehouse.SelectedIndex = -1; // Reset warehouse selection
                cbSupplier.SelectedIndex = -1; // Reset supplier selection
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if a permission is selected
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a supply permission to add items.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate input fields
                if (string.IsNullOrEmpty(tbPermNum.Text) || cbItem.SelectedIndex < 0 || int.Parse(tbQuantity.Text) <= 0 || int.Parse(tbExpDuration.Text) <= 0)
                {
                    MessageBox.Show("Please fill in all fields correctly.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Add the item to the permission items list
                var permissionItem = new PermissionItem
                {
                    PermissionNumber = tbPermNum.Text,
                    ItemCode = cbItem.SelectedValue.ToString(),
                    Quantity = int.Parse(tbQuantity.Text),
                    ProductionDate = ProdDate.Value.Date,
                    ExpiryDuration = int.Parse(tbExpDuration.Text)
                };
                _context.PermissionItems.Add(permissionItem);

                // Create new inventory item
                var inventoryItem = new InventoryItem
                {
                    WarehouseID = (int)cbWarehouse.SelectedValue,
                    ItemCode = permissionItem.ItemCode,
                    ProductionDate = permissionItem.ProductionDate,
                    ExpiryDate = permissionItem.ProductionDate.Value.AddDays(permissionItem.ExpiryDuration),
                    Quantity = permissionItem.Quantity
                };
                _context.InventoryItems.Add(inventoryItem);

                _context.SaveChanges();

                // Update the DataGridView to show the added item
                dataGridView2.DataSource = _context.PermissionItems
                                                   .Where(pi => pi.PermissionNumber == tbPermNum.Text)
                                                   .Select(pi => new
                                                   {
                                                       ID = pi.PermItemID,
                                                       pi.ItemCode,
                                                       pi.ProductionDate,
                                                       pi.ExpiryDuration,
                                                       pi.Quantity
                                                   })
                                                   .ToList();

                MessageBox.Show($"Item added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddPermission_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input fields
                if (string.IsNullOrEmpty(tbPermNum.Text) || cbWarehouse.SelectedIndex < 0 || cbSupplier.SelectedIndex < 0)
                {
                    MessageBox.Show("Please fill in all fields correctly.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Update permission
                _currPerm.Permission.PermissionNumber = tbPermNum.Text;
                _currPerm.Permission.PermissionDate = PermDate.Value.Date;
                _currPerm.Permission.MainWarehouseID = (int)cbWarehouse.SelectedValue;

                // Update supply permission
                _currPerm.PermissionNumber = tbPermNum.Text;
                _currPerm.SupplierID = (int)cbSupplier.SelectedValue;

                // Add the permission to the context
                _context.SupplyPermissions.Add(_currPerm);
                _context.SaveChanges();
                // Refresh the DataGridView
                btnDisplay_Click(sender, e);
                MessageBox.Show("Supply permission added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding supply permission: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdatePermission_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if a permission is selected
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a supply permission to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedRow = dataGridView1.SelectedRows[0];
                // Get the permission number from the selected row
                var permissionNumber = selectedRow.Cells["PermissionNumber"].Value.ToString();
                _currPerm = _context.SupplyPermissions
                                    .Include(sp => sp.Permission)
                                    .Include(sp => sp.Permission.PermissionItems)
                                    .FirstOrDefault(sp => sp.PermissionNumber == permissionNumber);
                if (_currPerm == null)
                {
                    MessageBox.Show("Selected supply permission not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update the current supply permission with new values if provided
                _currPerm.Permission.PermissionDate = PermDate.Value.Date;
                if (cbSupplier.SelectedIndex >= 0)
                    _currPerm.SupplierID = (int)cbSupplier.SelectedValue;

                int oldWarehouseId = _currPerm.Permission.MainWarehouseID;
                int newWarehouseId = (int)cbWarehouse.SelectedValue;

                // Only proceed if warehouse has changed
                if (oldWarehouseId != newWarehouseId)
                {
                    foreach (var item in _currPerm.Permission.PermissionItems)
                    {
                        var expectedExpiry = item.ProductionDate.Value.AddDays(item.ExpiryDuration);

                        // 1. Decrease old warehouse inventory
                        var oldInv = _context.InventoryItems.FirstOrDefault(ii =>
                                                                ii.WarehouseID == oldWarehouseId &&
                                                                ii.ItemCode == item.ItemCode &&
                                                                ii.ProductionDate == item.ProductionDate &&
                                                                ii.ExpiryDate == expectedExpiry
                                                            );

                        if (oldInv != null)
                        {
                            // Check if the old inventory quantity is sufficient
                            if (oldInv.Quantity < item.Quantity)
                            {
                                MessageBox.Show("Inventory inconsistency detected. Cannot update permission.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            oldInv.Quantity -= item.Quantity;
                            if (oldInv.Quantity == 0)
                                _context.InventoryItems.Remove(oldInv); // Remove if quantity is zero
                        }

                        // 2. Increase or add to new warehouse inventory
                        var newInv = _context.InventoryItems.Local.FirstOrDefault(ii =>
                                                                ii.WarehouseID == newWarehouseId &&
                                                                ii.ItemCode == item.ItemCode &&
                                                                ii.ProductionDate == item.ProductionDate &&
                                                                ii.ExpiryDate == expectedExpiry
                                                            );

                        if (newInv != null)
                        {
                            newInv.Quantity += item.Quantity;
                        }
                        else
                        {
                            newInv = new InventoryItem
                            {
                                WarehouseID = newWarehouseId,
                                ItemCode = item.ItemCode,
                                ProductionDate = item.ProductionDate,
                                ExpiryDate = expectedExpiry,
                                Quantity = item.Quantity
                            };
                            _context.InventoryItems.Add(newInv);
                        }
                    }

                    // Finally, update the permission's warehouse ID
                    _currPerm.Permission.MainWarehouseID = newWarehouseId;
                }

                _context.SaveChanges();
                // Refresh the DataGridView
                btnDisplay_Click(sender, e);
                MessageBox.Show("Supply permission updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating supply permission: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView2.SelectedRows[0];
                // Retrieve the selected permission item
                var itemCode = selectedRow.Cells["ItemCode"].Value.ToString();
                var productionDate = (DateTime)selectedRow.Cells["ProductionDate"].Value;
                var expiryDuration = (int)selectedRow.Cells["ExpiryDuration"].Value;
                var quantity = (int)selectedRow.Cells["Quantity"].Value;
                // Populate the input fields with the selected item's details
                cbItem.SelectedValue = itemCode;
                ProdDate.Value = productionDate;
                tbQuantity.Text = quantity.ToString();
                tbExpDuration.Text = expiryDuration.ToString();
            }
            else
            {
                // Clear the input fields if no selection
                cbItem.SelectedIndex = -1;
                ProdDate.Value = DateTime.Today.Date; // Reset to today's date
                tbQuantity.Clear();
                tbExpDuration.Clear();
            }
        }

        private void btnUpdateItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if an item is selected
                if (dataGridView2.SelectedRows.Count == 0 )
                {
                    MessageBox.Show("Please select an item to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get the selected permission item
                var selectedRow = dataGridView2.SelectedRows[0];
                var permItemID = (int)selectedRow.Cells["ID"].Value;

                // Update the permission item
                var oldPermItem = _context.PermissionItems.FirstOrDefault(pi => pi.PermItemID == permItemID);
                if (oldPermItem != null)
                {
                    // 2. Calculate old expiry date
                    var oldExpiryDate = oldPermItem.ProductionDate.Value.AddDays(oldPermItem.ExpiryDuration);

                    var oldInv = _context.InventoryItems.FirstOrDefault(ii =>
                                                                ii.WarehouseID == (int)cbWarehouse.SelectedValue &&
                                                                ii.ItemCode == oldPermItem.ItemCode &&
                                                                ii.ProductionDate == oldPermItem.ProductionDate &&
                                                                ii.ExpiryDate == oldExpiryDate
                                                            );
                    if (oldInv != null)
                    {
                        // Check if the old inventory quantity is sufficient
                        if (oldInv.Quantity < oldPermItem.Quantity)
                        {
                            MessageBox.Show("Inventory inconsistency detected. Cannot update item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Decrease the old inventory quantity
                        oldInv.Quantity -= oldPermItem.Quantity;
                        if (oldInv.Quantity == 0)
                            _context.InventoryItems.Remove(oldInv); // Remove if quantity is zero
                    }

                    // 5. Calculate new expiry date
                    var newExpiryDate = ProdDate.Value.AddDays(int.Parse(tbExpDuration.Text));

                    var newInv = _context.InventoryItems.Local.FirstOrDefault(ii =>
                                                                ii.WarehouseID == (int)cbWarehouse.SelectedValue &&
                                                                ii.ItemCode == cbItem.SelectedValue.ToString() &&
                                                                ii.ProductionDate == ProdDate.Value &&
                                                                ii.ExpiryDate == newExpiryDate
                                                            );
                    if (newInv != null)
                    {
                        // Increase the existing inventory item quantity
                        newInv.Quantity += int.Parse(tbQuantity.Text);
                    }
                    else
                    {
                        // Create a new inventory item if it doesn't exist
                        newInv = new InventoryItem
                        {
                            WarehouseID = (int)cbWarehouse.SelectedValue,
                            ItemCode = cbItem.SelectedValue.ToString(),
                            ProductionDate = ProdDate.Value,
                            ExpiryDate = newExpiryDate,
                            Quantity = int.Parse(tbQuantity.Text)
                        };
                        _context.InventoryItems.Add(newInv);
                    }

                    // Update the permission item details
                    oldPermItem.ItemCode = cbItem.SelectedValue.ToString();
                    oldPermItem.ProductionDate = ProdDate.Value.Date;
                    oldPermItem.ExpiryDuration = int.Parse(tbExpDuration.Text);
                    oldPermItem.Quantity = int.Parse(tbQuantity.Text);
                    // Save changes to the context
                    _context.SaveChanges();
                    // Update the DataGridView to show updated items
                    dataGridView1_SelectionChanged(sender, e);

                    MessageBox.Show("Item updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if an item is selected
                if (dataGridView2.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an item to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get the selected permission item
                var selectedRow = dataGridView2.SelectedRows[0];
                var permItemID = (int)selectedRow.Cells["ID"].Value;

                // Find and remove the item from the permission items list
                var permItem = _context.PermissionItems.FirstOrDefault(pi => pi.PermItemID == permItemID);
                if (permItem != null)
                {
                    var itemCode = selectedRow.Cells["ItemCode"].Value.ToString();
                    var productionDate = (DateTime)selectedRow.Cells["ProductionDate"].Value;
                    var expiryDuration = (int)selectedRow.Cells["ExpiryDuration"].Value;
                    var expiryDate = productionDate.AddDays(expiryDuration);

                    var invItem = _context.InventoryItems.FirstOrDefault(ii =>
                                                                ii.WarehouseID == (int)cbWarehouse.SelectedValue &&
                                                                ii.ItemCode == itemCode &&
                                                                ii.ProductionDate == productionDate &&
                                                                ii.ExpiryDate == expiryDate
                                                            );
                    if (invItem != null)
                    {
                        // Check if the inventory item quantity is sufficient
                        if (invItem.Quantity < permItem.Quantity)
                        {
                            MessageBox.Show("Inventory inconsistency detected. Cannot delete item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Decrease the quantity from inventory
                        invItem.Quantity -= permItem.Quantity;
                        if (invItem.Quantity == 0)
                            _context.InventoryItems.Remove(invItem); // Remove if quantity is zero
                    }

                    _context.PermissionItems.Remove(permItem);
                    // Save changes to the context
                    _context.SaveChanges();
                    // Refresh the DataGridView to show updated items
                    dataGridView1_SelectionChanged(sender, e);
                    MessageBox.Show("Item deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
