using System;
using System.Collections.Generic;
using System.Text;

namespace eshop.Persistence.Core.Dtos
{
    public class ShoppingCartItemDto
    {
        public int Id { get; set; }


        public Guid IdShoppingCart { get; set; }


        // public int IdProduct { get; set; }
        public ProductDto Product { get; set; }


        public int? Quantity { get; set; }
    }
}
