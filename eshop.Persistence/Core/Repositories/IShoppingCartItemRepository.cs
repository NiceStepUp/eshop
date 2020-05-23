using eshop.Persistence.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Persistence.Core.Repositories
{
    public interface IShoppingCartItemRepository
    {
        Task Add(ShoppingCartItem shoppingCartItem);


        // Marks an entity as modified
        void Update(ShoppingCartItem shoppingCartItem);


        // Marks an entity to be removed
        void Delete(ShoppingCartItem shoppingCartItem);


        // Get an entity by int id
        Task<ShoppingCartItem> GetByIdAndProductId(Guid id, int productId);


        Task<IEnumerable<ShoppingCartItem>> GetAll();
    }
}
