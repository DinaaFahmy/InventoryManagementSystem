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
    public partial class Report_Store : Form
    {
       
        public Report_Store()
        {           
            InitializeComponent();
            DataContext db = new DataContext();
            foreach (var i in db.Stores)
            {
                cmb_store.Items.Add(i.StoreName);
            }

        }

        private void cmb_store_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataContext db = new DataContext();
            //all permission numbers that are of type : Issuance , used to deduct this amount of products from the store
            var lst = (from i in db.Permissions where i.PermissionType == "Issuance            " select i.PermissionNumber).ToList();
           
            List<int> qnt = new List<int>();
            List<int> prodID = new List<int>();
            string storeName = cmb_store.SelectedItem.ToString();
            SqlDataReader reader;
            sqlConnection1.Open();
            reader = sqlCommand1.ExecuteReader();

            DataTable table = new DataTable("store_table");
            table.Load(reader);
            DataView dv;
            dv = new DataView(table, "StoreName = '" + storeName + "'", "StoreName Desc", DataViewRowState.CurrentRows);
            dataGridView1.DataSource = dv;

            foreach (var x in db.Permission_Product)
            {
               if(lst.Contains(x.PermissionID))
                {
                    prodID.Add(x.ProductID);
                    qnt.Add(x.ProductQuantity); 
                }               
            }
           foreach(var x in db.Store_Products)
            {
                if (prodID.Contains(x.ProductID) && x.StoreName == storeName)
                {
                    foreach (var y in qnt)
                    {
                        x.Quantity = x.Quantity - y;
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            if (table.Rows[i][3].Equals(x.ProductID))
                            {
                               table.Rows[i][5]=x.Quantity;
                            }
                        }
                    }
                }
            }
        
            sqlConnection1.Close();
            reader.Close();
            sqlConnection1.Close();
        }

        private void prodDate_ValueChanged(object sender, EventArgs e)
        {
        }

        private void btn_Click(object sender, EventArgs e)
        {
            DataContext db = new DataContext();
            var date_from = fromDate.Value.ToString().Substring(0,10);
            var date_to = toDate.Value.ToString().Substring(0,10);
            SqlDataReader reader;
            sqlConnection1.Open();
            reader = sqlCommand1.ExecuteReader();
            
            DataTable table = new DataTable("store_table");
            table.Load(reader);
            DataView dv; 

            dv = new DataView(table, "DateOfAdjust >= '" + date_from + "' AND DateOfAdjust <= '" + date_to + "'", "StoreName Desc", DataViewRowState.CurrentRows);
            dataGridView1.DataSource = dv;
            sqlConnection1.Close();
            reader.Close();
            sqlConnection1.Close();
        }
    }
}
