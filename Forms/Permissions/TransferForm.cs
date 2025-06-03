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
    public partial class TransferForm : Form
    {
        private readonly WarehouseContext _context;
        // Collection of permissionItems to be added to the permission
        private List<PermissionItem> _permItems;
        // Current transfer permission being edited or created
        private TransferPermission _currPerm;

        public TransferForm(WarehouseContext context)
        {
            InitializeComponent();
            _context = context;
            _permItems = new List<PermissionItem>();
            _currPerm = new TransferPermission();
            _currPerm.Permission.PermissionItems = _permItems;

            cbSrcWh.DisplayMember = "WarehouseName";
            cbSrcWh.ValueMember = "WarehouseID";
            cbSrcWh.DataSource = _context.Warehouses.ToList();
            cbSrcWh.SelectedIndex = -1; // No selection by default

            // Set date pickers to today's date and restrict future dates
            PermDate.MaxDate = DateTime.Today.Date;
            ProdDate.MaxDate = DateTime.Today.Date;
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = _context.TransferPermissions
                                                   .Select(sp => new
                                                   {
                                                       sp.PermissionNumber,
                                                       sp.Permission.PermissionDate,
                                                       SrcWh = sp.Permission.MainWarehouse.WarehouseName,
                                                       DestWh = sp.DestWarehouse.WarehouseName,
                                                   })
                                                   .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying transfer permissions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbSrcWh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSrcWh.SelectedIndex != -1)
            {
                int srcWarehouseId = (int)cbSrcWh.SelectedValue;
                // Load items from the selected source warehouse
                var itemsInSrcWarehouse = _context.InventoryItems
                                                  .Where(ii => ii.WarehouseID == srcWarehouseId)
                                                  .Select(ii => new { ii.ItemCode, ii.Item.ItemName })
                                                  .Distinct()
                                                  .ToList();

                cbItem.DisplayMember = "ItemName";
                cbItem.ValueMember = "ItemCode";
                cbItem.DataSource = itemsInSrcWarehouse;
                cbItem.SelectedIndex = -1; // No selection by default

                // Load other warehouses for destination selection
                var otherWarehouses = _context.Warehouses
                                               .Where(w => w.WarehouseID != srcWarehouseId)
                                               .ToList();
                cbDestWh.DataSource = otherWarehouses;
                cbDestWh.DisplayMember = "WarehouseName";
                cbDestWh.ValueMember = "WarehouseID";
                cbDestWh.SelectedIndex = -1; // No selection by default
            }
            else
            {
                cbItem.DataSource = null;
                cbDestWh.DataSource = null;
            }
        }

        private void btnAddPermission_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input fields
                if (string.IsNullOrEmpty(tbPermNum.Text) || cbSrcWh.SelectedIndex < 0 || cbDestWh.SelectedIndex < 0)
                {
                    MessageBox.Show("Please fill in all fields correctly.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Update permission
                _currPerm.Permission.PermissionNumber = tbPermNum.Text;
                _currPerm.Permission.PermissionDate = PermDate.Value.Date;
                _currPerm.Permission.MainWarehouseID = (int)cbSrcWh.SelectedValue;

                // Update transfer permission
                _currPerm.PermissionNumber = tbPermNum.Text;
                _currPerm.DestWarehouseID = (int)cbDestWh.SelectedValue;

                // Add the permission to the context
                _context.TransferPermissions.Add(_currPerm);
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
                cbSrcWh.SelectedValue = _context.TransferPermissions
                                                    .Where(sp => sp.PermissionNumber == permissionNumber)
                                                    .Select(sp => sp.Permission.MainWarehouseID)
                                                    .FirstOrDefault();
                cbDestWh.SelectedValue = _context.TransferPermissions
                                                    .Where(sp => sp.PermissionNumber == permissionNumber)
                                                    .Select(sp => sp.DestWarehouseID)
                                                    .FirstOrDefault();
            }
            else
            {
                dataGridView2.DataSource = null; // Clear the items grid if no selection
                tbPermNum.Clear();
                PermDate.Value = DateTime.Today.Date; // Reset to today's date
                cbSrcWh.SelectedIndex = -1; // Reset source warehouse selection
                cbDestWh.SelectedIndex = -1; // Reset destination warehouse selection
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a transfer permission.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(tbPermNum.Text) || cbItem.SelectedIndex < 0 ||
                    !int.TryParse(tbQuantity.Text, out int quantity) || quantity <= 0)
                {
                    MessageBox.Show("Please fill in all fields correctly.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string itemCode = cbItem.SelectedValue.ToString();
                int srcWhId = (int)cbSrcWh.SelectedValue;
                int destWhId = (int)cbDestWh.SelectedValue;
                DateTime selectedProdDate = ProdDate.Value.Date;
                DateTime selectedExpDate = expDate.Value.Date;
                int expiryDuration = (int)(selectedExpDate - selectedProdDate).TotalDays;

                var batch = _context.InventoryItems.FirstOrDefault(ii =>
                    ii.ItemCode == itemCode &&
                    ii.WarehouseID == srcWhId &&
                    ii.ProductionDate == selectedProdDate &&
                    ii.ExpiryDate == selectedExpDate);

                if (batch == null || batch.Quantity < quantity)
                {
                    MessageBox.Show("Selected batch is not available or has insufficient quantity.", "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Reduce from source batch
                batch.Quantity -= quantity;

                // Add to destination batch
                var destBatch = _context.InventoryItems.FirstOrDefault(ii =>
                    ii.ItemCode == itemCode &&
                    ii.WarehouseID == destWhId &&
                    ii.ProductionDate == selectedProdDate &&
                    ii.ExpiryDate == selectedExpDate);

                if (destBatch != null)
                {
                    destBatch.Quantity += quantity;
                }
                else
                {
                    destBatch = new InventoryItem
                    {
                        ItemCode = itemCode,
                        WarehouseID = destWhId,
                        ProductionDate = selectedProdDate,
                        ExpiryDate = selectedExpDate,
                        Quantity = quantity
                    };
                    _context.InventoryItems.Add(destBatch);
                }

                // Add permission item
                _context.PermissionItems.Add(new PermissionItem
                {
                    PermissionNumber = tbPermNum.Text,
                    ItemCode = itemCode,
                    Quantity = quantity,
                    ProductionDate = selectedProdDate,
                    ExpiryDuration = expiryDuration
                });

                _context.SaveChanges();

                dataGridView2.DataSource = _context.PermissionItems
                    .Where(pi => pi.PermissionNumber == tbPermNum.Text)
                    .Select(pi => new
                    {
                        ID = pi.PermItemID,
                        pi.ItemCode,
                        pi.ProductionDate,
                        pi.ExpiryDuration,
                        pi.Quantity
                    }).ToList();

                MessageBox.Show("Item transferred successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an item to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(tbQuantity.Text, out int newQuantity) || newQuantity <= 0)
                {
                    MessageBox.Show("Enter a valid quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedRow = dataGridView2.SelectedRows[0];
                int permItemID = (int)selectedRow.Cells["ID"].Value;
                var existingItem = _context.PermissionItems.FirstOrDefault(pi => pi.PermItemID == permItemID);
                if (existingItem == null)
                {
                    MessageBox.Show("Selected item not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string itemCode = cbItem.SelectedValue.ToString();
                int srcWhId = (int)cbSrcWh.SelectedValue;
                int destWhId = (int)cbDestWh.SelectedValue;
                string permissionNumber = existingItem.PermissionNumber;
                DateTime selectedProdDate = existingItem.ProductionDate.Value;
                DateTime expectedExpDate = selectedProdDate.AddDays(existingItem.ExpiryDuration);

                var destBatch = _context.InventoryItems.FirstOrDefault(ii =>
                    ii.WarehouseID == destWhId &&
                    ii.ItemCode == itemCode &&
                    ii.ProductionDate == selectedProdDate &&
                    ii.ExpiryDate == expectedExpDate);

                if (destBatch == null || destBatch.Quantity < existingItem.Quantity)
                {
                    MessageBox.Show("Cannot restore quantity from destination warehouse.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Restore to source
                destBatch.Quantity -= existingItem.Quantity;
                var srcBatch = _context.InventoryItems.FirstOrDefault(ii =>
                    ii.WarehouseID == srcWhId &&
                    ii.ItemCode == itemCode &&
                    ii.ProductionDate == selectedProdDate &&
                    ii.ExpiryDate == expectedExpDate);

                if (srcBatch == null)
                {
                    srcBatch = new InventoryItem
                    {
                        WarehouseID = srcWhId,
                        ItemCode = itemCode,
                        ProductionDate = selectedProdDate,
                        ExpiryDate = expectedExpDate,
                        Quantity = 0
                    };
                    _context.InventoryItems.Add(srcBatch);
                }
                srcBatch.Quantity += existingItem.Quantity;

                _context.InventoryItems.Update(destBatch);
                _context.InventoryItems.Update(srcBatch);
                _context.SaveChanges();

                // Remove old permission item
                _context.PermissionItems.Remove(existingItem);
                _context.SaveChanges();

                // Reapply new quantity
                if (srcBatch.Quantity < newQuantity)
                {
                    MessageBox.Show("Not enough quantity in selected batch to apply the update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                srcBatch.Quantity -= newQuantity;
                destBatch.Quantity += newQuantity;

                _context.PermissionItems.Add(new PermissionItem
                {
                    PermissionNumber = permissionNumber,
                    ItemCode = itemCode,
                    Quantity = newQuantity,
                    ProductionDate = selectedProdDate,
                    ExpiryDuration = existingItem.ExpiryDuration
                });

                _context.SaveChanges();

                dataGridView2.DataSource = _context.PermissionItems
                    .Where(pi => pi.PermissionNumber == permissionNumber)
                    .Select(pi => new
                    {
                        ID = pi.PermItemID,
                        pi.ItemCode,
                        pi.ProductionDate,
                        pi.ExpiryDuration,
                        pi.Quantity
                    }).ToList();

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
                if (dataGridView2.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an item to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedRow = dataGridView2.SelectedRows[0];
                int permItemID = (int)selectedRow.Cells["ID"].Value;
                var existingItem = _context.PermissionItems.FirstOrDefault(pi => pi.PermItemID == permItemID);
                if (existingItem == null)
                {
                    MessageBox.Show("Selected item not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string itemCode = existingItem.ItemCode;
                int srcWhId = (int)cbSrcWh.SelectedValue;
                int destWhId = (int)cbDestWh.SelectedValue;
                DateTime selectedProdDate = existingItem.ProductionDate.Value;
                DateTime expectedExpDate = selectedProdDate.AddDays(existingItem.ExpiryDuration);

                // Restore quantity to source warehouse
                var srcBatch = _context.InventoryItems.FirstOrDefault(ii =>
                    ii.WarehouseID == srcWhId &&
                    ii.ItemCode == itemCode &&
                    ii.ProductionDate == selectedProdDate &&
                    ii.ExpiryDate == expectedExpDate);
                if (srcBatch == null)
                {
                    srcBatch = new InventoryItem
                    {
                        WarehouseID = srcWhId,
                        ItemCode = itemCode,
                        ProductionDate = selectedProdDate,
                        ExpiryDate = expectedExpDate,
                        Quantity = existingItem.Quantity
                    };
                    _context.InventoryItems.Add(srcBatch);
                }
                else
                {
                    srcBatch.Quantity += existingItem.Quantity;
                    _context.InventoryItems.Update(srcBatch);
                }

                // Reduce quantity from destination warehouse
                var destBatch = _context.InventoryItems.FirstOrDefault(ii =>
                    ii.WarehouseID == destWhId &&
                    ii.ItemCode == itemCode &&
                    ii.ProductionDate == selectedProdDate &&
                    ii.ExpiryDate == expectedExpDate);
                if (destBatch != null)
                {
                    destBatch.Quantity -= existingItem.Quantity;
                    if (destBatch.Quantity <= 0)
                        _context.InventoryItems.Remove(destBatch);
                    else
                        _context.InventoryItems.Update(destBatch);
                }

                _context.InventoryItems.Update(srcBatch);
                _context.PermissionItems.Remove(existingItem);
                _context.SaveChanges();

                dataGridView2.DataSource = _context.PermissionItems
                    .Where(pi => pi.PermissionNumber == tbPermNum.Text)
                    .Select(pi => new
                    {
                        ID = pi.PermItemID,
                        pi.ItemCode,
                        pi.ProductionDate,
                        pi.ExpiryDuration,
                        pi.Quantity
                    }).ToList();
                MessageBox.Show("Item deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdatePermission_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if a permission is selected
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a transfer permission to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedRow = dataGridView1.SelectedRows[0];
                // Get the permission number from the selected row
                var permissionNumber = selectedRow.Cells["PermissionNumber"].Value.ToString();
                _currPerm = _context.TransferPermissions
                                    .Include(sp => sp.Permission)
                                    .Include(sp => sp.Permission.PermissionItems)
                                    .FirstOrDefault(sp => sp.PermissionNumber == permissionNumber);
                if (_currPerm == null)
                {
                    MessageBox.Show("Selected transfer permission not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update the current supply permission with new values if provided
                _currPerm.Permission.PermissionDate = PermDate.Value.Date;
                // update source and destination warehouses only if there are no permission items associated with the permission
                if (_currPerm.Permission.PermissionItems.Count == 0)
                {
                    _currPerm.Permission.MainWarehouseID = (int)cbSrcWh.SelectedValue;
                    _currPerm.DestWarehouseID = (int)cbDestWh.SelectedValue;
                }

                _context.TransferPermissions.Update(_currPerm);
                _context.SaveChanges();
                // Refresh the DataGridView to reflect changes
                btnDisplay_Click(sender, e);
                MessageBox.Show("Transfer permission updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating transfer permission: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
