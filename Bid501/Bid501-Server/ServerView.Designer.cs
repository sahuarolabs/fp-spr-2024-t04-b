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
            this.uxListBoxProducts = new System.Windows.Forms.ListBox();
            this.uxListBoxClients = new System.Windows.Forms.ListBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEnd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxListBoxProducts
            // 
            this.uxListBoxProducts.FormattingEnabled = true;
            this.uxListBoxProducts.Items.AddRange(new object[] {
            "PS4",
            "iPhone 7",
            "Bose SoundSport",
            "Arduino Microcontroller"});
            this.uxListBoxProducts.Location = new System.Drawing.Point(12, 12);
            this.uxListBoxProducts.Name = "uxListBoxProducts";
            this.uxListBoxProducts.Size = new System.Drawing.Size(236, 355);
            this.uxListBoxProducts.TabIndex = 0;
            // 
            // uxListBoxClients
            // 
            this.uxListBoxClients.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxListBoxClients.FormattingEnabled = true;
            this.uxListBoxClients.Location = new System.Drawing.Point(254, 12);
            this.uxListBoxClients.Name = "uxListBoxClients";
            this.uxListBoxClients.Size = new System.Drawing.Size(238, 355);
            this.uxListBoxClients.TabIndex = 1;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(12, 373);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(113, 33);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Add product";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonEnd
            // 
            this.buttonEnd.Location = new System.Drawing.Point(131, 373);
            this.buttonEnd.Name = "buttonEnd";
            this.buttonEnd.Size = new System.Drawing.Size(117, 33);
            this.buttonEnd.TabIndex = 3;
            this.buttonEnd.Text = "End auction";
            this.buttonEnd.UseVisualStyleBackColor = true;
            // 
            // ServerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 430);
            this.Controls.Add(this.buttonEnd);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.uxListBoxClients);
            this.Controls.Add(this.uxListBoxProducts);
            this.Name = "ServerView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin view";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ServerView_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox uxListBoxProducts;
        private System.Windows.Forms.ListBox uxListBoxClients;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEnd;
    }
}

