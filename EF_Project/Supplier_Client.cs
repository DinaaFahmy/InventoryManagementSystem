namespace EF_Project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Supplier_Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier_Client()
        {
            Permissions = new HashSet<Permission>();
            Store_Products = new HashSet<Store_Products>();
            ProductsTransfers = new HashSet<ProductsTransfer>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string FullName { get; set; }

        public int Phone { get; set; }

        [StringLength(20)]
        public string Fax { get; set; }

        public int Mobile { get; set; }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(30)]
        public string Website { get; set; }

        [Column("Supplier_Client")]
        [Required]
        [StringLength(10)]
        public string Supplier_Client1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Permission> Permissions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Store_Products> Store_Products { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductsTransfer> ProductsTransfers { get; set; }
    }
}
