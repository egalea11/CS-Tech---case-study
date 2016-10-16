namespace caseStudy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShoppingCart")]
    public partial class ShoppingCart
    {
        public int? RecordId { get; set; }

        public int ShoppingCartId { get; set; }

        public DateTime DateCeated { get; set; }
    }
}
