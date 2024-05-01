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
    public partial class AddProductView : Form
    {
        public Product SelectedProd { get; private set; }

        public AddProductView(List<Product> products)
        {
            InitializeComponent();
            listBoxProducts.DataSource = products;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Product selected = (Product) listBoxProducts.SelectedItem;

            if (selected == null)
                MessageBox.Show("No product selected!", "Error");
            else
            {
                SelectedProd = selected;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
