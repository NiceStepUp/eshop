using eshop.Persistence.Core.Models;
using eshop.Persistence.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eshop.Persistence.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly eshopContext _context;

        public OrderRepository(eshopContext context)
        {
            _context = context;
        }


        public async Task<Order> GetById(int id)
        {
            return await _context.Orders
                .Include(p => p.Customer)
                // .Include(p => p.OrderItems)
                .FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _context.Orders
                .Include(p => p.Customer)
                //.Include(p => p.OrderItems)
                .ToListAsync();
        }

        public async Task Add(Order order)
        {
            _context.Attach(order.Customer);
            foreach (var orderItem in order.OrderItems)
            {
                _context.Attach(orderItem.Product);
            }            
            await _context.Orders.AddAsync(order);
        }

        public void Update(Order order)
        {
            _context.Orders.Attach(order);
            _context.Entry(order).State = EntityState.Modified;
        }

        public void Delete(Order order)
        {
            _context.Orders.Remove(order);
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserId(string id)
        {
            return await _context.Orders
                .Include(order => order.Customer)                
                .Include(order => order.OrderItems)
                    .ThenInclude(orderItem => orderItem.Product)
                .Where(o => o.Customer.Id == id)
                .ToListAsync();
        }
    }
}
