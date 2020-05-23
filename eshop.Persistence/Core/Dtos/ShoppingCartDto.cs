using System;
using System.Collections.Generic;
using System.Text;

namespace eshop.Persistence.Core.Dtos
{
    public class ShoppingCartDto
    {
        public Guid Id { get; set; }


        public DateTime? DateCreated { get; set; }


        public IEnumerable<ShoppingCartItemDto> ShoppingCartItems { get; set; }
    }
}
