namespace Bid501_Client
{
    partial class Form1
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
            this.uxUsernameTB = new System.Windows.Forms.TextBox();
            this.uxPasswordTB = new System.Windows.Forms.TextBox();
            this.uxLoginButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxUsernameTB
            // 
            this.uxUsernameTB.Location = new System.Drawing.Point(296, 130);
            this.uxUsernameTB.Name = "uxUsernameTB";
            this.uxUsernameTB.Size = new System.Drawing.Size(186, 20);
            this.uxUsernameTB.TabIndex = 0;
            // 
            // uxPasswordTB
            // 
            this.uxPasswordTB.Location = new System.Drawing.Point(296, 156);
            this.uxPasswordTB.Name = "uxPasswordTB";
            this.uxPasswordTB.Size = new System.Drawing.Size(186, 20);
            this.uxPasswordTB.TabIndex = 1;
            // 
            // uxLoginButton
            // 
            this.uxLoginButton.Location = new System.Drawing.Point(350, 182);
            this.uxLoginButton.Name = "uxLoginButton";
            this.uxLoginButton.Size = new System.Drawing.Size(75, 23);
            this.uxLoginButton.TabIndex = 2;
            this.uxLoginButton.Text = "LogIn";
            this.uxLoginButton.UseVisualStyleBackColor = true;
            this.uxLoginButton.Click += new System.EventHandler(this.uxLoginButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.uxLoginButton);
            this.Controls.Add(this.uxPasswordTB);
            this.Controls.Add(this.uxUsernameTB);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uxUsernameTB;
        private System.Windows.Forms.TextBox uxPasswordTB;
        private System.Windows.Forms.Button uxLoginButton;
    }
}

