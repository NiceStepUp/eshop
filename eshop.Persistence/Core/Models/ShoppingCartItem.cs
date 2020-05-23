using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace eshop.Persistence.Core.Models
{
    public partial class ShoppingCartItem
    {
        public int Id { get; set; }


        [ForeignKey("IdShoppingCart")]
        public virtual ShoppingCart ShoppingCart { get; set; }


        [ForeignKey("IdProduct")]
        public virtual Product Product { get; set; }


        public int? Quantity { get; set; }
    }
}
