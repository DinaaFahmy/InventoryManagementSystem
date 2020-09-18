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
    public partial class Report_ItemsKeptLongTime : Form
    {
        DataContext db = new DataContext();
        DataTable table = new DataTable("items");
        public Report_ItemsKeptLongTime()
        {
            InitializeComponent();
            cmb_months.DisplayMember = "Text";
            cmb_months.ValueMember = "Value";


            cmb_months.Items.Add(new { Text = "More than 12 Months", Value = 12 });
            cmb_months.Items.Add(new { Text = "More than 24 Months", Value = 24 });
            cmb_months.Items.Add(new { Text = "More than 36 Months", Value = 36 });
            //SqlDataReader reader;
            //sqlConnection1.Open();
            //reader = sqlCommand1.ExecuteReader();
            //table.Load(reader);
            //int n = 0;
            //for (int i = 0; i < table.Rows.Count; i++)
            //{
            //    DateTime d = Convert.ToDateTime(table.Rows[i][4]);
            //    d.AddMonths(Convert.ToInt32(table.Rows[i][5]));
            //    table.Rows[i][2] = d.AddMonths(Convert.ToInt32(table.Rows[i][5])).ToString().Substring(0, 9);
            //    n = ((Convert.ToDateTime(table.Rows[i][2]).Year - DateTime.Now.Year) * 12) + Convert.ToDateTime(table.Rows[i][4]).Month - DateTime.Now.Month;
            //    table.Rows[i][3] = n;
            //}
            //dataGridView1.DataSource = table;
            //sqlConnection1.Close();
            //reader.Close();
            //sqlConnection1.Close();
        }

        private void cmb_months_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int m = (cmb_months.SelectedItem as dynamic).Value;
            SqlDataReader reader;
            sqlConnection1.Open();
            reader = sqlCommand1.ExecuteReader();
            table.Load(reader);
            int n = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DateTime d = Convert.ToDateTime(table.Rows[i][4]);
                d.AddMonths(Convert.ToInt32(table.Rows[i][5]));
                table.Rows[i][2] = d.AddMonths(Convert.ToInt32(table.Rows[i][5])).ToString().Substring(0, 9);
                n = ((Convert.ToDateTime(table.Rows[i][2]).Year - DateTime.Now.Year) * 12) + Convert.ToDateTime(table.Rows[i][4]).Month - DateTime.Now.Month;
                table.Rows[i][3] = n;
            }
            DataView dv;
            dv = new DataView(table, "RemainingMonths > '" + m + "' ", "ProductID Desc", DataViewRowState.CurrentRows);

            dataGridView1.DataSource = dv;
            sqlConnection1.Close();
            reader.Close();
            sqlConnection1.Close();
        }
    }
}
