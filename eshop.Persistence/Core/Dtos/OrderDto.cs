using System;
using System.Collections.Generic;
using System.Text;

namespace eshop.Persistence.Core.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }


        public DateTime DatePlaced { get; set; }


        public CustomerDto Customer { get; set; }


        public ShippingDto Shipping { get; set; }

        public IEnumerable<OrderItemDto> Items { get; set; }

    }
}
