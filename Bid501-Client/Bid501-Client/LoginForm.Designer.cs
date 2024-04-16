namespace Bid501_Client
{
    partial class LoginForm
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.UxLoginButton = new System.Windows.Forms.Button();
            this.UxUsernameTextBox = new System.Windows.Forms.TextBox();
            this.UxPasswordTextBox = new System.Windows.Forms.TextBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UxLoginButton
            // 
            this.UxLoginButton.Location = new System.Drawing.Point(319, 351);
            this.UxLoginButton.Name = "UxLoginButton";
            this.UxLoginButton.Size = new System.Drawing.Size(121, 51);
            this.UxLoginButton.TabIndex = 0;
            this.UxLoginButton.Text = "Login";
            this.UxLoginButton.UseVisualStyleBackColor = true;
            this.UxLoginButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // UxUsernameTextBox
            // 
            this.UxUsernameTextBox.Location = new System.Drawing.Point(234, 165);
            this.UxUsernameTextBox.Name = "UxUsernameTextBox";
            this.UxUsernameTextBox.Size = new System.Drawing.Size(311, 22);
            this.UxUsernameTextBox.TabIndex = 1;
            // 
            // UxPasswordTextBox
            // 
            this.UxPasswordTextBox.Location = new System.Drawing.Point(234, 232);
            this.UxPasswordTextBox.Name = "UxPasswordTextBox";
            this.UxPasswordTextBox.Size = new System.Drawing.Size(311, 22);
            this.UxPasswordTextBox.TabIndex = 2;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(158, 171);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(70, 16);
            this.UsernameLabel.TabIndex = 3;
            this.UsernameLabel.Text = "Username";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(161, 237);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(67, 16);
            this.PasswordLabel.TabIndex = 4;
            this.PasswordLabel.Text = "Password";
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.UxPasswordTextBox);
            this.Controls.Add(this.UxUsernameTextBox);
            this.Controls.Add(this.UxLoginButton);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(800, 450);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UxLoginButton;
        private System.Windows.Forms.TextBox UxUsernameTextBox;
        private System.Windows.Forms.TextBox UxPasswordTextBox;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label PasswordLabel;
    }
}
