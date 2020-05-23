using eshop.Persistence.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Persistence.Core.Repositories
{
    public interface IOrderItemRepository
    {
        Task Add(OrderItem orderItem);


        // Marks an entity as modified
        void Update(OrderItem orderItem);


        // Marks an entity to be removed
        void Delete(OrderItem orderItem);


        // Get an entity by int id
        Task<OrderItem> GetById(int id);


        Task<IEnumerable<OrderItem>> GetAll();
    }
}
