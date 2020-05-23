using System;
using System.Collections.Generic;

namespace eshop.Persistence.Core.Models
{
    public partial class Shipping
    {
        public int Id { get; set; }


        public string Name { get; set; }


        public string City { get; set; }


        public string Line1 { get; set; }


        public string Line2 { get; set; }
    }
}
