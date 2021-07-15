using CoreShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoreShop
{
    public partial class MainForm : Form
    {
        DatabaseContext _ctx;
        public MainForm()
        {
            InitializeComponent();
            InitializeData();
        }
        private void InitializeData()
        {
            _ctx = new DatabaseContext();

            listBoxProducts.DisplayMember = "Name";
            listBoxProducts.ValueMember = "Id";
            listBoxProducts.DataSource = _ctx.Products.ToList();
        }

    }
}
