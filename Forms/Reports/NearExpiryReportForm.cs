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

namespace WarehouseManagementSystem.Forms.Reports
{
    public partial class NearExpiryReportForm : Form
    {
        // Helper class to show warehouse names in CheckedListBox
        public class WarehouseDisplay
        {
            public int WarehouseID { get; set; }
            public string WarehouseName { get; set; }
            public override string ToString() => WarehouseName;
        }

        private readonly WarehouseContext _context;
        public NearExpiryReportForm(WarehouseContext context)
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
                var selectedWarehouseIds = clbWarehouses.CheckedItems
                    .Cast<WarehouseDisplay>()
                    .Select(w => w.WarehouseID)
                    .ToList();

                if (!selectedWarehouseIds.Any())
                {
                    MessageBox.Show("Please select at least one warehouse.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int daysThreshold = int.Parse(txtDays.Text);
                DateTime today = DateTime.Today;
                DateTime thresholdDate = today.AddDays(daysThreshold);

                var nearExpiryItems = _context.InventoryItems
                    .Where(ii => selectedWarehouseIds.Contains(ii.WarehouseID) &&
                                 ii.ExpiryDate.HasValue &&
                                 ii.ExpiryDate.Value > today &&
                                 ii.ExpiryDate.Value <= thresholdDate)
                    .Include(ii => ii.Item)
                    .Select(ii => new
                    {
                        ii.Item.ItemCode,
                        ii.Item.ItemName,
                        Warehouse = _context.Warehouses
                                            .Where(w => w.WarehouseID == ii.WarehouseID)
                                            .Select(w => w.WarehouseName)
                                            .FirstOrDefault(),
                        ProdDate = ii.ProductionDate,
                        ExpDate = ii.ExpiryDate,
                        DaysUntilExpiry = EF.Functions.DateDiffDay(today, ii.ExpiryDate.Value),
                        ii.Quantity
                    })
                    .OrderBy(i => i.ExpDate)
                    .ToList();

                dataGridView1.DataSource = nearExpiryItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating near-expiry report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
