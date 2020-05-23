using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eshop.Persistence.Core.Models
{
    public partial class Product
    {
        public int Id { get; set; }


        public string Name { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }


        public string ImageUrl { get; set; }


        public virtual Category Category { get; set; }
    }
}
