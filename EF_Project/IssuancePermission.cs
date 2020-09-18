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
    public partial class IssuancePermission : Form
    {
        public IssuancePermission()
        {
            InitializeComponent();
            DataContext db = new DataContext();
           

            List<Store_Products> stores = new List<Store_Products>();
            stores = db.Store_Products.ToList();

            foreach (var h in stores)
            {
                cmb_store.Items.Add(h.StoreName);
            }
            for (int i = 0; i < cmb_store.Items.Count; i++)
            {
                for (int y = 0; y < cmb_store.Items.Count; y++)
                {
                    if (y != i && cmb_store.Items[i] == cmb_store.Items[y])
                    {
                        cmb_store.Items.RemoveAt(i);

                    }
                }
            }
            //--------------------------------------------------------------------
            List<Supplier_Client> suppliers = new List<Supplier_Client>();
            suppliers = db.Supplier_Client.ToList();

            cmb_client.DisplayMember = "Text";
            cmb_client.ValueMember = "Value";

            foreach (var s in suppliers)
            {
                if (s.Supplier_Client1 == "Client    ")
                {
                    cmb_client.Items.Add(new { Text = s.FullName, Value = s.ID });
                }
            }
            //--------------------------------------------------------------------
            cmb_prodName.DisplayMember = "Text";
            cmb_prodName.ValueMember = "Value";
        }
        public override string ToString()
        {
            return Text;
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_PermNo.Text = String.Empty;
            txt_Qnty.Text = String.Empty;     
            cmb_prodName.SelectedIndex = -1;
            //cmb_store.SelectedIndex = -1;
            cmb_client.SelectedIndex = -1;
            permDate.Value = DateTime.Now;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            DataContext db = new DataContext();

            Permission perm = new Permission();
            Permission_Product pp = new Permission_Product();

            perm.PermissionNumber = int.Parse(txt_PermNo.Text);
            perm.PermissionType = "Issuance";
            perm.StoreName = cmb_store.SelectedItem.ToString();
            perm.PermissionDate = permDate.Value;
            perm.Supplier_Client_ID = (cmb_client.SelectedItem as dynamic).Value;

            pp.PermissionID = int.Parse(txt_PermNo.Text);
            pp.ProductID = (cmb_prodName.SelectedItem as dynamic).Value;
            pp.ProductQuantity = int.Parse(txt_Qnty.Text);           

            if (db.Permission_Product.Select(a => a.PermissionID).Contains(pp.PermissionID) == true)
            {
                db.Permission_Product.Add(pp);
                db.SaveChanges();
                MessageBox.Show("Permission Added Successfully");
            }
            else
            {
                db.Permissions.Add(perm);
                db.Permission_Product.Add(pp);
                db.SaveChanges();
                MessageBox.Show("Permission Added Successfully");
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            DataContext db = new DataContext();
            int id = int.Parse(txt_PermNo.Text);
            var data_perm = (from i in db.Permissions
                             where id == i.PermissionNumber
                             select i).First();
            var data_pp = (from i in db.Permission_Product
                           where id == i.PermissionID
                           select i).First();

            data_perm.PermissionDate = permDate.Value;
            //data_perm.Supplier_Client_ID = (cmb_client.SelectedItem as dynamic).Value;
            data_pp.ProductQuantity = int.Parse(txt_Qnty.Text);

            db.SaveChanges();
            MessageBox.Show("Permission Edited Successfully");
        }

        private void cmb_store_SelectedIndexChanged(object sender, EventArgs e)
        {          
                cmb_prodName.Items.Clear();
                DataContext db = new DataContext();
                string storeName = cmb_store.SelectedItem.ToString();
                int productsID = (from i in db.Store_Products where storeName == i.StoreName select i.ProductID).First();
                List<Product> products = new List<Product>();
                products = db.Products.ToList();
                foreach (var x in products)
                {
                    if (x.ProductID == productsID)
                    {
                        cmb_prodName.Items.Add(new { Text = x.ProductName, Value = x.ProductID });
                    }
                }         
        }
    }
}
