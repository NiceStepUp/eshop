using eshop.Persistence.Core.Dtos;
using eshop.Persistence.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Common.Service.Business
{
    public interface ICustomerService
    {
        Task Add(CustomerDto customer, string password);


        // Marks an entity as modified
        Task Update(CustomerDto customer);


        // Marks an entity to be removed
        Task Delete(CustomerDto customer);


        // Get an entity by int id
        Task<CustomerDto> GetById(string id, bool showAllInfo);


        Task<IEnumerable<CustomerDto>> GetAll();


        Task<CustomerDto> ForgotPassword(CustomerDto customer, string resetCallbackUrl);


        Task<CustomerDto> ResetPassword(CustomerDto customer);
    }
}
