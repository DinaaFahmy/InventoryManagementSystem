using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_Project
{
    public partial class Report_Products : Form
    {
        DataContext db = new DataContext();
        DataView dv=new DataView();
        public Report_Products()
        {
            InitializeComponent();
            
            cmb_prodName.DisplayMember = "Text";
            cmb_prodName.ValueMember = "Value";

            List<Product> products = new List<Product>();
            products = db.Products.ToList();
            foreach (var p in products)
            {
                cmb_prodName.Items.Add(new { Text = p.ProductName, Value = p.ProductID });
            }  
            foreach(var s in db.Stores)
            {
                cmb_Store.Items.Add(s.StoreName);
            }
          
        }
        public override string ToString()
        {
            return Text;
        }
        private void cmb_store_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_Click(object sender, EventArgs e)
        {
            DataContext db = new DataContext();
            var date_from = fromDate.Value.ToString().Substring(0, 10);
            var date_to = toDate.Value.ToString().Substring(0, 10);
            SqlDataReader reader;
            sqlConnection1.Open();
            reader = sqlCommand1.ExecuteReader();

            DataTable table = new DataTable("products");
            table.Load(reader);
            DataView dv;
            
            dv = new DataView(table, "DateOfAdjust >= '" + date_from + "' AND DateOfAdjust <= '" + date_to + "'", "StoreName Desc", DataViewRowState.CurrentRows);
            
            dataGridView1.DataSource = dv;
            sqlConnection1.Close();
            reader.Close();
            sqlConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fromDate.Value = DateTime.Now;
            toDate.Value = DateTime.Now;
        }

        private void cmb_Store_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var lst = (from i in db.Permissions where i.PermissionType == "Supply            " select i.PermissionNumber).ToList();
            int prodID = (cmb_prodName.SelectedItem as dynamic).Value;
            string store = cmb_Store.SelectedItem.ToString();
            var mlist = (from i in db.ProductsMeasurements where i.ProductID == prodID select i.Measurement).ToList();
            SqlDataReader reader;
            sqlConnection1.Open();
            reader = sqlCommand1.ExecuteReader();

            DataTable table = new DataTable("products");
            table.Load(reader);

            listBox1.Items.Clear();
            foreach (var x in mlist)
            {
                if (db.ProductsMeasurements.Select(a => a.ProductID).Contains(prodID))
                {
                    listBox1.Items.Add(x);
                }
            }


            dv = new DataView(table, "ProductID = '" + prodID + "' AND StoreName = '" + store + "'", "ProductID Desc", DataViewRowState.CurrentRows);

            dataGridView1.DataSource = dv;
            sqlConnection1.Close();
        }
    }
}
