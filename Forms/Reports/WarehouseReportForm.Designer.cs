namespace WarehouseManagementSystem.Forms.Reports
{
    partial class WarehouseReportForm
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
            EndDate = new DateTimePicker();
            btnGenerateReport = new Button();
            dataGridView1 = new DataGridView();
            label3 = new Label();
            StartDate = new DateTimePicker();
            label2 = new Label();
            cbWh = new ComboBox();
            label1 = new Label();
            chbFilter = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // EndDate
            // 
            EndDate.Format = DateTimePickerFormat.Short;
            EndDate.Location = new Point(231, 115);
            EndDate.Name = "EndDate";
            EndDate.Size = new Size(144, 27);
            EndDate.TabIndex = 89;
            EndDate.Value = new DateTime(2025, 6, 3, 0, 0, 0, 0);
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.AutoSize = true;
            btnGenerateReport.Location = new Point(419, 113);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(128, 30);
            btnGenerateReport.TabIndex = 88;
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
            dataGridView1.Size = new Size(829, 284);
            dataGridView1.TabIndex = 87;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(139, 118);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 86;
            label3.Text = "End Date";
            // 
            // StartDate
            // 
            StartDate.Format = DateTimePickerFormat.Short;
            StartDate.Location = new Point(231, 71);
            StartDate.Name = "StartDate";
            StartDate.Size = new Size(144, 27);
            StartDate.TabIndex = 85;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(139, 76);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 84;
            label2.Text = "Start Date";
            // 
            // cbWh
            // 
            cbWh.FormattingEnabled = true;
            cbWh.Location = new Point(146, 26);
            cbWh.Name = "cbWh";
            cbWh.Size = new Size(207, 28);
            cbWh.TabIndex = 83;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 29);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 82;
            label1.Text = "Warehouse";
            // 
            // chbFilter
            // 
            chbFilter.AutoSize = true;
            chbFilter.Location = new Point(31, 74);
            chbFilter.Name = "chbFilter";
            chbFilter.Size = new Size(64, 24);
            chbFilter.TabIndex = 90;
            chbFilter.Text = "Filter";
            chbFilter.UseVisualStyleBackColor = true;
            chbFilter.CheckedChanged += chbFilter_CheckedChanged;
            // 
            // WarehouseReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(829, 450);
            Controls.Add(chbFilter);
            Controls.Add(EndDate);
            Controls.Add(btnGenerateReport);
            Controls.Add(dataGridView1);
            Controls.Add(label3);
            Controls.Add(StartDate);
            Controls.Add(label2);
            Controls.Add(cbWh);
            Controls.Add(label1);
            Name = "WarehouseReportForm";
            Text = "WarehouseReportForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker EndDate;
        private Button btnGenerateReport;
        private DataGridView dataGridView1;
        private Label label3;
        private DateTimePicker StartDate;
        private Label label2;
        private ComboBox cbWh;
        private Label label1;
        private CheckBox chbFilter;
    }
}