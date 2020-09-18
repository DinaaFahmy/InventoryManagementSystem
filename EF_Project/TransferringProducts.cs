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
    public partial class TransferringProducts : Form
    {
        public TransferringProducts()
        {
            InitializeComponent();
            DataContext db = new DataContext();

            cmb_prodName.DisplayMember = "Text";
            cmb_prodName.ValueMember = "Value";

            List<Product> products = new List<Product>();
            products = db.Products.ToList();
            foreach (var p in products)
            {
                cmb_prodName.Items.Add(new { Text = p.ProductName, Value = p.ProductID });
            }
            //--------------------------------------
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
            //---------------------------------------
            List<Store> stores = new List<Store>();
            stores = db.Stores.ToList();
            List<string> names = new List<string>();
            foreach (var h in stores)
            {
                cmb_to.Items.Add(h.StoreName);
            }
            //----------------------------------------
            List<Store_Products> stores_lst = new List<Store_Products>();
            stores_lst = db.Store_Products.ToList();

            foreach (var h in stores)
            {
                cmb_from.Items.Add(h.StoreName);
            }
            for (int i = 0; i < cmb_from.Items.Count; i++)
            {
                for (int y = 0; y < cmb_from.Items.Count; y++)
                {
                    if (y!= i && cmb_from.Items[i] == cmb_from.Items[y])
                    {
                        cmb_from.Items.RemoveAt(i);

                    }
                }
            }
        }
        public override string ToString()
        {
            return Text;
        }
        private void btn_transfer_Click(object sender, EventArgs e)
        {
            ProductsTransfer pt = new ProductsTransfer();
            Store_Products sp = new Store_Products();

            DataContext db = new DataContext();
       

            sp.StoreName = cmb_to.SelectedItem.ToString();
            sp.ProductID = (cmb_prodName.SelectedItem as dynamic).Value;
            sp.ProductName = (cmb_prodName.SelectedItem as dynamic).Text;
            sp.ProductionDate = prodDate.Value;
            sp.ValidityPeriod = int.Parse(txt_ValidPeriod.Text);
            sp.Quantity = int.Parse(txt_Qnty.Text);
            sp.SupplierID = (cmb_supplier.SelectedItem as dynamic).Value;
            sp.DateOfAdjust = DateTime.Now;

            pt.From_Store = cmb_from.SelectedItem.ToString();
            pt.To_Store = cmb_to.SelectedItem.ToString();
            pt.ProductID = (cmb_prodName.SelectedItem as dynamic).Value;
            pt.Quantity =int.Parse(txt_Qnty.Text);
            pt.SupplierID = (cmb_supplier.SelectedItem as dynamic).Value;
            pt.ProductionDate = prodDate.Value;
            pt.ValidityPeriod = int.Parse(txt_ValidPeriod.Text);

                db.ProductsTransfers.Add(pt);
                db.Store_Products.Add(sp);
                db.SaveChanges();
                MessageBox.Show("Transferring data has been saved successfully");                        
        }

        private void cmb_from_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_prodName.Items.Clear();
            DataContext db = new DataContext();
            string storeName = cmb_from.SelectedItem.ToString();

            if (db.Store_Products.Select(a => a.StoreName).Contains(storeName) == true)
            {
              var list= (from i in db.Store_Products where storeName == i.StoreName select new { ID = i.ProductID, Name = i.ProductName }).ToList();
                foreach (var x in list)
                {                    
                    cmb_prodName.Items.Add(new { Text = x.Name , Value = x.ID }) ;
                }               
            }          
        }

        private void cmb_prodName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_supplier.Items.Clear();
            DataContext db = new DataContext();
           
            int ProductID = (cmb_prodName.SelectedItem as dynamic).Value;
            int? supplierID = (from i in db.Store_Products where ProductID == i.ProductID select i.SupplierID).First();

            var supllierList = (from i in db.Supplier_Client where i.ID == supplierID select new { id = i.ID, Name = i.FullName}).ToList();

            foreach (var a in supllierList)
            {
              cmb_supplier.Items.Add(new { Text = a.Name, Value = a.id });              
            }
        }
    }
}
