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
    public partial class Report_NearExpiredItems : Form
    {
        DataContext db = new DataContext();
        DataTable table = new DataTable("items");
        public Report_NearExpiredItems()
        {
            InitializeComponent();
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
            dataGridView1.DataSource = table;
            sqlConnection1.Close();
            reader.Close();
            sqlConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
