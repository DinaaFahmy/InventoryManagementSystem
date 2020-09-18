using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_Project
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Store_Click(object sender, EventArgs e)
        {
            Store_Edit f = new Store_Edit();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product_Edit f = new Product_Edit();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Supplier_Edit f = new Supplier_Edit();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Client_Edit f = new Client_Edit();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SupplyPermission f = new SupplyPermission();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            IssuancePermission f = new IssuancePermission();
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TransferringProducts f = new TransferringProducts();
            f.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Report_Store f = new Report_Store();
            f.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Report_Products f = new Report_Products();
            f.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
         
        }

        private void button10_Click(object sender, EventArgs e)
        {
           
        }

        private void button11_Click(object sender, EventArgs e)
        {
           

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            Report_TransferGoods f = new Report_TransferGoods();
            f.Show();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            Report_NearExpiredItems f = new Report_NearExpiredItems();
            f.Show();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            Report_ItemsKeptLongTime f = new Report_ItemsKeptLongTime();
            f.Show();
        }
    }
}
