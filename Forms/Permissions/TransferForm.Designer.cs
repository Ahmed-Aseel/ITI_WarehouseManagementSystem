namespace WarehouseManagementSystem.Forms.Permissions
{
    partial class TransferForm
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
            btnDeleteItem = new Button();
            btnUpdateItem = new Button();
            btnAddItem = new Button();
            btnDisplay = new Button();
            btnUpdatePermission = new Button();
            btnAddPermission = new Button();
            dataGridView2 = new DataGridView();
            dataGridView1 = new DataGridView();
            label8 = new Label();
            ProdDate = new DateTimePicker();
            label7 = new Label();
            tbQuantity = new TextBox();
            label6 = new Label();
            cbItem = new ComboBox();
            label5 = new Label();
            PermDate = new DateTimePicker();
            label3 = new Label();
            cbSrcWh = new ComboBox();
            tbPermNum = new TextBox();
            label2 = new Label();
            label1 = new Label();
            cbDestWh = new ComboBox();
            label9 = new Label();
            expDate = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnDeleteItem
            // 
            btnDeleteItem.AutoSize = true;
            btnDeleteItem.Location = new Point(828, 184);
            btnDeleteItem.Name = "btnDeleteItem";
            btnDeleteItem.Size = new Size(121, 30);
            btnDeleteItem.TabIndex = 78;
            btnDeleteItem.Text = "Delete Item";
            btnDeleteItem.UseVisualStyleBackColor = true;
            btnDeleteItem.Click += btnDeleteItem_Click;
            // 
            // btnUpdateItem
            // 
            btnUpdateItem.AutoSize = true;
            btnUpdateItem.Location = new Point(692, 184);
            btnUpdateItem.Name = "btnUpdateItem";
            btnUpdateItem.Size = new Size(121, 30);
            btnUpdateItem.TabIndex = 77;
            btnUpdateItem.Text = "Update Item";
            btnUpdateItem.UseVisualStyleBackColor = true;
            btnUpdateItem.Click += btnUpdateItem_Click;
            // 
            // btnAddItem
            // 
            btnAddItem.AutoSize = true;
            btnAddItem.Location = new Point(556, 184);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(121, 30);
            btnAddItem.TabIndex = 76;
            btnAddItem.Text = "Add Item";
            btnAddItem.UseVisualStyleBackColor = true;
            btnAddItem.Click += btnAddItem_Click;
            // 
            // btnDisplay
            // 
            btnDisplay.AutoSize = true;
            btnDisplay.Location = new Point(447, 184);
            btnDisplay.Name = "btnDisplay";
            btnDisplay.Size = new Size(94, 30);
            btnDisplay.TabIndex = 75;
            btnDisplay.Text = "Display";
            btnDisplay.UseVisualStyleBackColor = true;
            btnDisplay.Click += btnDisplay_Click;
            // 
            // btnUpdatePermission
            // 
            btnUpdatePermission.AutoSize = true;
            btnUpdatePermission.Location = new Point(290, 184);
            btnUpdatePermission.Name = "btnUpdatePermission";
            btnUpdatePermission.Size = new Size(142, 30);
            btnUpdatePermission.TabIndex = 74;
            btnUpdatePermission.Text = "Update Permission";
            btnUpdatePermission.UseVisualStyleBackColor = true;
            btnUpdatePermission.Click += btnUpdatePermission_Click;
            // 
            // btnAddPermission
            // 
            btnAddPermission.AutoSize = true;
            btnAddPermission.Location = new Point(154, 184);
            btnAddPermission.Name = "btnAddPermission";
            btnAddPermission.Size = new Size(121, 30);
            btnAddPermission.TabIndex = 73;
            btnAddPermission.Text = "Add Permission";
            btnAddPermission.UseVisualStyleBackColor = true;
            btnAddPermission.Click += btnAddPermission_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(566, 245);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(558, 262);
            dataGridView2.TabIndex = 72;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 245);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(555, 262);
            dataGridView1.TabIndex = 71;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(586, 121);
            label8.Name = "label8";
            label8.Size = new Size(85, 20);
            label8.TabIndex = 69;
            label8.Text = "Expiry Date";
            // 
            // ProdDate
            // 
            ProdDate.Format = DateTimePickerFormat.Short;
            ProdDate.Location = new Point(728, 83);
            ProdDate.Name = "ProdDate";
            ProdDate.Size = new Size(207, 27);
            ProdDate.TabIndex = 68;
            ProdDate.Value = new DateTime(2025, 6, 1, 0, 0, 0, 0);
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(586, 86);
            label7.Name = "label7";
            label7.Size = new Size(117, 20);
            label7.TabIndex = 67;
            label7.Text = "Production Date";
            // 
            // tbQuantity
            // 
            tbQuantity.Location = new Point(728, 48);
            tbQuantity.Name = "tbQuantity";
            tbQuantity.Size = new Size(207, 27);
            tbQuantity.TabIndex = 66;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(586, 51);
            label6.Name = "label6";
            label6.Size = new Size(65, 20);
            label6.TabIndex = 65;
            label6.Text = "Quantity";
            // 
            // cbItem
            // 
            cbItem.FormattingEnabled = true;
            cbItem.Location = new Point(728, 12);
            cbItem.Name = "cbItem";
            cbItem.Size = new Size(207, 28);
            cbItem.TabIndex = 64;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(586, 16);
            label5.Name = "label5";
            label5.Size = new Size(83, 20);
            label5.TabIndex = 63;
            label5.Text = "Item Name";
            // 
            // PermDate
            // 
            PermDate.Format = DateTimePickerFormat.Short;
            PermDate.Location = new Point(310, 117);
            PermDate.Name = "PermDate";
            PermDate.Size = new Size(207, 27);
            PermDate.TabIndex = 60;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(166, 121);
            label3.Name = "label3";
            label3.Size = new Size(115, 20);
            label3.TabIndex = 59;
            label3.Text = "Permission Date";
            // 
            // cbSrcWh
            // 
            cbSrcWh.FormattingEnabled = true;
            cbSrcWh.Location = new Point(310, 47);
            cbSrcWh.Name = "cbSrcWh";
            cbSrcWh.Size = new Size(207, 28);
            cbSrcWh.TabIndex = 58;
            cbSrcWh.SelectedIndexChanged += cbSrcWh_SelectedIndexChanged;
            // 
            // tbPermNum
            // 
            tbPermNum.Location = new Point(310, 13);
            tbPermNum.Name = "tbPermNum";
            tbPermNum.Size = new Size(207, 27);
            tbPermNum.TabIndex = 57;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(166, 51);
            label2.Name = "label2";
            label2.Size = new Size(106, 20);
            label2.TabIndex = 56;
            label2.Text = "Src Warehouse";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(166, 16);
            label1.Name = "label1";
            label1.Size = new Size(137, 20);
            label1.TabIndex = 55;
            label1.Text = "Permission Number";
            // 
            // cbDestWh
            // 
            cbDestWh.FormattingEnabled = true;
            cbDestWh.Location = new Point(310, 82);
            cbDestWh.Name = "cbDestWh";
            cbDestWh.Size = new Size(207, 28);
            cbDestWh.TabIndex = 80;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(166, 86);
            label9.Name = "label9";
            label9.Size = new Size(116, 20);
            label9.TabIndex = 79;
            label9.Text = "Dest Warehouse";
            // 
            // expDate
            // 
            expDate.Format = DateTimePickerFormat.Short;
            expDate.Location = new Point(728, 118);
            expDate.Name = "expDate";
            expDate.Size = new Size(207, 27);
            expDate.TabIndex = 81;
            expDate.Value = new DateTime(2025, 6, 1, 0, 0, 0, 0);
            // 
            // TransferForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 505);
            Controls.Add(expDate);
            Controls.Add(cbDestWh);
            Controls.Add(label9);
            Controls.Add(btnDeleteItem);
            Controls.Add(btnUpdateItem);
            Controls.Add(btnAddItem);
            Controls.Add(btnDisplay);
            Controls.Add(btnUpdatePermission);
            Controls.Add(btnAddPermission);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(label8);
            Controls.Add(ProdDate);
            Controls.Add(label7);
            Controls.Add(tbQuantity);
            Controls.Add(label6);
            Controls.Add(cbItem);
            Controls.Add(label5);
            Controls.Add(PermDate);
            Controls.Add(label3);
            Controls.Add(cbSrcWh);
            Controls.Add(tbPermNum);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TransferForm";
            Text = "TransferForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDeleteItem;
        private Button btnUpdateItem;
        private Button btnAddItem;
        private Button btnDisplay;
        private Button btnUpdatePermission;
        private Button btnAddPermission;
        private DataGridView dataGridView2;
        private DataGridView dataGridView1;
        private Label label8;
        private DateTimePicker ProdDate;
        private Label label7;
        private TextBox tbQuantity;
        private Label label6;
        private ComboBox cbItem;
        private Label label5;
        private DateTimePicker PermDate;
        private Label label3;
        private ComboBox cbSrcWh;
        private TextBox tbPermNum;
        private Label label2;
        private Label label1;
        private ComboBox cbDestWh;
        private Label label9;
        private DateTimePicker expDate;
    }
}