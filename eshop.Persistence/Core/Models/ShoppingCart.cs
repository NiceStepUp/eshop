using System;
using System.Collections.Generic;

namespace eshop.Persistence.Core.Models
{
    public partial class ShoppingCart
    {
        public ShoppingCart()
        {
            ShoppingCartItems = new HashSet<ShoppingCartItem>();
        }

        public Guid Id { get; set; }


        public DateTime? DateCreated { get; set; }


        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
