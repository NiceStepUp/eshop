using eshop.Persistence.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Common.Service.Business
{
    public interface IShoppingCartItemService
    {
        Task<ShoppingCartItemDto> Add(ShoppingCartItemDto shoppingCartDto);


        // Marks an entity as modified
        Task<ShoppingCartItemDto> Update(ShoppingCartItemDto shoppingCartDto);


        // Marks an entity to be removed
        Task Delete(ShoppingCartItemDto shoppingCartDto);


        // Get an entity by int id
        Task<ShoppingCartItemDto> GetByIdAndProductId(Guid id, int productId);


        Task<IEnumerable<ShoppingCartItemDto>> GetAll();
    }
}
