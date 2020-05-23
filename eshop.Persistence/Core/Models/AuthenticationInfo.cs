using System;
using System.Collections.Generic;
using System.Text;

namespace eshop.Persistence.Core.Models
{
    public class AuthenticationInfo
    {
        public string Id { get; set; }


        public string AuthToken { get; set; }


        public DateTime ExpiresIn { get; set; }


        public IEnumerable<string> Roles { get; set; }


        public Customer Customer { get; set; }

        public bool IsUserExists { get; set; }
    }
}
