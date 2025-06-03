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
using WarehouseManagementSystem.Forms.Core;
using WarehouseManagementSystem.Forms.Permissions;
using WarehouseManagementSystem.Forms.Reports;

namespace WarehouseManagementSystem.Forms
{
    public partial class MainForm : Form
    {
        private readonly WarehouseContext _context;

        public MainForm()
        {
            InitializeComponent();
            _context = new WarehouseContext();
            // Apply any pending migrations at startup
            _context.Database.Migrate();
        }

        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            ShowForm(new WarehouseForm(_context));
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            ShowForm(new ItemForm(_context));
        }

        private void btnBusinessPartner_Click(object sender, EventArgs e)
        {
            ShowForm(new BusinessPartnerForm(_context));
        }

        private void btnSupplyPermission_Click(object sender, EventArgs e)
        {
            ShowForm(new SupplyPermissionForm(_context));
        }

        private void btnReleasePermission_Click(object sender, EventArgs e)
        {
            ShowForm(new ReleasePermissionForm(_context));
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            ShowForm(new TransferForm(_context));
        }

        private void btnWhReport_Click(object sender, EventArgs e)
        {
            ShowForm(new WarehouseReportForm(_context));
        }

        private void btnInventoryReport_Click(object sender, EventArgs e)
        {
            ShowForm(new InventoryReportForm(_context));
        }

        private void btnPermissionReport_Click(object sender, EventArgs e)
        {
            ShowForm(new PermissionReportForm(_context));
        }

        private void btnInactiveItems_Click(object sender, EventArgs e)
        {
            ShowForm(new InactiveItemsReportForm(_context));
        }

        private void btnNearExpiry_Click(object sender, EventArgs e)
        {
            ShowForm(new NearExpiryReportForm(_context));
        }

        private void ShowForm(Form form)
        {
            form.ShowDialog();
        }
    }
}
