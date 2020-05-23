using eshop.Persistence.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Common.Service.Business
{
    public interface IShoppingCartService
    {
        Task<ShoppingCartDto> Add(ShoppingCartDto shoppingCartDto);


        // Marks an entity as modified
        Task<ShoppingCartDto> Update(ShoppingCartDto shoppingCartDto);


        // Marks an entity to be removed
        Task Delete(ShoppingCartDto shoppingCartDto);


        // Get an entity by int id
        Task<ShoppingCartDto> GetById(Guid id);


        Task<IEnumerable<ShoppingCartDto>> GetAll();
    }
}
