namespace Cinema_System
{
    partial class AdminTab
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
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            button4 = new Button();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            openFileDialog1 = new OpenFileDialog();
            button2 = new Button();
            movIDTextBox = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(574, 463);
            button1.Name = "button1";
            button1.Size = new Size(111, 33);
            button1.TabIndex = 0;
            button1.Text = "Log out";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(48, 315);
            label1.Name = "label1";
            label1.Size = new Size(194, 32);
            label1.TabIndex = 3;
            label1.Text = "Add New Movie:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ButtonHighlight;
            label2.Font = new Font("Calibri", 14F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(289, -1);
            label2.Name = "label2";
            label2.Size = new Size(97, 35);
            label2.TabIndex = 5;
            label2.Text = "ADMIN";
            label2.Click += label2_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(123, 219);
            button4.Name = "button4";
            button4.Size = new Size(148, 60);
            button4.TabIndex = 27;
            button4.Text = "Confirm";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(94, 185);
            label4.Name = "label4";
            label4.Size = new Size(0, 25);
            label4.TabIndex = 9;
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.Location = new Point(44, 153);
            label5.Name = "label5";
            label5.Size = new Size(118, 32);
            label5.TabIndex = 11;
            label5.Text = "Movie ID:";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label6.Location = new Point(61, 83);
            label6.Name = "label6";
            label6.Size = new Size(181, 32);
            label6.TabIndex = 13;
            label6.Text = "Remove Movie:";
            label6.Click += label6_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(123, 376);
            button2.Name = "button2";
            button2.Size = new Size(148, 60);
            button2.TabIndex = 27;
            button2.Text = "Edit";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // movIDTextBox
            // 
            movIDTextBox.Location = new Point(168, 156);
            movIDTextBox.Name = "movIDTextBox";
            movIDTextBox.Size = new Size(150, 31);
            movIDTextBox.TabIndex = 28;
            // 
            // AdminTab
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(706, 508);
            Controls.Add(movIDTextBox);
            Controls.Add(button2);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(button4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Cursor = Cursors.Default;
            FormBorderStyle = FormBorderStyle.None;
            Name = "AdminTab";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += AdminTab_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private Button button4;
        private Label label4;
        private Label label5;
        private Label label6;
        private OpenFileDialog openFileDialog1;
        private Button button2;
        private TextBox movIDTextBox;
    }
}