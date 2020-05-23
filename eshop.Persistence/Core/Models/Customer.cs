using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace eshop.Persistence.Core.Models
{
    /// <summary>
    /// Profile data for application users
    /// </summary>
    public class Customer : IdentityUser
    {        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public long? FacebookId { get; set; }

        public string PictureUrl { get; set; }

        public string Location { get; set; }

        public string Locale { get; set; }

        public string Gender { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
