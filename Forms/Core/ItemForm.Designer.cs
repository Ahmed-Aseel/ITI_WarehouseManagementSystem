namespace WarehouseManagementSystem.Forms.Core
{
    partial class ItemForm
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
            btnDisplay = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            tbUnit = new TextBox();
            tbName = new TextBox();
            tbCode = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnDisplay
            // 
            btnDisplay.AutoSize = true;
            btnDisplay.Location = new Point(461, 165);
            btnDisplay.Name = "btnDisplay";
            btnDisplay.Size = new Size(94, 30);
            btnDisplay.TabIndex = 19;
            btnDisplay.Text = "Display";
            btnDisplay.UseVisualStyleBackColor = true;
            btnDisplay.Click += btnDisplay_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.AutoSize = true;
            btnUpdate.Location = new Point(343, 165);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 30);
            btnUpdate.TabIndex = 18;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.AutoSize = true;
            btnAdd.Location = new Point(225, 165);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 30);
            btnAdd.TabIndex = 17;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // tbUnit
            // 
            tbUnit.Location = new Point(350, 105);
            tbUnit.Name = "tbUnit";
            tbUnit.Size = new Size(207, 27);
            tbUnit.TabIndex = 16;
            // 
            // tbName
            // 
            tbName.Location = new Point(350, 64);
            tbName.Name = "tbName";
            tbName.Size = new Size(207, 27);
            tbName.TabIndex = 15;
            // 
            // tbCode
            // 
            tbCode.Location = new Point(350, 23);
            tbCode.Name = "tbCode";
            tbCode.Size = new Size(207, 27);
            tbCode.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(215, 108);
            label3.Name = "label3";
            label3.Size = new Size(116, 20);
            label3.TabIndex = 13;
            label3.Text = "Unit Of Measure";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(215, 67);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 12;
            label2.Text = "Item Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(215, 26);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 11;
            label1.Text = "Item Code";
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
            dataGridView1.TabIndex = 10;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // ItemForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDisplay);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(tbUnit);
            Controls.Add(tbName);
            Controls.Add(tbCode);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "ItemForm";
            Text = "ItemForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDisplay;
        private Button btnUpdate;
        private Button btnAdd;
        private TextBox tbUnit;
        private TextBox tbName;
        private TextBox tbCode;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridView dataGridView1;
    }
}