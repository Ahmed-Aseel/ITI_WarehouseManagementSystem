namespace WarehouseManagementSystem.Forms.Reports
{
    partial class InactiveItemsReportForm
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
            clbWarehouses = new CheckedListBox();
            btnGenerateReport = new Button();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            txtDays = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // clbWarehouses
            // 
            clbWarehouses.FormattingEnabled = true;
            clbWarehouses.Location = new Point(130, 26);
            clbWarehouses.Name = "clbWarehouses";
            clbWarehouses.Size = new Size(150, 114);
            clbWarehouses.TabIndex = 109;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.AutoSize = true;
            btnGenerateReport.Location = new Point(317, 90);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(128, 30);
            btnGenerateReport.TabIndex = 108;
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
            dataGridView1.TabIndex = 107;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(317, 41);
            label1.Name = "label1";
            label1.Size = new Size(101, 20);
            label1.TabIndex = 110;
            label1.Text = "Period in days";
            // 
            // txtDays
            // 
            txtDays.Location = new Point(428, 38);
            txtDays.Name = "txtDays";
            txtDays.Size = new Size(133, 27);
            txtDays.TabIndex = 111;
            // 
            // InactiveItemsReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtDays);
            Controls.Add(label1);
            Controls.Add(clbWarehouses);
            Controls.Add(btnGenerateReport);
            Controls.Add(dataGridView1);
            Name = "InactiveItemsReportForm";
            Text = "InactiveItemsReportForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox clbWarehouses;
        private Button btnGenerateReport;
        private DataGridView dataGridView1;
        private Label label1;
        private TextBox txtDays;
    }
}