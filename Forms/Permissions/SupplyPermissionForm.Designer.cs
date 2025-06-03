namespace WarehouseManagementSystem.Forms.Permissions
{
    partial class SupplyPermissionForm
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
            cbWarehouse = new ComboBox();
            tbPermNum = new TextBox();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            PermDate = new DateTimePicker();
            cbSupplier = new ComboBox();
            label4 = new Label();
            cbItem = new ComboBox();
            label5 = new Label();
            tbQuantity = new TextBox();
            label6 = new Label();
            ProdDate = new DateTimePicker();
            label7 = new Label();
            tbExpDuration = new TextBox();
            label8 = new Label();
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            btnDisplay = new Button();
            btnUpdatePermission = new Button();
            btnAddPermission = new Button();
            btnAddItem = new Button();
            btnUpdateItem = new Button();
            btnDeleteItem = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // cbWarehouse
            // 
            cbWarehouse.FormattingEnabled = true;
            cbWarehouse.Location = new Point(310, 53);
            cbWarehouse.Name = "cbWarehouse";
            cbWarehouse.Size = new Size(207, 28);
            cbWarehouse.TabIndex = 34;
            // 
            // tbPermNum
            // 
            tbPermNum.Location = new Point(310, 14);
            tbPermNum.Name = "tbPermNum";
            tbPermNum.Size = new Size(207, 27);
            tbPermNum.TabIndex = 33;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(166, 57);
            label2.Name = "label2";
            label2.Size = new Size(126, 20);
            label2.TabIndex = 32;
            label2.Text = "Warehouse Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(166, 17);
            label1.Name = "label1";
            label1.Size = new Size(137, 20);
            label1.TabIndex = 31;
            label1.Text = "Permission Number";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(166, 96);
            label3.Name = "label3";
            label3.Size = new Size(115, 20);
            label3.TabIndex = 35;
            label3.Text = "Permission Date";
            // 
            // PermDate
            // 
            PermDate.Format = DateTimePickerFormat.Short;
            PermDate.Location = new Point(310, 93);
            PermDate.Name = "PermDate";
            PermDate.Size = new Size(207, 27);
            PermDate.TabIndex = 36;
            // 
            // cbSupplier
            // 
            cbSupplier.FormattingEnabled = true;
            cbSupplier.Location = new Point(310, 132);
            cbSupplier.Name = "cbSupplier";
            cbSupplier.Size = new Size(207, 28);
            cbSupplier.TabIndex = 38;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(166, 136);
            label4.Name = "label4";
            label4.Size = new Size(108, 20);
            label4.TabIndex = 37;
            label4.Text = "Supplier Name";
            // 
            // cbItem
            // 
            cbItem.FormattingEnabled = true;
            cbItem.Location = new Point(728, 13);
            cbItem.Name = "cbItem";
            cbItem.Size = new Size(207, 28);
            cbItem.TabIndex = 40;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(579, 17);
            label5.Name = "label5";
            label5.Size = new Size(83, 20);
            label5.TabIndex = 39;
            label5.Text = "Item Name";
            // 
            // tbQuantity
            // 
            tbQuantity.Location = new Point(728, 54);
            tbQuantity.Name = "tbQuantity";
            tbQuantity.Size = new Size(207, 27);
            tbQuantity.TabIndex = 42;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(579, 57);
            label6.Name = "label6";
            label6.Size = new Size(65, 20);
            label6.TabIndex = 41;
            label6.Text = "Quantity";
            // 
            // ProdDate
            // 
            ProdDate.Format = DateTimePickerFormat.Short;
            ProdDate.Location = new Point(728, 93);
            ProdDate.Name = "ProdDate";
            ProdDate.Size = new Size(207, 27);
            ProdDate.TabIndex = 44;
            ProdDate.Value = new DateTime(2025, 6, 1, 0, 0, 0, 0);
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(579, 96);
            label7.Name = "label7";
            label7.Size = new Size(117, 20);
            label7.TabIndex = 43;
            label7.Text = "Production Date";
            // 
            // tbExpDuration
            // 
            tbExpDuration.Location = new Point(728, 133);
            tbExpDuration.Name = "tbExpDuration";
            tbExpDuration.Size = new Size(207, 27);
            tbExpDuration.TabIndex = 46;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(579, 136);
            label8.Name = "label8";
            label8.Size = new Size(111, 20);
            label8.TabIndex = 45;
            label8.Text = "Expiry Duration";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 246);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(555, 205);
            dataGridView1.TabIndex = 47;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // dataGridView2
            // 
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(566, 246);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(558, 205);
            dataGridView2.TabIndex = 48;
            dataGridView2.SelectionChanged += dataGridView2_SelectionChanged;
            // 
            // btnDisplay
            // 
            btnDisplay.AutoSize = true;
            btnDisplay.Location = new Point(447, 190);
            btnDisplay.Name = "btnDisplay";
            btnDisplay.Size = new Size(94, 30);
            btnDisplay.TabIndex = 51;
            btnDisplay.Text = "Display";
            btnDisplay.UseVisualStyleBackColor = true;
            btnDisplay.Click += btnDisplay_Click;
            // 
            // btnUpdatePermission
            // 
            btnUpdatePermission.AutoSize = true;
            btnUpdatePermission.Location = new Point(290, 190);
            btnUpdatePermission.Name = "btnUpdatePermission";
            btnUpdatePermission.Size = new Size(142, 30);
            btnUpdatePermission.TabIndex = 50;
            btnUpdatePermission.Text = "Update Permission";
            btnUpdatePermission.UseVisualStyleBackColor = true;
            btnUpdatePermission.Click += btnUpdatePermission_Click;
            // 
            // btnAddPermission
            // 
            btnAddPermission.AutoSize = true;
            btnAddPermission.Location = new Point(154, 190);
            btnAddPermission.Name = "btnAddPermission";
            btnAddPermission.Size = new Size(121, 30);
            btnAddPermission.TabIndex = 49;
            btnAddPermission.Text = "Add Permission";
            btnAddPermission.UseVisualStyleBackColor = true;
            btnAddPermission.Click += btnAddPermission_Click;
            // 
            // btnAddItem
            // 
            btnAddItem.AutoSize = true;
            btnAddItem.Location = new Point(556, 190);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(121, 30);
            btnAddItem.TabIndex = 52;
            btnAddItem.Text = "Add Item";
            btnAddItem.UseVisualStyleBackColor = true;
            btnAddItem.Click += btnAddItem_Click;
            // 
            // btnUpdateItem
            // 
            btnUpdateItem.AutoSize = true;
            btnUpdateItem.Location = new Point(692, 190);
            btnUpdateItem.Name = "btnUpdateItem";
            btnUpdateItem.Size = new Size(121, 30);
            btnUpdateItem.TabIndex = 53;
            btnUpdateItem.Text = "Update Item";
            btnUpdateItem.UseVisualStyleBackColor = true;
            btnUpdateItem.Click += btnUpdateItem_Click;
            // 
            // btnDeleteItem
            // 
            btnDeleteItem.AutoSize = true;
            btnDeleteItem.Location = new Point(828, 190);
            btnDeleteItem.Name = "btnDeleteItem";
            btnDeleteItem.Size = new Size(121, 30);
            btnDeleteItem.TabIndex = 54;
            btnDeleteItem.Text = "Delete Item";
            btnDeleteItem.UseVisualStyleBackColor = true;
            btnDeleteItem.Click += btnDeleteItem_Click;
            // 
            // SupplyPermissionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 451);
            Controls.Add(btnDeleteItem);
            Controls.Add(btnUpdateItem);
            Controls.Add(btnAddItem);
            Controls.Add(btnDisplay);
            Controls.Add(btnUpdatePermission);
            Controls.Add(btnAddPermission);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(tbExpDuration);
            Controls.Add(label8);
            Controls.Add(ProdDate);
            Controls.Add(label7);
            Controls.Add(tbQuantity);
            Controls.Add(label6);
            Controls.Add(cbItem);
            Controls.Add(label5);
            Controls.Add(cbSupplier);
            Controls.Add(label4);
            Controls.Add(PermDate);
            Controls.Add(label3);
            Controls.Add(cbWarehouse);
            Controls.Add(tbPermNum);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "SupplyPermissionForm";
            Text = "SupplyPermissionForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbWarehouse;
        private TextBox tbPermNum;
        private Label label2;
        private Label label1;
        private Label label3;
        private DateTimePicker PermDate;
        private ComboBox cbSupplier;
        private Label label4;
        private ComboBox cbItem;
        private Label label5;
        private TextBox tbQuantity;
        private Label label6;
        private DateTimePicker ProdDate;
        private Label label7;
        private TextBox tbExpDuration;
        private Label label8;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private Button btnDisplay;
        private Button btnUpdatePermission;
        private Button btnAddPermission;
        private Button btnAddItem;
        private Button btnUpdateItem;
        private Button btnDeleteItem;
    }
}