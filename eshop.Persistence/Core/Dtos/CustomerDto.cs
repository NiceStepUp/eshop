using System;
using System.Collections.Generic;
using System.Text;

namespace eshop.Persistence.Core.Dtos
{
    public class CustomerDto
    {
        public string Id { get; set; }


        public string FirstName { get; set; }        


        public string LastName { get; set; }


        public string UserName { get; set; }


        public string Location { get; set; }


        public string Email { get; set; }

        public string EmailToken { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public bool IsAdmin { get; set; }
    }
}
