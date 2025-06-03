namespace WarehouseManagementSystem.Forms.Reports
{
    partial class InventoryReportForm
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
            chbFilter = new CheckBox();
            EndDate = new DateTimePicker();
            btnGenerateReport = new Button();
            dataGridView1 = new DataGridView();
            label3 = new Label();
            StartDate = new DateTimePicker();
            label2 = new Label();
            clbWarehouses = new CheckedListBox();
            clbItems = new CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // chbFilter
            // 
            chbFilter.AutoSize = true;
            chbFilter.Location = new Point(389, 20);
            chbFilter.Name = "chbFilter";
            chbFilter.Size = new Size(64, 24);
            chbFilter.TabIndex = 97;
            chbFilter.Text = "Filter";
            chbFilter.UseVisualStyleBackColor = true;
            chbFilter.CheckedChanged += chbFilter_CheckedChanged;
            // 
            // EndDate
            // 
            EndDate.Format = DateTimePickerFormat.Short;
            EndDate.Location = new Point(589, 61);
            EndDate.Name = "EndDate";
            EndDate.Size = new Size(144, 27);
            EndDate.TabIndex = 96;
            EndDate.Value = new DateTime(2025, 6, 3, 0, 0, 0, 0);
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.AutoSize = true;
            btnGenerateReport.Location = new Point(449, 100);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(128, 30);
            btnGenerateReport.TabIndex = 95;
            btnGenerateReport.Text = "Generate Report";
            btnGenerateReport.UseVisualStyleBackColor = true;
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(0, 166);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(800, 284);
            dataGridView1.TabIndex = 94;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(497, 64);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 93;
            label3.Text = "End Date";
            // 
            // StartDate
            // 
            StartDate.Format = DateTimePickerFormat.Short;
            StartDate.Location = new Point(589, 17);
            StartDate.Name = "StartDate";
            StartDate.Size = new Size(144, 27);
            StartDate.TabIndex = 92;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(497, 22);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 91;
            label2.Text = "Start Date";
            // 
            // clbWarehouses
            // 
            clbWarehouses.FormattingEnabled = true;
            clbWarehouses.Location = new Point(12, 16);
            clbWarehouses.Name = "clbWarehouses";
            clbWarehouses.Size = new Size(150, 114);
            clbWarehouses.TabIndex = 98;
            clbWarehouses.ItemCheck += clbWarehouses_ItemCheck;
            // 
            // clbItems
            // 
            clbItems.FormattingEnabled = true;
            clbItems.Location = new Point(194, 16);
            clbItems.Name = "clbItems";
            clbItems.Size = new Size(150, 114);
            clbItems.TabIndex = 99;
            // 
            // InventoryReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(clbItems);
            Controls.Add(clbWarehouses);
            Controls.Add(chbFilter);
            Controls.Add(EndDate);
            Controls.Add(btnGenerateReport);
            Controls.Add(dataGridView1);
            Controls.Add(label3);
            Controls.Add(StartDate);
            Controls.Add(label2);
            Name = "InventoryReportForm";
            Text = "InventoryReportForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox chbFilter;
        private DateTimePicker EndDate;
        private Button btnGenerateReport;
        private DataGridView dataGridView1;
        private Label label3;
        private DateTimePicker StartDate;
        private Label label2;
        private CheckedListBox clbWarehouses;
        private CheckedListBox clbItems;
    }
}