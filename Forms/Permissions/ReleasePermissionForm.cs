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
    public partial class ReleasePermissionForm : Form
    {
        private readonly WarehouseContext _context;
        // Collection of permissionItems to be added to the permission
        private List<PermissionItem> _permItems;
        // Current release permission being edited or created
        private ReleasePermission _currPerm;

        public ReleasePermissionForm(WarehouseContext context)
        {
            InitializeComponent();
            _context = context;
            _permItems = new List<PermissionItem>();
            _currPerm = new ReleasePermission();
            _currPerm.Permission.PermissionItems = _permItems;

            cbWarehouse.DataSource = _context.Warehouses.ToList();
            cbWarehouse.DisplayMember = "WarehouseName";
            cbWarehouse.ValueMember = "WarehouseID";
            cbWarehouse.SelectedIndex = -1; // No selection by default

            cbCustomer.DataSource = _context.BusinessPartners
                                            .Where(bp => bp.Type == PartnerType.Customer)
                                            .ToList();
            cbCustomer.DisplayMember = "Name";
            cbCustomer.ValueMember = "PartnerID";
            cbCustomer.SelectedIndex = -1; // No selection by default

            // Set date pickers to today's date and restrict future dates
            PermDate.MaxDate = DateTime.Today.Date;
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = _context.ReleasePermissions
                                                   .Select(sp => new
                                                   {
                                                       sp.PermissionNumber,
                                                       sp.Permission.PermissionDate,
                                                       Warehouse = sp.Permission.MainWarehouse.WarehouseName,
                                                       Customer = sp.Customer.Name,
                                                   })
                                                   .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying release permissions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbWarehouse.SelectedIndex >= 0)
            {
                int selectedWarehouseId = (int)cbWarehouse.SelectedValue;

                // Filter items based on selected warehouse
                var itemsInWarehouse = _context.InventoryItems
                                               .Where(ii => ii.WarehouseID == selectedWarehouseId)
                                               .Select(ii => new { ii.ItemCode, ii.Item.ItemName })
                                               .Distinct()
                                               .ToList();

                cbItem.DataSource = itemsInWarehouse;
                cbItem.DisplayMember = "ItemName";
                cbItem.ValueMember = "ItemCode";
                cbItem.SelectedIndex = -1; // No selection by default
            }
            else
            {
                cbItem.DataSource = null;
            }
        }

        private void btnAddPermission_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input fields
                if (string.IsNullOrEmpty(tbPermNum.Text) || cbWarehouse.SelectedIndex < 0 || cbCustomer.SelectedIndex < 0)
                {
                    MessageBox.Show("Please fill in all fields correctly.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Update permission
                _currPerm.Permission.PermissionNumber = tbPermNum.Text;
                _currPerm.Permission.PermissionDate = PermDate.Value.Date;
                _currPerm.Permission.MainWarehouseID = (int)cbWarehouse.SelectedValue;

                // Update release permission
                _currPerm.PermissionNumber = tbPermNum.Text;
                _currPerm.CustomerID = (int)cbCustomer.SelectedValue;

                // Add the permission to the context
                _context.ReleasePermissions.Add(_currPerm);
                _context.SaveChanges();
                // Refresh the DataGridView
                btnDisplay_Click(sender, e);
                MessageBox.Show("Release permission added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding release permission: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdatePermission_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if a permission is selected
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a release permission to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedRow = dataGridView1.SelectedRows[0];
                // Get the permission number from the selected row
                var permissionNumber = selectedRow.Cells["PermissionNumber"].Value.ToString();
                _currPerm = _context.ReleasePermissions
                                    .Include(sp => sp.Permission)
                                    .Include(sp => sp.Permission.PermissionItems)
                                    .FirstOrDefault(sp => sp.PermissionNumber == permissionNumber);
                if (_currPerm == null)
                {
                    MessageBox.Show("Selected release permission not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update the current supply permission with new values if provided
                _currPerm.Permission.PermissionDate = PermDate.Value.Date;
                if (cbCustomer.SelectedIndex >= 0)
                    _currPerm.CustomerID = (int)cbCustomer.SelectedValue;

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

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if a permission is selected
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a release permission to add items.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate input fields
                if (string.IsNullOrEmpty(tbPermNum.Text) || cbItem.SelectedIndex < 0 || int.Parse(tbQuantity.Text) <= 0)
                {
                    MessageBox.Show("Please fill in all fields correctly.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Decrease the quantity in the inventory of the selected warehouse
                var selectedRow = dataGridView1.SelectedRows[0];
                var permissionNumber = selectedRow.Cells["PermissionNumber"].Value.ToString();
                var selectedWarehouseId = (int)cbWarehouse.SelectedValue;
                var itemCode = cbItem.SelectedValue.ToString();
                var releaseQuantity = int.Parse(tbQuantity.Text);
                var remainingQty = releaseQuantity;

                // Check if the item exists in the selected warehouse and has enough quantity
                var inventoryItems = _context.InventoryItems
                                             .Where(ii => ii.WarehouseID == selectedWarehouseId &&
                                                          ii.ItemCode == itemCode &&
                                                          ii.Quantity > 0)
                                             .OrderBy(ii => ii.ExpiryDate)
                                             .ToList();

                List<PermissionItem> itemsToAdd = new();

                foreach (var inv in inventoryItems)
                {
                    if (remainingQty == 0) break;

                    int takeQty = Math.Min(inv.Quantity, remainingQty);
                    remainingQty -= takeQty;

                    inv.Quantity -= takeQty;

                    itemsToAdd.Add(new PermissionItem
                    {
                        PermissionNumber = permissionNumber,
                        ItemCode = inv.ItemCode,
                        Quantity = takeQty,
                        ProductionDate = inv.ProductionDate.Value,
                        ExpiryDuration = (inv.ExpiryDate.Value - inv.ProductionDate.Value).Days
                    });

                    if (inv.Quantity == 0)
                        _context.InventoryItems.Remove(inv);
                }

                if (remainingQty > 0)
                {
                    MessageBox.Show("Insufficient quantity for the selected item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _context.PermissionItems.AddRange(itemsToAdd);

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
                cbWarehouse.SelectedValue = _context.ReleasePermissions
                                                    .Where(sp => sp.PermissionNumber == permissionNumber)
                                                    .Select(sp => sp.Permission.MainWarehouseID)
                                                    .FirstOrDefault();
                cbCustomer.SelectedValue = _context.ReleasePermissions
                                                    .Where(sp => sp.PermissionNumber == permissionNumber)
                                                    .Select(sp => sp.CustomerID)
                                                    .FirstOrDefault();
            }
            else
            {
                dataGridView2.DataSource = null; // Clear the items grid if no selection
                tbPermNum.Clear();
                PermDate.Value = DateTime.Today.Date; // Reset to today's date
                cbWarehouse.SelectedIndex = -1; // Reset warehouse selection
                cbCustomer.SelectedIndex = -1; // Reset supplier selection
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView2.SelectedRows[0];
                // Retrieve the selected permission item
                var permItemId = (int)selectedRow.Cells["ID"].Value;
                // Find the permission item in the context
                var permItem = _context.PermissionItems.Find(permItemId);
                if (permItem != null)
                {
                    cbItem.SelectedValue = permItem.ItemCode;
                    tbQuantity.Text = permItem.Quantity.ToString();
                }
            }
            else
            {
                cbItem.SelectedIndex = -1; // Reset item selection
                tbQuantity.Clear(); // Clear quantity textbox
            }
        }

        private void btnUpdateItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if an item is selected
                if (dataGridView2.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an item to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbItem.SelectedIndex < 0 || int.Parse(tbQuantity.Text) <= 0)
                {
                    MessageBox.Show("Please fill in item and quantity correctly.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedItemRow = dataGridView2.SelectedRows[0];
                var permItemID = (int)selectedItemRow.Cells["ID"].Value;

                // Find the existing permission item
                var existingItem = _context.PermissionItems.FirstOrDefault(pi => pi.PermItemID == permItemID);
                if (existingItem == null)
                {
                    MessageBox.Show("Selected item not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var selectedWarehouseId = (int)cbWarehouse.SelectedValue;
                var itemCode = cbItem.SelectedValue.ToString();
                var newQuantity = int.Parse(tbQuantity.Text);
                var permissionNumber = existingItem.PermissionNumber;

                // Step 1: Restore quantity back to inventory from the old item
                var matchingInventory = _context.InventoryItems.FirstOrDefault(ii =>
                                                                ii.WarehouseID == selectedWarehouseId &&
                                                                ii.ItemCode == existingItem.ItemCode &&
                                                                ii.ProductionDate == existingItem.ProductionDate);

                if (matchingInventory != null)
                {
                    matchingInventory.Quantity += existingItem.Quantity;
                }
                else
                {
                    // If no matching inventory item, recreate it
                    _context.InventoryItems.Add(new InventoryItem
                    {
                        WarehouseID = selectedWarehouseId,
                        ItemCode = existingItem.ItemCode,
                        ProductionDate = existingItem.ProductionDate,
                        ExpiryDate = existingItem.ProductionDate?.AddDays(existingItem.ExpiryDuration),
                        Quantity = existingItem.Quantity
                    });
                }

                // Step 2: Remove the old permission item
                _context.PermissionItems.Remove(existingItem);
                _context.SaveChanges(); // So inventory is restored and item is gone

                // Step 3: Re-attempt to add the item with the new quantity
                int remainingQty = newQuantity;
                var inventoryItems = _context.InventoryItems
                    .Where(ii => ii.WarehouseID == selectedWarehouseId &&
                                 ii.ItemCode == itemCode &&
                                 ii.Quantity > 0)
                    .OrderBy(ii => ii.ExpiryDate)
                    .ToList();

                List<PermissionItem> updatedItems = new();

                foreach (var inv in inventoryItems)
                {
                    if (remainingQty == 0) break;

                    int takeQty = Math.Min(inv.Quantity, remainingQty);
                    remainingQty -= takeQty;
                    inv.Quantity -= takeQty;

                    updatedItems.Add(new PermissionItem
                    {
                        PermissionNumber = permissionNumber,
                        ItemCode = inv.ItemCode,
                        Quantity = takeQty,
                        ProductionDate = inv.ProductionDate.Value,
                        ExpiryDuration = (inv.ExpiryDate.Value - inv.ProductionDate.Value).Days
                    });

                    if (inv.Quantity == 0)
                        _context.InventoryItems.Remove(inv);
                }

                if (remainingQty > 0)
                {
                    MessageBox.Show("Insufficient quantity for the updated item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _context.PermissionItems.AddRange(updatedItems);
                _context.SaveChanges();

                // Refresh the DataGridView
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

                MessageBox.Show("Item updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                var selectedRow = dataGridView2.SelectedRows[0];
                var permItemID = (int)selectedRow.Cells["ID"].Value;

                // Get the permission item to delete
                var permissionItem = _context.PermissionItems.FirstOrDefault(pi => pi.PermItemID == permItemID);
                if (permissionItem == null)
                {
                    MessageBox.Show("Selected item not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var warehouseId = (int)cbWarehouse.SelectedValue;
                var itemCode = permissionItem.ItemCode;

                // Restore quantity to inventory
                var matchingInventory = _context.InventoryItems.FirstOrDefault(ii =>
                    ii.WarehouseID == warehouseId &&
                    ii.ItemCode == itemCode &&
                    ii.ProductionDate == permissionItem.ProductionDate);

                if (matchingInventory != null)
                {
                    matchingInventory.Quantity += permissionItem.Quantity;
                }
                else
                {
                    // Recreate inventory item if not found
                    _context.InventoryItems.Add(new InventoryItem
                    {
                        WarehouseID = warehouseId,
                        ItemCode = itemCode,
                        ProductionDate = permissionItem.ProductionDate,
                        ExpiryDate = permissionItem.ProductionDate?.AddDays(permissionItem.ExpiryDuration),
                        Quantity = permissionItem.Quantity
                    });
                }

                // Remove the permission item
                _context.PermissionItems.Remove(permissionItem);
                _context.SaveChanges();

                // Refresh the DataGridView
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

                MessageBox.Show("Item deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
