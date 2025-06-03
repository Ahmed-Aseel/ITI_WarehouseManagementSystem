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
using WarehouseManagementSystem.Data.Entities.Permissions;

namespace WarehouseManagementSystem.Forms.Reports
{
    public partial class InactiveItemsReportForm : Form
    {
        // Helper class to show warehouse names in CheckedListBox
        public class WarehouseDisplay
        {
            public int WarehouseID { get; set; }
            public string WarehouseName { get; set; }
            public override string ToString() => WarehouseName;
        }

        private readonly WarehouseContext _context;

        public InactiveItemsReportForm(WarehouseContext context)
        {
            InitializeComponent();
            _context = context;

            var warehouses = _context.Warehouses
                         .Select(w => new { w.WarehouseID, w.WarehouseName })
                         .ToList();

            clbWarehouses.Items.Clear();
            foreach (var wh in warehouses)
            {
                clbWarehouses.Items.Add(new WarehouseDisplay { WarehouseID = wh.WarehouseID, WarehouseName = wh.WarehouseName }, false);
            }

        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtDays.Text, out int days) || days <= 0)
                {
                    MessageBox.Show("Please enter a valid number of days.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedWarehouseIds = clbWarehouses.CheckedItems
                    .Cast<WarehouseDisplay>()
                    .Select(w => w.WarehouseID)
                    .ToList();

                if (!selectedWarehouseIds.Any())
                {
                    MessageBox.Show("Please select at least one warehouse.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var cutoffDate = DateTime.Now.Date.AddDays(-days);

                // 1. Get items that currently exist in the selected warehouses
                var currentInventory = _context.InventoryItems
                    .Include(ii => ii.Item)
                    .Where(ii => selectedWarehouseIds.Contains(ii.WarehouseID) && ii.Quantity > 0)
                    .ToList();

                // 2. Get items that had any movement in those warehouses since cutoffDate
                var recentMovements = _context.PermissionItems
                    .Include(pi => pi.Permission)
                    .Where(pi =>
                        (selectedWarehouseIds.Contains(pi.Permission.MainWarehouseID) ||
                         (pi.Permission.Type == PermissionType.Transfer &&
                          selectedWarehouseIds.Contains(pi.Permission.TransferPermission.DestWarehouseID))) &&
                        pi.Permission.PermissionDate > cutoffDate)
                    .Select(pi => new { pi.ItemCode, pi.Permission.MainWarehouseID })
                    .Distinct()
                    .ToList();

                // 3. Filter out items that had recent movements
                var inactiveItems = currentInventory
                    .Where(ii => !recentMovements.Any(rm => rm.ItemCode == ii.ItemCode && rm.MainWarehouseID == ii.WarehouseID))
                    .Select(ii => new
                    {
                        ii.Item.ItemCode,
                        ii.Item.ItemName,
                        Warehouse = _context.Warehouses
                                            .Where(w => w.WarehouseID == ii.WarehouseID)
                                            .Select(w => w.WarehouseName)
                                            .FirstOrDefault(),
                        ProductionDate = ii.ProductionDate.Value,
                        ExpiryDate = ii.ExpiryDate.Value,
                        ii.Quantity
                    })
                    .OrderBy(i => i.ItemName)
                    .ToList();

                dataGridView1.DataSource = inactiveItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
