using eshop.Persistence.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Common.Service.Business
{
    public interface IOrderService
    {
        Task<OrderDto> Add(OrderDto order);


        // Marks an entity as modified
        Task Update(OrderDto order);


        // Marks an entity to be removed
        Task Delete(OrderDto order);


        // Get an entity by int id
        Task<OrderDto> GetById(int id);

        // Get an entity by int id
        Task<IEnumerable<OrderDto>> GetOrdersByUserId(string id);

        Task<IEnumerable<OrderDto>> GetAll();
    }
}
