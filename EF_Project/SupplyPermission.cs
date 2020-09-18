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
    public partial class SupplyPermission : Form
    {      
        public SupplyPermission()
        {
            InitializeComponent();                     
            loadComboBoxes();
        }
        public void loadComboBoxes()
        {
            DataContext db = new DataContext();

            List<Store> stores = new List<Store>();
            stores = db.Stores.ToList();
            List<string> names = new List<string>();
            foreach (var h in stores)
            {
                cmb_store.Items.Add(h.StoreName);
            }
            //--------------------------------------------------------------------
            List<Supplier_Client> suppliers = new List<Supplier_Client>();
            suppliers = db.Supplier_Client.ToList();

            cmb_supplier.DisplayMember = "Text";
            cmb_supplier.ValueMember = "Value";

            foreach (var s in suppliers)
            {
                if (s.Supplier_Client1 == "Supplier  ")
                {
                    cmb_supplier.Items.Add(new { Text = s.FullName, Value = s.ID });
                }
            }
            //--------------------------------------------------------------------
            cmb_prodName.DisplayMember = "Text";
            cmb_prodName.ValueMember = "Value";

            List<Product> products = new List<Product>();
            products = db.Products.ToList();
            foreach (var p in products)
            {
                cmb_prodName.Items.Add(new { Text = p.ProductName, Value = p.ProductID });
            }
           
        }
        public override string ToString()
        {
            return Text;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            Permission perm = new Permission();
            Permission_Product pp = new Permission_Product();
            Store_Products sp = new Store_Products();

            perm.PermissionNumber = int.Parse(txt_PermNo.Text);
            perm.PermissionType = "Supply";
            perm.StoreName = cmb_store.SelectedItem.ToString();
            perm.PermissionDate = permDate.Value;
            perm.Supplier_Client_ID = (cmb_supplier.SelectedItem as dynamic).Value;
            perm.ProductionDate = prodDate.Value;
            perm.ValidityPeriod= int.Parse(txt_ValidPeriod.Text);

            sp.StoreName = cmb_store.SelectedItem.ToString();
            sp.ProductID =(cmb_prodName.SelectedItem as dynamic).Value;
            sp.ProductName = (cmb_prodName.SelectedItem as dynamic).Text;
            sp.ProductionDate = prodDate.Value;
            sp.ValidityPeriod = int.Parse(txt_ValidPeriod.Text);
            sp.SupplierID = (cmb_supplier.SelectedItem as dynamic).Value;
            sp.Quantity = int.Parse(txt_Qnty.Text);
            sp.DateOfAdjust= permDate.Value; 

            pp.PermissionID = int.Parse(txt_PermNo.Text);
            pp.ProductID = (cmb_prodName.SelectedItem as dynamic).Value;
            pp.ProductQuantity = int.Parse(txt_Qnty.Text);

            DataContext db = new DataContext();  

            if(db.Permission_Product.Select(a => a.PermissionID).Contains(pp.PermissionID) == true)
            {
                db.Permission_Product.Add(pp);
                db.Store_Products.Add(sp);
                db.SaveChanges();
                MessageBox.Show("Permission Added Successfully");
            }
            else
            {
                db.Permissions.Add(perm);
                db.Permission_Product.Add(pp);
                db.Store_Products.Add(sp);

                db.SaveChanges();
               
                MessageBox.Show("Permission Added Successfully");
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_PermNo.Text = String.Empty;
            txt_Qnty.Text = String.Empty;
            txt_ValidPeriod.Text = String.Empty;
            cmb_prodName.SelectedIndex = -1;
            cmb_store.SelectedIndex = -1;
            cmb_supplier.SelectedIndex = -1;
            prodDate.Value = DateTime.Now;
            permDate.Value = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)//add
        {
           
        }

        private void button2_Click(object sender, EventArgs e)//edit
        {
        }

        private void btn_Clear2_Click(object sender, EventArgs e)
        {          
        }

        private void btn_Edit_Click(object sender, EventArgs e)//edit permission_date 
        {
            DataContext db = new DataContext();
            int id = int.Parse(txt_PermNo.Text);
            var data_perm = (from i in db.Permissions
                        where id == i.PermissionNumber
                        select i).First();
            //var data_pp = (from i in db.Permission_Product
            //               where id == i.PermissionID
            //               select i).First();
      
            data_perm.PermissionDate= permDate.Value; 
            //data_perm.Supplier_Client_ID= (cmb_supplier.SelectedItem as dynamic).Value;
            //data_perm.ProductionDate = prodDate.Value;
            //data_perm.ValidityPeriod=int.Parse(txt_ValidPeriod.Text);
            //data_pp.ProductQuantity = int.Parse(txt_Qnty.Text);

            db.SaveChanges();
            MessageBox.Show("Permission Edited Successfully");
        }
    }
}
