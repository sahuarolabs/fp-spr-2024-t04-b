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
            this.listBoxProducts = new System.Windows.Forms.ListBox();
            this.listBoxBids = new System.Windows.Forms.ListBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxProducts
            // 
            this.listBoxProducts.FormattingEnabled = true;
            this.listBoxProducts.Items.AddRange(new object[] {
            "PS4",
            "iPhone 7",
            "Bose SoundSport",
            "Arduino Microcontroller"});
            this.listBoxProducts.Location = new System.Drawing.Point(12, 12);
            this.listBoxProducts.Name = "listBoxProducts";
            this.listBoxProducts.Size = new System.Drawing.Size(162, 225);
            this.listBoxProducts.TabIndex = 0;
            // 
            // listBoxBids
            // 
            this.listBoxBids.FormattingEnabled = true;
            this.listBoxBids.Items.AddRange(new object[] {
            "Client 54181145",
            "Client 33711845"});
            this.listBoxBids.Location = new System.Drawing.Point(180, 12);
            this.listBoxBids.Name = "listBoxBids";
            this.listBoxBids.Size = new System.Drawing.Size(162, 225);
            this.listBoxBids.TabIndex = 1;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(140, 243);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Add product";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.button1_Click);
            // 
            // ServerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 293);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.listBoxBids);
            this.Controls.Add(this.listBoxProducts);
            this.Name = "ServerView";
            this.Text = "Admin view";
            this.ResumeLayout(false);

            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ServerView_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxProducts;
        private System.Windows.Forms.ListBox listBoxBids;
        private System.Windows.Forms.Button buttonAdd;
    }
}

