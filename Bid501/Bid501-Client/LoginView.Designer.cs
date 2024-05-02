namespace Bid501_Client
{
    partial class LoginView
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
            this.UxLoginButton = new System.Windows.Forms.Button();
            this.PasswordTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UsernameTextbox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uxSendTest = new System.Windows.Forms.Button();
            this.uxSocketStat = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UxLoginButton
            // 
            this.UxLoginButton.Enabled = false;
            this.UxLoginButton.Location = new System.Drawing.Point(318, 234);
            this.UxLoginButton.Name = "UxLoginButton";
            this.UxLoginButton.Size = new System.Drawing.Size(166, 36);
            this.UxLoginButton.TabIndex = 0;
            this.UxLoginButton.Text = "Login";
            this.UxLoginButton.UseVisualStyleBackColor = true;
            this.UxLoginButton.Click += new System.EventHandler(this.UxLoginButton_Click);
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PasswordTextbox.Location = new System.Drawing.Point(318, 172);
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.Size = new System.Drawing.Size(166, 20);
            this.PasswordTextbox.TabIndex = 2;
            this.PasswordTextbox.UseSystemPasswordChar = true;
            this.PasswordTextbox.TextChanged += new System.EventHandler(this.PasswordTextbox_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(254, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password:";
            // 
            // UsernameTextbox
            // 
            this.UsernameTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UsernameTextbox.Location = new System.Drawing.Point(318, 119);
            this.UsernameTextbox.Name = "UsernameTextbox";
            this.UsernameTextbox.Size = new System.Drawing.Size(166, 20);
            this.UsernameTextbox.TabIndex = 1;
            this.UsernameTextbox.TextChanged += new System.EventHandler(this.UsernameTextbox_TextChanged);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.uxSocketStat);
            this.panel1.Controls.Add(this.UxLoginButton);
            this.panel1.Controls.Add(this.PasswordTextbox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.UsernameTextbox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 5;
            // 
            // uxSendTest
            // 
            this.uxSendTest.Location = new System.Drawing.Point(364, 346);
            this.uxSendTest.Name = "uxSendTest";
            this.uxSendTest.Size = new System.Drawing.Size(75, 23);
            this.uxSendTest.TabIndex = 6;
            this.uxSendTest.Text = "Send All Clients";
            this.uxSendTest.UseVisualStyleBackColor = true;
            this.uxSendTest.Click += new System.EventHandler(this.uxSendTest_Click);
            // 
            // uxSocketStat
            // 
            this.uxSocketStat.AutoSize = true;
            this.uxSocketStat.Location = new System.Drawing.Point(343, 416);
            this.uxSocketStat.Name = "uxSocketStat";
            this.uxSocketStat.Size = new System.Drawing.Size(0, 13);
            this.uxSocketStat.TabIndex = 5;
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "LoginView";
            this.Text = "Login Form";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UxLoginButton;
        private System.Windows.Forms.TextBox PasswordTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UsernameTextbox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label uxSocketStat;
    }
}

