using System;
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
        //Refer to comment in contructor
        private ServerCommCtrl serverCommCtrl;


        public ServerView()
        {
            InitializeComponent();
            // May need to axe this, since the web socket server opens a new ServerCommCtrl() on program init.
            //serverCommCtrl = new ServerCommCtrl();
            //uxListBoxClients.DataSource = serverCommCtrl.GetClients();
        }

        private void ServerView_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public static void RefreshView()
        {
           
        }

    }
}
