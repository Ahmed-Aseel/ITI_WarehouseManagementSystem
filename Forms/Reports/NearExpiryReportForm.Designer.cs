namespace WarehouseManagementSystem.Forms.Reports
{
    partial class NearExpiryReportForm
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
            txtDays = new TextBox();
            label1 = new Label();
            clbWarehouses = new CheckedListBox();
            btnGenerateReport = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtDays
            // 
            txtDays.Location = new Point(432, 25);
            txtDays.Name = "txtDays";
            txtDays.Size = new Size(133, 27);
            txtDays.TabIndex = 116;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(317, 28);
            label1.Name = "label1";
            label1.Size = new Size(104, 20);
            label1.TabIndex = 115;
            label1.Text = "Days to expire";
            // 
            // clbWarehouses
            // 
            clbWarehouses.FormattingEnabled = true;
            clbWarehouses.Location = new Point(130, 15);
            clbWarehouses.Name = "clbWarehouses";
            clbWarehouses.Size = new Size(150, 114);
            clbWarehouses.TabIndex = 114;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.AutoSize = true;
            btnGenerateReport.Location = new Point(317, 77);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(128, 30);
            btnGenerateReport.TabIndex = 113;
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
            dataGridView1.TabIndex = 112;
            // 
            // NearExpiryReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtDays);
            Controls.Add(label1);
            Controls.Add(clbWarehouses);
            Controls.Add(btnGenerateReport);
            Controls.Add(dataGridView1);
            Name = "NearExpiryReportForm";
            Text = "NearExpiryReportForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDays;
        private Label label1;
        private CheckedListBox clbWarehouses;
        private Button btnGenerateReport;
        private DataGridView dataGridView1;
    }
}