using eshop.Persistence.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Persistence.Core.Repositories
{
    public interface IShippingRepository
    {
        Task Add(Shipping order);


        // Marks an entity as modified
        void Update(Shipping order);


        // Marks an entity to be removed
        void Delete(Shipping order);


        // Get an entity by int id
        Task<Shipping> GetById(int id);


        Task<IEnumerable<Shipping>> GetAll();
    }
}
