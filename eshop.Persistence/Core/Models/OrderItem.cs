using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace eshop.Persistence.Core.Models
{
    public partial class OrderItem
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalPrice { get; set; }

        public virtual Order Order { get; set; }
        
        public virtual Product Product { get; set; }
    }
}
