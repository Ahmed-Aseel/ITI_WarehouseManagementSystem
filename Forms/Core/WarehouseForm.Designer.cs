namespace WarehouseManagementSystem.Forms.Core
{
    partial class WarehouseForm
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
            dataGridView1 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tbWhName = new TextBox();
            tbWhLoc = new TextBox();
            tbMgrName = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDisplay = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(0, 235);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(800, 215);
            dataGridView1.TabIndex = 0;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(206, 23);
            label1.Name = "label1";
            label1.Size = new Size(126, 20);
            label1.TabIndex = 1;
            label1.Text = "Warehouse Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(206, 64);
            label2.Name = "label2";
            label2.Size = new Size(143, 20);
            label2.TabIndex = 2;
            label2.Text = "Warehouse Location";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(206, 105);
            label3.Name = "label3";
            label3.Size = new Size(112, 20);
            label3.TabIndex = 3;
            label3.Text = "Manager Name";
            // 
            // tbWhName
            // 
            tbWhName.Location = new Point(365, 20);
            tbWhName.Name = "tbWhName";
            tbWhName.Size = new Size(207, 27);
            tbWhName.TabIndex = 4;
            // 
            // tbWhLoc
            // 
            tbWhLoc.Location = new Point(365, 61);
            tbWhLoc.Name = "tbWhLoc";
            tbWhLoc.Size = new Size(207, 27);
            tbWhLoc.TabIndex = 5;
            // 
            // tbMgrName
            // 
            tbMgrName.Location = new Point(365, 102);
            tbMgrName.Name = "tbMgrName";
            tbMgrName.Size = new Size(207, 27);
            tbMgrName.TabIndex = 6;
            // 
            // btnAdd
            // 
            btnAdd.AutoSize = true;
            btnAdd.Location = new Point(227, 161);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 30);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.AutoSize = true;
            btnUpdate.Location = new Point(345, 161);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 30);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDisplay
            // 
            btnDisplay.AutoSize = true;
            btnDisplay.Location = new Point(463, 161);
            btnDisplay.Name = "btnDisplay";
            btnDisplay.Size = new Size(94, 30);
            btnDisplay.TabIndex = 9;
            btnDisplay.Text = "Display";
            btnDisplay.UseVisualStyleBackColor = true;
            btnDisplay.Click += btnDisplay_Click;
            // 
            // WarehouseForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDisplay);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(tbMgrName);
            Controls.Add(tbWhLoc);
            Controls.Add(tbWhName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "WarehouseForm";
            Text = "WarehouseForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tbWhName;
        private TextBox tbWhLoc;
        private TextBox tbMgrName;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDisplay;
    }
}