﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bid501_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private ClientCommCtrl commCtrl = new ClientCommCtrl();

        private void uxLoginButton_Click(object sender, EventArgs e)
        {
            commCtrl.SendMessage("" + uxUsernameTB + uxPasswordTB);
        }
    }
}
