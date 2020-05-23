using eshop.Persistence.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Persistence.Core.Repositories
{
    public interface IProductRepository
    {
        Task Add(Product product);


        // Marks an entity as modified
        void Update(Product product);


        // Marks an entity to be removed
        void Delete(int  id);


        // Get an entity by int id
        Task<Product> GetById(int id);


        Task<IEnumerable<Product>> GetAll();
    }
}
