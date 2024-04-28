namespace Bid501_Client
{
    partial class BidView
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
            this.UxLogoutButton = new System.Windows.Forms.Button();
            this.UxProductListBox = new System.Windows.Forms.ListBox();
            this.UxProductName = new System.Windows.Forms.Label();
            this.UxStatusLabel = new System.Windows.Forms.Label();
            this.UxCurrentPriceTextBox = new System.Windows.Forms.Label();
            this.UxNewBidTextBox = new System.Windows.Forms.TextBox();
            this.UxPlaceBid = new System.Windows.Forms.Button();
            this.UxBidCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UxLogoutButton
            // 
            this.UxLogoutButton.Location = new System.Drawing.Point(13, 415);
            this.UxLogoutButton.Name = "UxLogoutButton";
            this.UxLogoutButton.Size = new System.Drawing.Size(75, 23);
            this.UxLogoutButton.TabIndex = 0;
            this.UxLogoutButton.Text = "Logout";
            this.UxLogoutButton.UseVisualStyleBackColor = true;
            this.UxLogoutButton.Click += new System.EventHandler(this.UxLogoutButton_Click);
            // 
            // UxProductListBox
            // 
            this.UxProductListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UxProductListBox.FormattingEnabled = true;
            this.UxProductListBox.ItemHeight = 24;
            this.UxProductListBox.Location = new System.Drawing.Point(547, 17);
            this.UxProductListBox.Name = "UxProductListBox";
            this.UxProductListBox.Size = new System.Drawing.Size(241, 412);
            this.UxProductListBox.TabIndex = 1;
            this.UxProductListBox.SelectedIndexChanged += new System.EventHandler(this.UxProductListBox_SelectedIndexChanged);
            // 
            // UxProductName
            // 
            this.UxProductName.AutoSize = true;
            this.UxProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UxProductName.Location = new System.Drawing.Point(2, 9);
            this.UxProductName.Name = "UxProductName";
            this.UxProductName.Size = new System.Drawing.Size(86, 31);
            this.UxProductName.TabIndex = 2;
            this.UxProductName.Text = "Name";
            // 
            // UxStatusLabel
            // 
            this.UxStatusLabel.AutoSize = true;
            this.UxStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UxStatusLabel.Location = new System.Drawing.Point(8, 71);
            this.UxStatusLabel.Name = "UxStatusLabel";
            this.UxStatusLabel.Size = new System.Drawing.Size(60, 24);
            this.UxStatusLabel.TabIndex = 3;
            this.UxStatusLabel.Text = "Status";
            // 
            // UxCurrentPriceTextBox
            // 
            this.UxCurrentPriceTextBox.AutoSize = true;
            this.UxCurrentPriceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UxCurrentPriceTextBox.Location = new System.Drawing.Point(1, 248);
            this.UxCurrentPriceTextBox.Name = "UxCurrentPriceTextBox";
            this.UxCurrentPriceTextBox.Size = new System.Drawing.Size(89, 37);
            this.UxCurrentPriceTextBox.TabIndex = 4;
            this.UxCurrentPriceTextBox.Text = "Price";
            // 
            // UxNewBidTextBox
            // 
            this.UxNewBidTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UxNewBidTextBox.Location = new System.Drawing.Point(44, 291);
            this.UxNewBidTextBox.Name = "UxNewBidTextBox";
            this.UxNewBidTextBox.Size = new System.Drawing.Size(370, 62);
            this.UxNewBidTextBox.TabIndex = 5;
            this.UxNewBidTextBox.Text = "0.00";
            // 
            // UxPlaceBid
            // 
            this.UxPlaceBid.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UxPlaceBid.Location = new System.Drawing.Point(420, 291);
            this.UxPlaceBid.Name = "UxPlaceBid";
            this.UxPlaceBid.Size = new System.Drawing.Size(121, 62);
            this.UxPlaceBid.TabIndex = 6;
            this.UxPlaceBid.Text = "Bid";
            this.UxPlaceBid.UseVisualStyleBackColor = true;
            this.UxPlaceBid.Click += new System.EventHandler(this.UxPlaceBid_Click);
            // 
            // UxBidCount
            // 
            this.UxBidCount.AutoSize = true;
            this.UxBidCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UxBidCount.Location = new System.Drawing.Point(416, 268);
            this.UxBidCount.Name = "UxBidCount";
            this.UxBidCount.Size = new System.Drawing.Size(63, 20);
            this.UxBidCount.TabIndex = 7;
            this.UxBidCount.Text = "(# Bids)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 55);
            this.label1.TabIndex = 8;
            this.label1.Text = "$";
            // 
            // BidView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UxBidCount);
            this.Controls.Add(this.UxPlaceBid);
            this.Controls.Add(this.UxNewBidTextBox);
            this.Controls.Add(this.UxCurrentPriceTextBox);
            this.Controls.Add(this.UxStatusLabel);
            this.Controls.Add(this.UxProductName);
            this.Controls.Add(this.UxProductListBox);
            this.Controls.Add(this.UxLogoutButton);
            this.Controls.Add(this.label1);
            this.Name = "BidView";
            this.Text = "BidView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UxLogoutButton;
        private System.Windows.Forms.ListBox UxProductListBox;
        private System.Windows.Forms.Label UxProductName;
        private System.Windows.Forms.Label UxStatusLabel;
        private System.Windows.Forms.Label UxCurrentPriceTextBox;
        private System.Windows.Forms.TextBox UxNewBidTextBox;
        private System.Windows.Forms.Button UxPlaceBid;
        private System.Windows.Forms.Label UxBidCount;
        private System.Windows.Forms.Label label1;
    }
}