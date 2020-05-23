using eshop.Persistence.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Persistence.Core.Repositories
{
    public interface ICustomerRepository
    {
        Task Add(Customer customer, string password);


        // Marks an entity as modified
        Task Update(Customer customer);


        // Marks an entity to be removed
        void Delete(Customer customer);


        // Get an entity by int id
        Task<Customer> GetById(string id);


        Task<IEnumerable<Customer>> GetAll();
    }
}
