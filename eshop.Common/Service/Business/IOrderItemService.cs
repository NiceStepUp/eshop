using eshop.Persistence.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Common.Service.Business
{
    public interface IOrderItemService
    {
        Task<OrderItemDto> Add(OrderItemDto order);


        // Marks an entity as modified
        Task Update(OrderItemDto order);


        // Marks an entity to be removed
        Task Delete(OrderItemDto order);


        // Get an entity by int id
        Task<OrderItemDto> GetById(int id);


        Task<IEnumerable<OrderItemDto>> GetAll();
    }
}
