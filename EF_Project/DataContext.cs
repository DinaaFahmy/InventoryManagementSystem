namespace EF_Project
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Permission_Product> Permission_Product { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductsMeasurement> ProductsMeasurements { get; set; }
        public virtual DbSet<Store_Products> Store_Products { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Supplier_Client> Supplier_Client { get; set; }
        public virtual DbSet<ProductsTransfer> ProductsTransfers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permission>()
                .Property(e => e.PermissionType)
                .IsFixedLength();

            modelBuilder.Entity<Permission>()
                .Property(e => e.StoreName)
                .IsFixedLength();

            modelBuilder.Entity<Permission>()
                .HasMany(e => e.Permission_Product)
                .WithRequired(e => e.Permission)
                .HasForeignKey(e => e.PermissionID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductName)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Permission_Product)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductsMeasurements)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductsTransfers)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Store_Products)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductsMeasurement>()
                .Property(e => e.Measurement)
                .IsFixedLength();

            modelBuilder.Entity<Store_Products>()
                .Property(e => e.StoreName)
                .IsFixedLength();

            modelBuilder.Entity<Store_Products>()
                .Property(e => e.ProductName)
                .IsFixedLength();

            modelBuilder.Entity<Store>()
                .Property(e => e.StoreName)
                .IsFixedLength();

            modelBuilder.Entity<Store>()
                .Property(e => e.Location)
                .IsFixedLength();

            modelBuilder.Entity<Store>()
                .Property(e => e.StoreOfficer)
                .IsFixedLength();

            modelBuilder.Entity<Store>()
                .HasMany(e => e.Permissions)
                .WithRequired(e => e.Store)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Store>()
                .HasMany(e => e.Store_Products)
                .WithRequired(e => e.Store)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Store>()
                .HasMany(e => e.ProductsTransfers)
                .WithRequired(e => e.Store)
                .HasForeignKey(e => e.From_Store)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Store>()
                .HasMany(e => e.ProductsTransfers1)
                .WithRequired(e => e.Store1)
                .HasForeignKey(e => e.To_Store)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier_Client>()
                .Property(e => e.FullName)
                .IsFixedLength();

            modelBuilder.Entity<Supplier_Client>()
                .Property(e => e.Fax)
                .IsFixedLength();

            modelBuilder.Entity<Supplier_Client>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<Supplier_Client>()
                .Property(e => e.Website)
                .IsFixedLength();

            modelBuilder.Entity<Supplier_Client>()
                .Property(e => e.Supplier_Client1)
                .IsFixedLength();

            modelBuilder.Entity<Supplier_Client>()
                .HasMany(e => e.Permissions)
                .WithRequired(e => e.Supplier_Client)
                .HasForeignKey(e => e.Supplier_Client_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier_Client>()
                .HasMany(e => e.Store_Products)
                .WithOptional(e => e.Supplier_Client)
                .HasForeignKey(e => e.SupplierID);

            modelBuilder.Entity<Supplier_Client>()
                .HasMany(e => e.ProductsTransfers)
                .WithRequired(e => e.Supplier_Client)
                .HasForeignKey(e => e.SupplierID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductsTransfer>()
                .Property(e => e.From_Store)
                .IsFixedLength();

            modelBuilder.Entity<ProductsTransfer>()
                .Property(e => e.To_Store)
                .IsFixedLength();
        }
    }
}
