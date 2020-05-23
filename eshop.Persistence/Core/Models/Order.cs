using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace eshop.Persistence.Core.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }

        public DateTime DatePlaced { get; set; }


        public virtual Customer Customer { get; set; }

        [ForeignKey("IdShipping")]
        public virtual Shipping Shipping { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
