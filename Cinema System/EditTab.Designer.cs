namespace Cinema_System
{
    partial class EditTab
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
            titleTextBox = new TextBox();
            label3 = new Label();
            label4 = new Label();
            button2 = new Button();
            button3 = new Button();
            priceTextBox = new TextBox();
            screeningRoomTextBox = new TextBox();
            Room = new Label();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(523, 404);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 0;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label1.Location = new Point(39, 52);
            label1.Name = "label1";
            label1.Size = new Size(150, 29);
            label1.TabIndex = 1;
            label1.Text = "Movie Title:";
            label1.Click += label1_Click;
            // 
            // titleTextBox
            // 
            titleTextBox.Location = new Point(244, 52);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.Size = new Size(150, 31);
            titleTextBox.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label3.Location = new Point(31, 112);
            label3.Name = "label3";
            label3.Size = new Size(158, 29);
            label3.TabIndex = 4;
            label3.Text = "Movie Price:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label4.Location = new Point(36, 363);
            label4.Name = "label4";
            label4.Size = new Size(169, 29);
            label4.TabIndex = 5;
            label4.Text = "Movie Image:";
            label4.Click += label4_Click;
            // 
            // button2
            // 
            button2.Location = new Point(657, 404);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 6;
            button2.Text = "Save";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(211, 363);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 7;
            button3.Text = "Insert";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // priceTextBox
            // 
            priceTextBox.Location = new Point(244, 112);
            priceTextBox.Name = "priceTextBox";
            priceTextBox.Size = new Size(150, 31);
            priceTextBox.TabIndex = 9;
            // 
            // screeningRoomTextBox
            // 
            screeningRoomTextBox.Location = new Point(244, 172);
            screeningRoomTextBox.Name = "screeningRoomTextBox";
            screeningRoomTextBox.Size = new Size(150, 31);
            screeningRoomTextBox.TabIndex = 11;
            // 
            // Room
            // 
            Room.AutoSize = true;
            Room.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            Room.Location = new Point(39, 172);
            Room.Name = "Room";
            Room.Size = new Size(96, 29);
            Room.TabIndex = 10;
            Room.Text = "Room: ";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(244, 231);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(300, 31);
            dateTimePicker1.TabIndex = 12;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(244, 295);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(300, 31);
            dateTimePicker2.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label5.Location = new Point(36, 231);
            label5.Name = "label5";
            label5.Size = new Size(142, 29);
            label5.TabIndex = 14;
            label5.Text = "Start Date: ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label6.Location = new Point(39, 295);
            label6.Name = "label6";
            label6.Size = new Size(127, 29);
            label6.TabIndex = 15;
            label6.Text = "End Date:";
            // 
            // EditTab
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(screeningRoomTextBox);
            Controls.Add(Room);
            Controls.Add(priceTextBox);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(titleTextBox);
            Controls.Add(label1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "EditTab";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EditTab";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private TextBox titleTextBox;
        private Label label3;
        private Label label4;
        private Button button2;
        private Button button3;
        private TextBox priceTextBox;
        private TextBox screeningRoomTextBox;
        private Label Room;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label label5;
        private Label label6;
    }
}