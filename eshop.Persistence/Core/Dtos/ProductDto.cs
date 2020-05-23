using System;
using System.Collections.Generic;
using System.Text;

namespace eshop.Persistence.Core.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        

        public string Name { get; set; }


        public decimal? Price { get; set; }


        public string ImageUrl { get; set; }


        public CategoryDto Category { get; set; }
    }
}
