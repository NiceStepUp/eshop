using System;
using System.Collections.Generic;
using System.Text;

namespace eshop.Persistence.Core.Dtos
{
    public class OrderItemDto
    {
        public int Id { get; set; }


        // public int IdOrder { get; set; }


        //public int IdProduct { get; set; }

        public ProductDto Product { get; set; }

        public OrderDto Order { get; set; }


        public int Quantity { get; set; }


        public decimal? TotalPrice { get; set; }
    }
}
