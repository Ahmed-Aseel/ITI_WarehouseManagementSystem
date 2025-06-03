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
    public partial class WarehouseReportForm : Form
    {
        private readonly WarehouseContext _context;

        public WarehouseReportForm(WarehouseContext context)
        {
            InitializeComponent();
            _context = context;

            // Load warehouses into the combo box
            cbWh.DisplayMember = "WarehouseName";
            cbWh.ValueMember = "WarehouseID";
            cbWh.DataSource = _context.Warehouses.ToList();
            cbWh.SelectedIndex = -1; // No selection by default

            StartDate.MaxDate = DateTime.Today.Date;
            EndDate.MaxDate = DateTime.Today.Date;
            chbFilter.Checked = false;
            StartDate.Enabled = false;
            EndDate.Enabled = false;
        }

        private void chbFilter_CheckedChanged(object sender, EventArgs e)
        {
            StartDate.Enabled = chbFilter.Checked;
            EndDate.Enabled = chbFilter.Checked;
            if (!chbFilter.Checked)
            {
                StartDate.Value = DateTime.Today.Date;
                EndDate.Value = DateTime.Today.Date;
            }
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbWh.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a warehouse.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int selectedWarehouseId = (int)cbWh.SelectedValue;
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
                                        .ThenInclude(p => p.SupplyPermission)
                                            .ThenInclude(sp => sp.Supplier)
                                    .Include(pi => pi.Permission)
                                        .ThenInclude(p => p.ReleasePermission)
                                            .ThenInclude(rp => rp.Customer)
                                    .Include(pi => pi.Permission)
                                        .ThenInclude(p => p.TransferPermission)
                                            .ThenInclude(tp => tp.DestWarehouse)
                                    .AsQueryable();

                // Filter by warehouse (either source or destination)
                query = query.Where(pi =>
                    pi.Permission.MainWarehouseID == selectedWarehouseId ||
                    (pi.Permission.Type == PermissionType.Transfer &&
                     pi.Permission.TransferPermission.DestWarehouseID == selectedWarehouseId));

                // Filter by date
                if (startDate.HasValue && endDate.HasValue)
                {
                    query = query.Where(pi =>
                        pi.Permission.PermissionDate >= startDate.Value &&
                        pi.Permission.PermissionDate <= endDate.Value);
                }

                var reportData = query.Select(pi => new
                {
                    Warehouse = selectedWarehouseId == pi.Permission.MainWarehouseID
                                    ? pi.Permission.MainWarehouse.WarehouseName
                                    : pi.Permission.TransferPermission.DestWarehouse.WarehouseName,

                    pi.Item.ItemName,
                    pi.ItemCode,
                    pi.Quantity,
                    Date = pi.Permission.PermissionDate,

                    OperationType = pi.Permission.Type == PermissionType.Supply
                                        ? (pi.Permission.MainWarehouseID == selectedWarehouseId ? "In (Supply)" : "Unknown")
                                    : pi.Permission.Type == PermissionType.Release
                                        ? (pi.Permission.MainWarehouseID == selectedWarehouseId ? "Out (Release)" : "Unknown")
                                    : pi.Permission.Type == PermissionType.Transfer
                                        ? (pi.Permission.MainWarehouseID == selectedWarehouseId ? "Out (Transfer)" : "In (Transfer)")
                                    : "Unknown",

                    RelatedParty = pi.Permission.Type == PermissionType.Supply
                                        ? pi.Permission.SupplyPermission.Supplier.Name
                                   : pi.Permission.Type == PermissionType.Release
                                        ? pi.Permission.ReleasePermission.Customer.Name
                                   : pi.Permission.Type == PermissionType.Transfer
                                        ? (pi.Permission.MainWarehouseID == selectedWarehouseId
                                            ? pi.Permission.TransferPermission.DestWarehouse.WarehouseName
                                            : pi.Permission.MainWarehouse.WarehouseName)
                                   : "N/A"
                })
                .OrderBy(r => r.Date)
                .ToList();

                dataGridView1.DataSource = reportData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
