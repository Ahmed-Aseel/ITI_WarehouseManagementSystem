namespace WarehouseManagementSystem.Forms.Core
{
    partial class BusinessPartnerForm
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
            tbPhone = new TextBox();
            tbName = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            comboBox1 = new ComboBox();
            tbEmail = new TextBox();
            tbMobile = new TextBox();
            tbFax = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            tbWebSite = new TextBox();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnDisplay
            // 
            btnDisplay.AutoSize = true;
            btnDisplay.Location = new Point(484, 185);
            btnDisplay.Name = "btnDisplay";
            btnDisplay.Size = new Size(94, 30);
            btnDisplay.TabIndex = 29;
            btnDisplay.Text = "Display";
            btnDisplay.UseVisualStyleBackColor = true;
            btnDisplay.Click += btnDisplay_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.AutoSize = true;
            btnUpdate.Location = new Point(366, 185);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 30);
            btnUpdate.TabIndex = 28;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.AutoSize = true;
            btnAdd.Location = new Point(248, 185);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 30);
            btnAdd.TabIndex = 27;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // tbPhone
            // 
            tbPhone.Location = new Point(140, 87);
            tbPhone.Name = "tbPhone";
            tbPhone.Size = new Size(207, 27);
            tbPhone.TabIndex = 26;
            // 
            // tbName
            // 
            tbName.Location = new Point(140, 5);
            tbName.Name = "tbName";
            tbName.Size = new Size(207, 27);
            tbName.TabIndex = 24;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(5, 90);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 23;
            label3.Text = "Phone";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(5, 49);
            label2.Name = "label2";
            label2.Size = new Size(40, 20);
            label2.TabIndex = 22;
            label2.Text = "Type";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 8);
            label1.Name = "label1";
            label1.Size = new Size(99, 20);
            label1.TabIndex = 21;
            label1.Text = "Partner Name";
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
            dataGridView1.TabIndex = 20;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(140, 45);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(207, 28);
            comboBox1.TabIndex = 30;
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(507, 5);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(207, 27);
            tbEmail.TabIndex = 36;
            // 
            // tbMobile
            // 
            tbMobile.Location = new Point(140, 128);
            tbMobile.Name = "tbMobile";
            tbMobile.Size = new Size(207, 27);
            tbMobile.TabIndex = 35;
            // 
            // tbFax
            // 
            tbFax.Location = new Point(507, 46);
            tbFax.Name = "tbFax";
            tbFax.PlaceholderText = "Optional";
            tbFax.Size = new Size(207, 27);
            tbFax.TabIndex = 34;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(414, 8);
            label6.Name = "label6";
            label6.Size = new Size(46, 20);
            label6.TabIndex = 33;
            label6.Text = "Email";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(5, 131);
            label5.Name = "label5";
            label5.Size = new Size(56, 20);
            label5.TabIndex = 32;
            label5.Text = "Mobile";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(414, 49);
            label4.Name = "label4";
            label4.Size = new Size(30, 20);
            label4.TabIndex = 31;
            label4.Text = "Fax";
            // 
            // tbWebSite
            // 
            tbWebSite.Location = new Point(507, 87);
            tbWebSite.Name = "tbWebSite";
            tbWebSite.PlaceholderText = "Optional";
            tbWebSite.Size = new Size(207, 27);
            tbWebSite.TabIndex = 38;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(414, 90);
            label7.Name = "label7";
            label7.Size = new Size(62, 20);
            label7.TabIndex = 37;
            label7.Text = "Website";
            // 
            // BusinessPartnerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tbWebSite);
            Controls.Add(label7);
            Controls.Add(tbEmail);
            Controls.Add(tbMobile);
            Controls.Add(tbFax);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(comboBox1);
            Controls.Add(btnDisplay);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(tbPhone);
            Controls.Add(tbName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "BusinessPartnerForm";
            Text = "BusinessPartnerForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDisplay;
        private Button btnUpdate;
        private Button btnAdd;
        private TextBox tbPhone;
        private TextBox tbName;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridView dataGridView1;
        private ComboBox comboBox1;
        private TextBox tbEmail;
        private TextBox tbMobile;
        private TextBox tbFax;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox tbWebSite;
        private Label label7;
    }
}