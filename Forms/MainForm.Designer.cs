namespace WarehouseManagementSystem.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnWarehouse = new Button();
            btnItem = new Button();
            btnBusinessPartner = new Button();
            btnSupplyPermission = new Button();
            btnReleasePermission = new Button();
            btnTransfer = new Button();
            btnInventoryReport = new Button();
            btnPermissionReport = new Button();
            btnWhReport = new Button();
            btnInactiveItems = new Button();
            btnNearExpiry = new Button();
            SuspendLayout();
            // 
            // btnWarehouse
            // 
            btnWarehouse.AutoSize = true;
            btnWarehouse.Location = new Point(158, 49);
            btnWarehouse.Name = "btnWarehouse";
            btnWarehouse.Size = new Size(94, 30);
            btnWarehouse.TabIndex = 0;
            btnWarehouse.Text = "Warehouse";
            btnWarehouse.UseVisualStyleBackColor = true;
            btnWarehouse.Click += btnWarehouse_Click;
            // 
            // btnItem
            // 
            btnItem.AutoSize = true;
            btnItem.Location = new Point(348, 49);
            btnItem.Name = "btnItem";
            btnItem.Size = new Size(94, 30);
            btnItem.TabIndex = 1;
            btnItem.Text = "Item";
            btnItem.UseVisualStyleBackColor = true;
            btnItem.Click += btnItem_Click;
            // 
            // btnBusinessPartner
            // 
            btnBusinessPartner.AutoSize = true;
            btnBusinessPartner.Location = new Point(503, 48);
            btnBusinessPartner.Name = "btnBusinessPartner";
            btnBusinessPartner.Size = new Size(127, 32);
            btnBusinessPartner.TabIndex = 2;
            btnBusinessPartner.Text = "Business Partner";
            btnBusinessPartner.UseVisualStyleBackColor = true;
            btnBusinessPartner.Click += btnBusinessPartner_Click;
            // 
            // btnSupplyPermission
            // 
            btnSupplyPermission.AutoSize = true;
            btnSupplyPermission.Location = new Point(136, 135);
            btnSupplyPermission.Name = "btnSupplyPermission";
            btnSupplyPermission.Size = new Size(138, 30);
            btnSupplyPermission.TabIndex = 3;
            btnSupplyPermission.Text = "Supply Permission";
            btnSupplyPermission.UseVisualStyleBackColor = true;
            btnSupplyPermission.Click += btnSupplyPermission_Click;
            // 
            // btnReleasePermission
            // 
            btnReleasePermission.AutoSize = true;
            btnReleasePermission.Location = new Point(323, 135);
            btnReleasePermission.Name = "btnReleasePermission";
            btnReleasePermission.Size = new Size(144, 30);
            btnReleasePermission.TabIndex = 4;
            btnReleasePermission.Text = "Release Permission";
            btnReleasePermission.UseVisualStyleBackColor = true;
            btnReleasePermission.Click += btnReleasePermission_Click;
            // 
            // btnTransfer
            // 
            btnTransfer.AutoSize = true;
            btnTransfer.Location = new Point(519, 135);
            btnTransfer.Name = "btnTransfer";
            btnTransfer.Size = new Size(94, 30);
            btnTransfer.TabIndex = 5;
            btnTransfer.Text = "Transfer";
            btnTransfer.UseVisualStyleBackColor = true;
            btnTransfer.Click += btnTransfer_Click;
            // 
            // btnInventoryReport
            // 
            btnInventoryReport.AutoSize = true;
            btnInventoryReport.Location = new Point(331, 221);
            btnInventoryReport.Name = "btnInventoryReport";
            btnInventoryReport.Size = new Size(129, 30);
            btnInventoryReport.TabIndex = 6;
            btnInventoryReport.Text = "Inventory Report";
            btnInventoryReport.UseVisualStyleBackColor = true;
            btnInventoryReport.Click += btnInventoryReport_Click;
            // 
            // btnPermissionReport
            // 
            btnPermissionReport.AutoSize = true;
            btnPermissionReport.Location = new Point(497, 221);
            btnPermissionReport.Name = "btnPermissionReport";
            btnPermissionReport.Size = new Size(138, 30);
            btnPermissionReport.TabIndex = 7;
            btnPermissionReport.Text = "Permission Report";
            btnPermissionReport.UseVisualStyleBackColor = true;
            btnPermissionReport.Click += btnPermissionReport_Click;
            // 
            // btnWhReport
            // 
            btnWhReport.AutoSize = true;
            btnWhReport.Location = new Point(135, 221);
            btnWhReport.Name = "btnWhReport";
            btnWhReport.Size = new Size(141, 30);
            btnWhReport.TabIndex = 8;
            btnWhReport.Text = "Warehouse Report";
            btnWhReport.UseVisualStyleBackColor = true;
            btnWhReport.Click += btnWhReport_Click;
            // 
            // btnInactiveItems
            // 
            btnInactiveItems.AutoSize = true;
            btnInactiveItems.Location = new Point(136, 307);
            btnInactiveItems.Name = "btnInactiveItems";
            btnInactiveItems.Size = new Size(155, 30);
            btnInactiveItems.TabIndex = 9;
            btnInactiveItems.Text = "InactiveItems Report";
            btnInactiveItems.UseVisualStyleBackColor = true;
            btnInactiveItems.Click += btnInactiveItems_Click;
            // 
            // btnNearExpiry
            // 
            btnNearExpiry.AutoSize = true;
            btnNearExpiry.Location = new Point(318, 307);
            btnNearExpiry.Name = "btnNearExpiry";
            btnNearExpiry.Size = new Size(155, 30);
            btnNearExpiry.TabIndex = 10;
            btnNearExpiry.Text = "NearExpiry Report";
            btnNearExpiry.UseVisualStyleBackColor = true;
            btnNearExpiry.Click += btnNearExpiry_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnNearExpiry);
            Controls.Add(btnInactiveItems);
            Controls.Add(btnWhReport);
            Controls.Add(btnPermissionReport);
            Controls.Add(btnInventoryReport);
            Controls.Add(btnTransfer);
            Controls.Add(btnReleasePermission);
            Controls.Add(btnSupplyPermission);
            Controls.Add(btnBusinessPartner);
            Controls.Add(btnItem);
            Controls.Add(btnWarehouse);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnWarehouse;
        private Button btnItem;
        private Button btnBusinessPartner;
        private Button btnSupplyPermission;
        private Button btnReleasePermission;
        private Button btnTransfer;
        private Button btnInventoryReport;
        private Button btnPermissionReport;
        private Button btnWhReport;
        private Button btnInactiveItems;
        private Button btnNearExpiry;
    }
}