namespace EF_Project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductsTransfer")]
    public partial class ProductsTransfer
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string From_Store { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string To_Store { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Quantity { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SupplierID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ProductionDate { get; set; }

        public int? ValidityPeriod { get; set; }

        public virtual Product Product { get; set; }

        public virtual Store Store { get; set; }

        public virtual Store Store1 { get; set; }

        public virtual Supplier_Client Supplier_Client { get; set; }
    }
}
