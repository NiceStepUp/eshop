using System;
using System.Collections.Generic;
using System.Text;

namespace eshop.Persistence.Core.Dtos
{
    public class AuthenticationInfoDto
    {
        public string Id { get; set; }

        public string AuthToken { get; set; }

        public DateTime ExpiresIn { get; set; }

        public string UserName { get; set; }

        public IEnumerable<string> Roles { get; set; }

        public bool IsUserExists { get; set; }
    }
}
