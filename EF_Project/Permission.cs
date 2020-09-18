namespace EF_Project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Permission")]
    public partial class Permission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Permission()
        {
            Permission_Product = new HashSet<Permission_Product>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PermissionNumber { get; set; }

        [Required]
        [StringLength(20)]
        public string PermissionType { get; set; }

        [Required]
        [StringLength(20)]
        public string StoreName { get; set; }

        [Column(TypeName = "date")]
        public DateTime PermissionDate { get; set; }

        [Column("Supplier/Client_ID")]
        public int Supplier_Client_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ProductionDate { get; set; }

        public int? ValidityPeriod { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Permission_Product> Permission_Product { get; set; }

        public virtual Store Store { get; set; }

        public virtual Supplier_Client Supplier_Client { get; set; }
    }
}
