using eshop.Persistence.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Persistence.Core.Repositories
{
    public interface IShoppingCartRepository
    {
        Task Add(ShoppingCart shoppingCart);


        // Marks an entity as modified
        void Update(ShoppingCart shoppingCart);


        // Marks an entity to be removed
        void Delete(ShoppingCart shoppingCart);


        // Get an entity by int id
        Task<ShoppingCart> GetById(Guid id);


        Task<IEnumerable<ShoppingCart>> GetAll();
    }
}
