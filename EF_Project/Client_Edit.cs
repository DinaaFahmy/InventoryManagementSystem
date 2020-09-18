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
    public partial class Client_Edit : Form
    {
        List<Panel> panels = new List<Panel>();
        int index;
        public Client_Edit()
        {
            InitializeComponent();
            panels.Add(panel1);
            panels.Add(panel2);
            panels[index].BringToFront();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            Supplier_Client client = new Supplier_Client();
            client.ID = int.Parse(txt_ID.Text);
            client.FullName = txt_Name.Text;
            client.Phone = int.Parse(txt_Phone.Text);
            client.Fax = txt_Fax.Text;
            client.Mobile = int.Parse(txt_Mobile.Text);
            client.Email = txt_Mail.Text;
            client.Website = txt_Website.Text;
            client.Supplier_Client1 = "Client";
            DataContext db = new DataContext();
            db.Supplier_Client.Add(client);
            db.SaveChanges();
            txt_ID.Text = String.Empty;
            txt_Name.Text = String.Empty;
            txt_Phone.Text = String.Empty;
            txt_Fax.Text = String.Empty;
            txt_Mobile.Text = String.Empty;
            txt_Mail.Text = String.Empty;
            txt_Website.Text = String.Empty;
            MessageBox.Show("Client Added Successfully");
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            DataContext db = new DataContext();
            int id = Convert.ToInt32(cmb_id.SelectedItem);
            var data = (from i in db.Supplier_Client
                        where id == i.ID
                        select i).First();
            data.FullName = txt_cName.Text;
            data.Phone = int.Parse(txt_cPhone.Text);
            data.Fax = txt_cFax.Text;
            data.Mobile = int.Parse(txt_cMobile.Text);
            data.Email = txt_cMail.Text;
            data.Website = txt_cWebsite.Text;
            db.SaveChanges();
            txt_cName.Text = String.Empty;
            txt_cPhone.Text = String.Empty;
            txt_cFax.Text = String.Empty;
            txt_cMobile.Text = String.Empty;
            txt_cMail.Text = String.Empty;
            txt_cWebsite.Text = String.Empty;
            MessageBox.Show("Client Edited Successfully");
        }

        private void txt_ID_TextChanged(object sender, EventArgs e)
        {
        }

        private void Client_Edit_Load(object sender, EventArgs e)
        {

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
            
            List<Supplier_Client> clients = new List<Supplier_Client>();
            clients = db.Supplier_Client.ToList();

            List<int> lst = new List<int>();
           
            foreach(var h in clients)
            {
                if (h.Supplier_Client1 == "Client    ")
                {
                    lst.Add(h.ID);
                }
            }           
            foreach (int x in lst)
            {
                cmb_id.Items.Add(x);
            }                    
        }

        private void cmb_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataContext db = new DataContext();
            int id = Convert.ToInt32(cmb_id.SelectedItem);
            var data = (from i in db.Supplier_Client
                        where id == i.ID
                        select new {  Name = i.FullName, Phone = i.Phone, Fax = i.Fax, Mobile = i.Mobile, Emai = i.Email, website = i.Website }).First();
            txt_cName.Text = data.Name;
            txt_cPhone.Text = data.Phone.ToString();
            txt_cFax.Text = data.Fax;
            txt_cMobile.Text = data.Mobile.ToString();
            txt_cMail.Text = data.Emai;
            txt_cWebsite.Text = data.website;
        }
    }
}
