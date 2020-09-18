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
    public partial class Store_Edit : Form
    {
        public Store_Edit()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            Store store = new Store();
            store.StoreName = txt_Name.Text;
            store.Location = txt_Loc.Text;
            store.StoreOfficer = txt_Officer.Text;
            DataContext db = new DataContext();
            db.Stores.Add(store);
            db.SaveChanges();
            txt_Name.Text = string.Empty;
            txt_Loc.Text = string.Empty;
            txt_Officer.Text = string.Empty;
            MessageBox.Show("Store Added Successfully");
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            DataContext db = new DataContext();
            string storeName = txt_Name.Text;
            Store store = new Store();
            var data = (from i in db.Stores
                        where storeName == i.StoreName
                        select i).First();
            data.Location = txt_Loc.Text;
            data.StoreOfficer = txt_Officer.Text;
            db.SaveChanges();
            txt_Name.Text = string.Empty;
            txt_Loc.Text = string.Empty;
            txt_Officer.Text = string.Empty;
            MessageBox.Show("Store Edited Successfully");
        }
        
        private void txt_Name_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
