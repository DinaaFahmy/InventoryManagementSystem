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
    public partial class Report_TransferGoods : Form
    {
        DataContext db = new DataContext();
        DataTable table = new DataTable("TransferringGoods");
        public Report_TransferGoods()
        {
            InitializeComponent();
            
            foreach (var s in db.Stores)
            {
                checkedListBox1.Items.Add(s.StoreName);
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
           
            var date_from = fromDate.Value.ToString().Substring(0, 10);
            var date_to = toDate.Value.ToString().Substring(0, 10);
            SqlDataReader reader;
            sqlConnection1.Open();
            reader = sqlCommand1.ExecuteReader();

            
            table.Load(reader);
            DataView dv;

            dv = new DataView(table, "TransferringDate >= '" + date_from + "' AND TransferringDate <= '" + date_to + "'", "ProductID Desc", DataViewRowState.CurrentRows);

            dataGridView1.DataSource = dv;
            sqlConnection1.Close();
            reader.Close();
            sqlConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
       
           }
           
    }
}
