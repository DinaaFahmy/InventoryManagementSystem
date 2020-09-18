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
    public partial class Supplier_Edit : Form
    {
        List<Panel> panels = new List<Panel>();
        int index;
        public Supplier_Edit()
        {
            InitializeComponent();
            panels.Add(panel1);
            panels.Add(panel4);
            panels[index].BringToFront();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            Supplier_Client supplier = new Supplier_Client();
            supplier.ID = int.Parse(txt_ID.Text);
            supplier.FullName=txt_Name.Text;
            supplier.Phone= int.Parse(txt_Phone.Text);
            supplier.Fax = txt_Fax.Text;
            supplier.Mobile = int.Parse(txt_Mobile.Text);
            supplier.Email = txt_Mail.Text;
            supplier.Website = txt_Website.Text;
            supplier.Supplier_Client1 = "Supplier";
            DataContext db = new DataContext();
            db.Supplier_Client.Add(supplier);
            db.SaveChanges();
            txt_ID.Text = String.Empty;
            txt_Name.Text = String.Empty;
            txt_Phone.Text = String.Empty;
            txt_Fax.Text = String.Empty;
            txt_Mobile.Text = String.Empty;
            txt_Mail.Text = String.Empty;
            txt_Website.Text = String.Empty;
            MessageBox.Show("Supplier Added Successfully");
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            DataContext db = new DataContext();
            Supplier_Client supplier = new Supplier_Client();
            int id = Convert.ToInt32(comboBox1.SelectedItem);
            var data= (from i in db.Supplier_Client
                       where id == i.ID
                       select i).First();
            data.FullName= txt_sName.Text; 
            data.Phone= int.Parse(txt_sPhone.Text);
            data.Fax= txt_sFax.Text; 
            data.Mobile= int.Parse(txt_sMobile.Text); 
            data.Email = txt_sMail.Text;
            data.Website= txt_sWebsite.Text;
            db.SaveChanges();
            txt_sName.Text = String.Empty;
            txt_sPhone.Text = String.Empty;
            txt_sFax.Text = String.Empty;
            txt_sMobile.Text = String.Empty;
            txt_sMail.Text = String.Empty;
            txt_sWebsite.Text = String.Empty;
            MessageBox.Show("Supplier Edited Successfully");
        }

        private void txt_ID_TextChanged(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)//edit
        {
            if (index < panels.Count - 1)
            {
                panels[++index].BringToFront();
            }
            DataContext db = new DataContext();

            List<Supplier_Client> suppliers = new List<Supplier_Client>();
            suppliers = db.Supplier_Client.ToList();

            List<int> lst = new List<int>();

            foreach (var h in suppliers)
            {
                if (h.Supplier_Client1 == "Supplier  ")
                {
                    lst.Add(h.ID);
                }
            }
            foreach (int x in lst)
            {
                comboBox1.Items.Add(x);
            }
        }

        private void button1_Click(object sender, EventArgs e)//add
        {
            if (index > 0)
            {
                panels[--index].BringToFront();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataContext db = new DataContext();
            int id = Convert.ToInt32(comboBox1.SelectedItem);
            var data = (from i in db.Supplier_Client
                        where id == i.ID
                        select new { Name = i.FullName, Phone = i.Phone, Fax = i.Fax, Mobile = i.Mobile, Emai = i.Email, website = i.Website }).First();
            txt_sName.Text = data.Name;
            txt_sPhone.Text = data.Phone.ToString();
            txt_sFax.Text = data.Fax;
            txt_sMobile.Text = data.Mobile.ToString();
            txt_sMail.Text = data.Emai;
            txt_sWebsite.Text = data.website;
        }
    }
}
