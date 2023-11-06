namespace NorthwindSupplierManagementSystem
{
    partial class DashBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashBoard));
            panel1 = new Panel();
            button1 = new Button();
            groupBox2 = new GroupBox();
            button6 = new Button();
            button5 = new Button();
            groupBox1 = new GroupBox();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            button7 = new Button();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.AppWorkspace;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(0, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(761, 397);
            panel1.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = Color.Salmon;
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(679, 9);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 10;
            button1.Text = "Log Out";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button4);
            groupBox2.Controls.Add(button6);
            groupBox2.Controls.Add(button5);
            groupBox2.Location = new Point(413, 115);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(341, 239);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Customers And Orders";
            // 
            // button6
            // 
            button6.Location = new Point(38, 103);
            button6.Name = "button6";
            button6.Size = new Size(277, 35);
            button6.TabIndex = 2;
            button6.Text = "Employees";
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(38, 41);
            button5.Name = "button5";
            button5.Size = new Size(277, 35);
            button5.TabIndex = 1;
            button5.Text = "Customers";
            button5.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button7);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Location = new Point(11, 115);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(366, 239);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Suppliers And Products";
            // 
            // button4
            // 
            button4.Location = new Point(38, 175);
            button4.Name = "button4";
            button4.Size = new Size(277, 35);
            button4.TabIndex = 2;
            button4.Text = "View Detailed Orders  Report";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(35, 112);
            button3.Name = "button3";
            button3.Size = new Size(277, 35);
            button3.TabIndex = 1;
            button3.Text = "Products";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(35, 41);
            button2.Name = "button2";
            button2.Size = new Size(277, 35);
            button2.TabIndex = 0;
            button2.Text = "Suppliers";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(8, 9);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(746, 91);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.Highlight;
            label3.Location = new Point(317, 369);
            label3.Name = "label3";
            label3.Size = new Size(162, 15);
            label3.TabIndex = 6;
            label3.Text = "Developed By Thobani Ndlela";
            // 
            // button7
            // 
            button7.Location = new Point(35, 175);
            button7.Name = "button7";
            button7.Size = new Size(277, 35);
            button7.TabIndex = 2;
            button7.Text = "Categories";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // DashBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(761, 396);
            Controls.Add(panel1);
            Name = "DashBoard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DashBoard";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label3;
        private Button button1;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button6;
        private Button button5;
        private Button button7;
    }
}