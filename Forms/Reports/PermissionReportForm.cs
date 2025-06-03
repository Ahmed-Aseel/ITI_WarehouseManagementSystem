using Microsoft.EntityFrameworkCore;
using System.Data;
using WarehouseManagementSystem.Data.Contexts;
using WarehouseManagementSystem.Data.Entities.Permissions;

namespace WarehouseManagementSystem.Forms.Reports
{
    public partial class PermissionReportForm : Form
    {
        // Helper class to show warehouse names in CheckedListBox
        public class WarehouseDisplay
        {
            public int WarehouseID { get; set; }
            public string WarehouseName { get; set; }
            public override string ToString() => WarehouseName;
        }

        private readonly WarehouseContext _context;

        public PermissionReportForm(WarehouseContext context)
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

            StartDate.MaxDate = DateTime.Today.Date;
            EndDate.MaxDate = DateTime.Today.Date;
            chbFilter.Checked = false;
            // disable date pickers initially
            StartDate.Enabled = false;
            EndDate.Enabled = false;
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedWarehouseIds = clbWarehouses.CheckedItems
                                                .Cast<WarehouseDisplay>()
                                                .Select(item => item.WarehouseID)
                                                .ToList();

                if (!selectedWarehouseIds.Any())
                {
                    MessageBox.Show("Please select at least one warehouse.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime? startDate = chbFilter.Checked ? StartDate.Value.Date : null;
                DateTime? endDate = chbFilter.Checked ? EndDate.Value.Date.AddDays(1).AddTicks(-1) : null;

                if (startDate > endDate)
                {
                    MessageBox.Show("Start date cannot be greater than end date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var query = _context.PermissionItems
                                    .Include(pi => pi.Item)
                                    .Include(pi => pi.Permission)
                                        .ThenInclude(p => p.MainWarehouse)
                                    .Include(pi => pi.Permission)
                                        .ThenInclude(p => p.TransferPermission)
                                            .ThenInclude(tp => tp.DestWarehouse)
                                    .AsQueryable();

                query = query.Where(pi =>
                    selectedWarehouseIds.Contains(pi.Permission.MainWarehouseID) ||
                    (pi.Permission.Type == PermissionType.Transfer &&
                     selectedWarehouseIds.Contains(pi.Permission.TransferPermission.DestWarehouseID)));

                if (startDate.HasValue && endDate.HasValue)
                {
                    query = query.Where(pi =>
                        pi.Permission.PermissionDate >= startDate.Value &&
                        pi.Permission.PermissionDate <= endDate.Value);
                }

                var reportData = query.Select(pi => new
                {
                    pi.Item.ItemCode,
                    pi.Item.ItemName,
                    Date = pi.Permission.PermissionDate,

                    Warehouse = selectedWarehouseIds.Contains(pi.Permission.MainWarehouseID)
                                    ? pi.Permission.MainWarehouse.WarehouseName
                                    : pi.Permission.TransferPermission.DestWarehouse.WarehouseName,

                    OperationType = pi.Permission.Type == PermissionType.Supply
                                        ? (selectedWarehouseIds.Contains(pi.Permission.MainWarehouseID) ? "In (Supply)" : "N/A")
                                    : pi.Permission.Type == PermissionType.Release
                                        ? (selectedWarehouseIds.Contains(pi.Permission.MainWarehouseID) ? "Out (Release)" : "N/A")
                                    : pi.Permission.Type == PermissionType.Transfer
                                        ? (selectedWarehouseIds.Contains(pi.Permission.MainWarehouseID) ? "Out (Transfer)" : "In (Transfer)")
                                    : "Unknown",

                    pi.Quantity
                })
                .OrderBy(r => r.ItemName).ThenBy(r => r.Date)
                .ToList();

                dataGridView1.DataSource = reportData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while generating the report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chbFilter_CheckedChanged(object sender, EventArgs e)
        {
            // Enable or disable date pickers based on the checkbox state
            StartDate.Enabled = chbFilter.Checked;
            EndDate.Enabled = chbFilter.Checked;
            // Clear the date pickers if the filter is unchecked
            if (!chbFilter.Checked)
            {
                StartDate.Value = DateTime.Today;
                EndDate.Value = DateTime.Today;
            }
        }
    }
}
