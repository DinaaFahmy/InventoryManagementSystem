namespace EF_Project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Store_Products
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string StoreName { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ProductionDate { get; set; }

        public int? ValidityPeriod { get; set; }

        public int? SupplierID { get; set; }

        public int? Quantity { get; set; }

        [StringLength(20)]
        public string ProductName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfAdjust { get; set; }

        public virtual Product Product { get; set; }

        public virtual Store Store { get; set; }

        public virtual Supplier_Client Supplier_Client { get; set; }
    }
}
