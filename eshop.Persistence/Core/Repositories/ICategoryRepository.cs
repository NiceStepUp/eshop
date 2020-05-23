using eshop.Persistence.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Persistence.Core.Repositories
{
    public interface ICategoryRepository
    {
        Task Add(Category customer);


        // Marks an entity as modified
        void Update(Category customer);


        // Marks an entity to be removed
        void Delete(int id);


        // Get an entity by int id
        Task<Category> GetById(int id);


        Task<IEnumerable<Category>> GetAll();
    }
}
