namespace WarehouseManagementSystem.Forms.Permissions
{
    partial class ReleasePermissionForm
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
            tbQuantity = new TextBox();
            label6 = new Label();
            cbItem = new ComboBox();
            label5 = new Label();
            cbCustomer = new ComboBox();
            label4 = new Label();
            PermDate = new DateTimePicker();
            label3 = new Label();
            cbWarehouse = new ComboBox();
            tbPermNum = new TextBox();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnDeleteItem
            // 
            btnDeleteItem.AutoSize = true;
            btnDeleteItem.Location = new Point(773, 188);
            btnDeleteItem.Name = "btnDeleteItem";
            btnDeleteItem.Size = new Size(121, 30);
            btnDeleteItem.TabIndex = 72;
            btnDeleteItem.Text = "Delete Item";
            btnDeleteItem.UseVisualStyleBackColor = true;
            btnDeleteItem.Click += btnDeleteItem_Click;
            // 
            // btnUpdateItem
            // 
            btnUpdateItem.AutoSize = true;
            btnUpdateItem.Location = new Point(637, 188);
            btnUpdateItem.Name = "btnUpdateItem";
            btnUpdateItem.Size = new Size(121, 30);
            btnUpdateItem.TabIndex = 71;
            btnUpdateItem.Text = "Update Item";
            btnUpdateItem.UseVisualStyleBackColor = true;
            btnUpdateItem.Click += btnUpdateItem_Click;
            // 
            // btnAddItem
            // 
            btnAddItem.AutoSize = true;
            btnAddItem.Location = new Point(501, 188);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(121, 30);
            btnAddItem.TabIndex = 70;
            btnAddItem.Text = "Add Item";
            btnAddItem.UseVisualStyleBackColor = true;
            btnAddItem.Click += btnAddItem_Click;
            // 
            // btnDisplay
            // 
            btnDisplay.AutoSize = true;
            btnDisplay.Location = new Point(392, 188);
            btnDisplay.Name = "btnDisplay";
            btnDisplay.Size = new Size(94, 30);
            btnDisplay.TabIndex = 69;
            btnDisplay.Text = "Display";
            btnDisplay.UseVisualStyleBackColor = true;
            btnDisplay.Click += btnDisplay_Click;
            // 
            // btnUpdatePermission
            // 
            btnUpdatePermission.AutoSize = true;
            btnUpdatePermission.Location = new Point(235, 188);
            btnUpdatePermission.Name = "btnUpdatePermission";
            btnUpdatePermission.Size = new Size(142, 30);
            btnUpdatePermission.TabIndex = 68;
            btnUpdatePermission.Text = "Update Permission";
            btnUpdatePermission.UseVisualStyleBackColor = true;
            btnUpdatePermission.Click += btnUpdatePermission_Click;
            // 
            // btnAddPermission
            // 
            btnAddPermission.AutoSize = true;
            btnAddPermission.Location = new Point(99, 188);
            btnAddPermission.Name = "btnAddPermission";
            btnAddPermission.Size = new Size(121, 30);
            btnAddPermission.TabIndex = 67;
            btnAddPermission.Text = "Add Permission";
            btnAddPermission.UseVisualStyleBackColor = true;
            btnAddPermission.Click += btnAddPermission_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(566, 244);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(558, 205);
            dataGridView2.TabIndex = 66;
            dataGridView2.SelectionChanged += dataGridView2_SelectionChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 244);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(555, 205);
            dataGridView1.TabIndex = 65;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // tbQuantity
            // 
            tbQuantity.Location = new Point(664, 87);
            tbQuantity.Name = "tbQuantity";
            tbQuantity.Size = new Size(207, 27);
            tbQuantity.TabIndex = 64;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(556, 90);
            label6.Name = "label6";
            label6.Size = new Size(65, 20);
            label6.TabIndex = 63;
            label6.Text = "Quantity";
            // 
            // cbItem
            // 
            cbItem.FormattingEnabled = true;
            cbItem.Location = new Point(664, 47);
            cbItem.Name = "cbItem";
            cbItem.Size = new Size(207, 28);
            cbItem.TabIndex = 62;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(556, 51);
            label5.Name = "label5";
            label5.Size = new Size(83, 20);
            label5.TabIndex = 61;
            label5.Text = "Item Name";
            // 
            // cbCustomer
            // 
            cbCustomer.FormattingEnabled = true;
            cbCustomer.Location = new Point(279, 126);
            cbCustomer.Name = "cbCustomer";
            cbCustomer.Size = new Size(207, 28);
            cbCustomer.TabIndex = 80;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(135, 130);
            label4.Name = "label4";
            label4.Size = new Size(116, 20);
            label4.TabIndex = 79;
            label4.Text = "Customer Name";
            // 
            // PermDate
            // 
            PermDate.Format = DateTimePickerFormat.Short;
            PermDate.Location = new Point(279, 87);
            PermDate.Name = "PermDate";
            PermDate.Size = new Size(207, 27);
            PermDate.TabIndex = 78;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(135, 90);
            label3.Name = "label3";
            label3.Size = new Size(115, 20);
            label3.TabIndex = 77;
            label3.Text = "Permission Date";
            // 
            // cbWarehouse
            // 
            cbWarehouse.FormattingEnabled = true;
            cbWarehouse.Location = new Point(279, 47);
            cbWarehouse.Name = "cbWarehouse";
            cbWarehouse.Size = new Size(207, 28);
            cbWarehouse.TabIndex = 76;
            cbWarehouse.SelectedIndexChanged += cbWarehouse_SelectedIndexChanged;
            // 
            // tbPermNum
            // 
            tbPermNum.Location = new Point(279, 8);
            tbPermNum.Name = "tbPermNum";
            tbPermNum.Size = new Size(207, 27);
            tbPermNum.TabIndex = 75;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(135, 51);
            label2.Name = "label2";
            label2.Size = new Size(126, 20);
            label2.TabIndex = 74;
            label2.Text = "Warehouse Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(135, 11);
            label1.Name = "label1";
            label1.Size = new Size(137, 20);
            label1.TabIndex = 73;
            label1.Text = "Permission Number";
            // 
            // ReleasePermissionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 451);
            Controls.Add(cbCustomer);
            Controls.Add(label4);
            Controls.Add(PermDate);
            Controls.Add(label3);
            Controls.Add(cbWarehouse);
            Controls.Add(tbPermNum);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnDeleteItem);
            Controls.Add(btnUpdateItem);
            Controls.Add(btnAddItem);
            Controls.Add(btnDisplay);
            Controls.Add(btnUpdatePermission);
            Controls.Add(btnAddPermission);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(tbQuantity);
            Controls.Add(label6);
            Controls.Add(cbItem);
            Controls.Add(label5);
            Name = "ReleasePermissionForm";
            Text = "ReleasePermissionForm";
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
        private TextBox tbQuantity;
        private Label label6;
        private ComboBox cbItem;
        private Label label5;
        private ComboBox cbCustomer;
        private Label label4;
        private DateTimePicker PermDate;
        private Label label3;
        private ComboBox cbWarehouse;
        private TextBox tbPermNum;
        private Label label2;
        private Label label1;
    }
}