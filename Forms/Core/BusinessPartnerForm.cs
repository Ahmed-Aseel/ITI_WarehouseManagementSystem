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
    public partial class BusinessPartnerForm : Form
    {
        private readonly WarehouseContext _context;

        public BusinessPartnerForm(WarehouseContext context)
        {
            InitializeComponent();
            _context = context;
            // Initialize ComboBox with PartnerType enum values
            comboBox1.DataSource = Enum.GetValues(typeof(PartnerType));
            comboBox1.SelectedIndex = -1; // No selection by default
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                var partners = _context.BusinessPartners
                                       .Select(bp => new
                                       {
                                           bp.PartnerID,
                                           bp.Name,
                                           bp.Type,
                                           bp.Phone,
                                           bp.Mobile,
                                           bp.Email,
                                           bp.Fax,
                                           bp.Website
                                       })
                                       .ToList();
                dataGridView1.DataSource = partners;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying business partners: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tbName.Text) ||
                    string.IsNullOrWhiteSpace(tbPhone.Text) ||
                    string.IsNullOrWhiteSpace(tbMobile.Text) ||
                    string.IsNullOrWhiteSpace(tbEmail.Text))
                {
                    MessageBox.Show("Please fill in all non optional fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var partner = new BusinessPartner()
                {
                    Name = tbName.Text,
                    Type = (PartnerType)comboBox1.SelectedItem,
                    Phone = tbPhone.Text,
                    Mobile = tbMobile.Text,
                    Email = tbEmail.Text,
                    Fax = string.IsNullOrWhiteSpace(tbFax.Text) ? null : tbFax.Text,
                    Website = string.IsNullOrWhiteSpace(tbWebSite.Text) ? null : tbWebSite.Text
                };

                _context.BusinessPartners.Add(partner);
                _context.SaveChanges();
                tbName.Text = tbPhone.Text = tbFax.Text = tbMobile.Text = tbEmail.Text = tbWebSite.Text = string.Empty; // Clear input fields
                btnDisplay_Click(sender, e); // Refresh the display
                MessageBox.Show("Business partner added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding business partner: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a business partner to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(tbName.Text) &&
                    string.IsNullOrWhiteSpace(tbPhone.Text) &&
                    string.IsNullOrWhiteSpace(tbFax.Text) &&
                    string.IsNullOrWhiteSpace(tbMobile.Text) &&
                    string.IsNullOrWhiteSpace(tbEmail.Text) &&
                    string.IsNullOrWhiteSpace(tbWebSite.Text))
                {
                    MessageBox.Show("Please fill in any field to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedRow = dataGridView1.SelectedRows[0];
                var partnerId = (int)selectedRow.Cells["PartnerID"].Value;
                var partner = _context.BusinessPartners.Find(partnerId);
                if (partner == null)
                {
                    MessageBox.Show("Business partner not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update only the fields that are not empty
                if (!string.IsNullOrWhiteSpace(tbName.Text))
                    partner.Name = tbName.Text;

                if (!string.IsNullOrWhiteSpace(tbPhone.Text))
                    partner.Phone = tbPhone.Text;

                if (!string.IsNullOrWhiteSpace(tbMobile.Text))
                    partner.Mobile = tbMobile.Text;

                if (!string.IsNullOrWhiteSpace(tbEmail.Text))
                    partner.Email = tbEmail.Text;

                if (!string.IsNullOrWhiteSpace(tbFax.Text))
                    partner.Fax = tbFax.Text;

                if (!string.IsNullOrWhiteSpace(tbWebSite.Text))
                    partner.Website = tbWebSite.Text;

                _context.SaveChanges();
                btnDisplay_Click(sender, e); // Refresh the display
                tbName.Text = tbPhone.Text = tbFax.Text = tbMobile.Text = tbEmail.Text = tbWebSite.Text = string.Empty; // Clear input fields
                MessageBox.Show("Business partner updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating business partner: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                tbName.Text = selectedRow.Cells["Name"].Value.ToString();
                comboBox1.SelectedItem = (PartnerType)selectedRow.Cells["Type"].Value;
                tbPhone.Text = selectedRow.Cells["Phone"].Value.ToString();
                tbMobile.Text = selectedRow.Cells["Mobile"].Value.ToString();
                tbEmail.Text = selectedRow.Cells["Email"].Value.ToString();
                tbFax.Text = selectedRow.Cells["Fax"].Value?.ToString() ?? string.Empty;
                tbWebSite.Text = selectedRow.Cells["Website"].Value?.ToString() ?? string.Empty;

                comboBox1.Enabled = false; // Disable ComboBox when a row is selected
                btnAdd.Enabled = false; // Disable Add button when a row is selected
            }
            else
            {
                // Clear input fields if no row is selected
                tbName.Text = tbPhone.Text = tbFax.Text = tbMobile.Text = tbEmail.Text = tbWebSite.Text = string.Empty;
                comboBox1.SelectedIndex = -1; // Reset ComboBox selection
                comboBox1.Enabled = true; // Enable ComboBox when no row is selected
                btnAdd.Enabled = true; // Enable Add button when no row is selected
            }
        }
    }
}
