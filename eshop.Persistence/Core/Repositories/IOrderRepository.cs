using eshop.Persistence.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Persistence.Core.Repositories
{
    public interface IOrderRepository
    {
        Task Add(Order order);


        // Marks an entity as modified
        void Update(Order order);


        // Marks an entity to be removed
        void Delete(Order order);


        // Get an entity by int id
        Task<Order> GetById(int id);


        // Get an entities by user id
        Task<IEnumerable<Order>> GetOrdersByUserId(string id);


        Task<IEnumerable<Order>> GetAll();
    }
}
