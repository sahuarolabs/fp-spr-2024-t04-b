﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bid501_Server
{
    public partial class ServerView : Form
    {

        private ServerCommCtrl serverCommCtrl;

        public ServerView()
        {
            InitializeComponent();
            serverCommCtrl = new ServerCommCtrl();
        }

        private void ServerView_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        ///REMINDER: necessary to add a Form.Closed event handler to closs the websocket server in ServerCommCtrl
    }
}
