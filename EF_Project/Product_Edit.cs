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
    public partial class Product_Edit : Form
    {
        List<Panel> panels = new List<Panel>();
        int index;
        public Product_Edit()
        {
            InitializeComponent();
            panels.Add(panel1);
            panels.Add(panel2);
            panels[index].BringToFront();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                Product p = new Product();
                p.ProductID = int.Parse(txt_Code.Text);
                p.ProductName = txt_Name.Text;
                ProductsMeasurement m = new ProductsMeasurement();
                m.ProductID = int.Parse(txt_Code.Text);
                m.Measurement = txt_Measure.Text;
                DataContext db = new DataContext();
                if (db.Products.Select(a => a.ProductID).Contains(p.ProductID) == true &&
                    db.Products.Select(b => b.ProductName).Contains(p.ProductName) == true)
                {
                    db.ProductsMeasurements.Add(m);
                    db.SaveChanges();
                    MessageBox.Show("Product Added Successfully");
                }
                else
                {
                    db.Products.Add(p);
                    db.ProductsMeasurements.Add(m);
                    db.SaveChanges();
                    txt_Name.Text = string.Empty;
                    txt_Code.Text = string.Empty;
                    txt_Measure.Text = string.Empty;
                    MessageBox.Show("Product Added Successfully");
                }
        }
            catch(Exception)
            {
                MessageBox.Show("Invalid Input");
            }
}

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            DataContext db = new DataContext();
            int id = Convert.ToInt32(cmb_id.SelectedItem);
            var data = (from i in db.Products
                        where id == i.ProductID
                        select i).First();
            data.ProductName = txt_pName.Text;            
            db.SaveChanges();
            txt_pName.Text = string.Empty;            
            MessageBox.Show("Product Edited Successfully");
        }

        private void button1_Click(object sender, EventArgs e)//add
        {

            if (index > 0)
            {
                panels[--index].BringToFront();
            }
        }

        private void button2_Click(object sender, EventArgs e)//edit
        {
           
            if (index < panels.Count - 1)
            {
                panels[++index].BringToFront();
            }
            DataContext db = new DataContext();
            List<int> lst = new List<int>();
            lst = db.Products.Select(a => a.ProductID).ToList();
            foreach (var i in lst)
            {
                cmb_id.Items.Add(i);
            }
        }

        private void cmb_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_measure.Items.Clear();
            DataContext db = new DataContext();
            List<ProductsMeasurement> measurements = new List<ProductsMeasurement>();
            List<string> lst = new List<string>();
            measurements = db.ProductsMeasurements.ToList();
           
            if (db.ProductsMeasurements.Select(a => a.ProductID).Contains(Convert.ToInt32(cmb_id.SelectedItem))==true)
            {
                lst = (from x in measurements where Convert.ToInt32(cmb_id.SelectedItem) == x.ProductID select x.Measurement).ToList();
                foreach (var i in lst) 
                {
                    cmb_measure.Items.Add(i);
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
