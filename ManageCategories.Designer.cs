namespace NorthwindSupplierManagementSystem
{
    partial class ManageCategories
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageCategories));
            panel1 = new Panel();
            label6 = new Label();
            label1 = new Label();
            txt_CategoryDescription = new TextBox();
            txt_CategoryName = new TextBox();
            button4 = new Button();
            button3 = new Button();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.AppWorkspace;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txt_CategoryDescription);
            panel1.Controls.Add(txt_CategoryName);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(1, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(892, 387);
            panel1.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(584, 135);
            label6.Name = "label6";
            label6.Size = new Size(67, 15);
            label6.TabIndex = 30;
            label6.Text = "Description";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(584, 68);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 26;
            label1.Text = "Category Name";
            // 
            // txt_CategoryDescription
            // 
            txt_CategoryDescription.Location = new Point(584, 163);
            txt_CategoryDescription.Multiline = true;
            txt_CategoryDescription.Name = "txt_CategoryDescription";
            txt_CategoryDescription.Size = new Size(300, 49);
            txt_CategoryDescription.TabIndex = 20;
            // 
            // txt_CategoryName
            // 
            txt_CategoryName.Location = new Point(584, 95);
            txt_CategoryName.Name = "txt_CategoryName";
            txt_CategoryName.Size = new Size(300, 23);
            txt_CategoryName.TabIndex = 16;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.ActiveCaption;
            button4.Location = new Point(584, 306);
            button4.Name = "button4";
            button4.Size = new Size(300, 31);
            button4.TabIndex = 14;
            button4.Text = "Update Category";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.MintCream;
            button3.Location = new Point(584, 244);
            button3.Name = "button3";
            button3.Size = new Size(297, 31);
            button3.TabIndex = 13;
            button3.Text = "Add Category";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(11, 68);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(529, 269);
            dataGridView1.TabIndex = 12;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaption;
            button2.Location = new Point(702, 11);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 11;
            button2.Text = "DashBoard";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Salmon;
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(783, 11);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 10;
            button1.Text = "Log Out";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(11, 9);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(873, 43);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.Highlight;
            label3.Location = new Point(360, 360);
            label3.Name = "label3";
            label3.Size = new Size(162, 15);
            label3.TabIndex = 6;
            label3.Text = "Developed By Thobani Ndlela";
            // 
            // ManageCategories
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(894, 385);
            Controls.Add(panel1);
            Name = "ManageCategories";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ManageCategories";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label6;
        private Label label1;
        private TextBox txt_CategoryDescription;
        private TextBox txt_CategoryName;
        private Button button4;
        private Button button3;
        private DataGridView dataGridView1;
        private Button button2;
        private Button button1;
        private PictureBox pictureBox1;
        private Label label3;
    }
}