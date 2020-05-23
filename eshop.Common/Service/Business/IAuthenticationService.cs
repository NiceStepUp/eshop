using eshop.Persistence.Core.Dtos;
using eshop.Persistence.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Common.Service.Business
{
    public interface IAuthenticationService
    {
        Task<AuthenticationInfo> Login(string userName, string password);
    }
}
