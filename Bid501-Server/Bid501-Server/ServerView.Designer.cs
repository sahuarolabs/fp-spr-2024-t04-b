namespace Bid501_Server
{
    partial class ServerView
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
            this.uxConnectionText = new System.Windows.Forms.TextBox();
            this.uxConnectionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uxConnectionText
            // 
            this.uxConnectionText.Location = new System.Drawing.Point(116, 15);
            this.uxConnectionText.Name = "uxConnectionText";
            this.uxConnectionText.ReadOnly = true;
            this.uxConnectionText.Size = new System.Drawing.Size(100, 20);
            this.uxConnectionText.TabIndex = 0;
            // 
            // uxConnectionLabel
            // 
            this.uxConnectionLabel.AutoSize = true;
            this.uxConnectionLabel.Location = new System.Drawing.Point(13, 18);
            this.uxConnectionLabel.Name = "uxConnectionLabel";
            this.uxConnectionLabel.Size = new System.Drawing.Size(97, 13);
            this.uxConnectionLabel.TabIndex = 1;
            this.uxConnectionLabel.Text = "Connection Status:";
            // 
            // ServerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.uxConnectionLabel);
            this.Controls.Add(this.uxConnectionText);
            this.Name = "ServerView";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uxConnectionText;
        private System.Windows.Forms.Label uxConnectionLabel;
    }
}

