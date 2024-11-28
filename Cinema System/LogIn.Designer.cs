namespace Cinema_System
{
    partial class LogIn
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
            TitleLabel = new Label();
            UNameTextLabel = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            PassLabel = new Label();
            logInButt = new Button();
            backButton = new Button();
            SuspendLayout();
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.BackColor = Color.Transparent;
            TitleLabel.Font = new Font("Cascadia Code", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TitleLabel.ForeColor = Color.Red;
            TitleLabel.Location = new Point(589, 380);
            TitleLabel.Margin = new Padding(4, 0, 4, 0);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(418, 95);
            TitleLabel.TabIndex = 0;
            TitleLabel.Text = "PinoyFlix";
            // 
            // UNameTextLabel
            // 
            UNameTextLabel.AutoSize = true;
            UNameTextLabel.BackColor = Color.Transparent;
            UNameTextLabel.Font = new Font("Franklin Gothic Medium", 11F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            UNameTextLabel.ForeColor = Color.Red;
            UNameTextLabel.Location = new Point(522, 501);
            UNameTextLabel.Margin = new Padding(4, 0, 4, 0);
            UNameTextLabel.Name = "UNameTextLabel";
            UNameTextLabel.Size = new Size(138, 28);
            UNameTextLabel.TabIndex = 1;
            UNameTextLabel.Text = "User Name: ";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(649, 499);
            textBox1.Margin = new Padding(4, 5, 4, 5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(304, 31);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(649, 548);
            textBox2.Margin = new Padding(4, 5, 4, 5);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(304, 31);
            textBox2.TabIndex = 4;
            // 
            // PassLabel
            // 
            PassLabel.AutoSize = true;
            PassLabel.BackColor = Color.Transparent;
            PassLabel.Font = new Font("Franklin Gothic Medium", 11F, FontStyle.Bold | FontStyle.Italic);
            PassLabel.ForeColor = Color.Red;
            PassLabel.Location = new Point(526, 548);
            PassLabel.Margin = new Padding(4, 0, 4, 0);
            PassLabel.Name = "PassLabel";
            PassLabel.Size = new Size(132, 28);
            PassLabel.TabIndex = 3;
            PassLabel.Text = "Password : ";
            // 
            // logInButt
            // 
            logInButt.Font = new Font("Franklin Gothic Medium", 11F, FontStyle.Bold | FontStyle.Italic);
            logInButt.Location = new Point(526, 592);
            logInButt.Margin = new Padding(4, 5, 4, 5);
            logInButt.Name = "logInButt";
            logInButt.Size = new Size(427, 38);
            logInButt.TabIndex = 5;
            logInButt.Text = "Log In";
            logInButt.UseVisualStyleBackColor = true;
            logInButt.Click += logInButt_Click;
            // 
            // backButton
            // 
            backButton.Font = new Font("Franklin Gothic Medium", 11F, FontStyle.Bold | FontStyle.Italic);
            backButton.Location = new Point(17, 20);
            backButton.Margin = new Padding(4, 5, 4, 5);
            backButton.Name = "backButton";
            backButton.Size = new Size(107, 38);
            backButton.TabIndex = 6;
            backButton.Text = "Exit";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // LogIn
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._462558345_930185608568689_4640817194369959952_n;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1463, 1106);
            ControlBox = false;
            Controls.Add(backButton);
            Controls.Add(logInButt);
            Controls.Add(textBox2);
            Controls.Add(PassLabel);
            Controls.Add(textBox1);
            Controls.Add(UNameTextLabel);
            Controls.Add(TitleLabel);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "LogIn";
            StartPosition = FormStartPosition.CenterScreen;
            Load += LogIn_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TitleLabel;
        private Label UNameTextLabel;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label PassLabel;
        private Button logInButt;
        private Button backButton;
    }
}