using Bid501_Shared;
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
        private Model model;

        public ServerView(Model model)
        {
            this.model = model;

            InitializeComponent();
            uxListBoxProducts.DataSource = model.Products;
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
