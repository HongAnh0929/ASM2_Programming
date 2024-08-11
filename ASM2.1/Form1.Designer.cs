namespace ASM2._1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbName = new Label();
            lbPassword = new Label();
            txbName = new TextBox();
            txbPassword = new TextBox();
            btnLogin = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.BackColor = SystemColors.GradientActiveCaption;
            lbName.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbName.Location = new Point(109, 144);
            lbName.Name = "lbName";
            lbName.Size = new Size(173, 27);
            lbName.TabIndex = 0;
            lbName.Text = "Enter your name";
            // 
            // lbPassword
            // 
            lbPassword.AutoSize = true;
            lbPassword.BackColor = SystemColors.GradientActiveCaption;
            lbPassword.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbPassword.Location = new Point(109, 225);
            lbPassword.Name = "lbPassword";
            lbPassword.Size = new Size(161, 27);
            lbPassword.TabIndex = 1;
            lbPassword.Text = "Enter password";
            // 
            // txbName
            // 
            txbName.Font = new Font(".VnCentury SchoolbookH", 12F, FontStyle.Bold);
            txbName.ForeColor = Color.Violet;
            txbName.Location = new Point(302, 127);
            txbName.Multiline = true;
            txbName.Name = "txbName";
            txbName.Size = new Size(355, 57);
            txbName.TabIndex = 2;
            // 
            // txbPassword
            // 
            txbPassword.Font = new Font(".VnCentury SchoolbookH", 12F, FontStyle.Bold);
            txbPassword.ForeColor = Color.Violet;
            txbPassword.Location = new Point(302, 215);
            txbPassword.Multiline = true;
            txbPassword.Name = "txbPassword";
            txbPassword.PasswordChar = '*';
            txbPassword.Size = new Size(355, 53);
            txbPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(231, 323);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(112, 34);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "&Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(515, 323);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(112, 34);
            btnExit.TabIndex = 5;
            btnExit.Text = "&Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Screenshot_2024_07_29_153103;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExit);
            Controls.Add(btnLogin);
            Controls.Add(txbPassword);
            Controls.Add(txbName);
            Controls.Add(lbPassword);
            Controls.Add(lbName);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbName;
        private Label lbPassword;
        private TextBox txbName;
        private TextBox txbPassword;
        private Button btnLogin;
        private Button btnExit;
    }
}
