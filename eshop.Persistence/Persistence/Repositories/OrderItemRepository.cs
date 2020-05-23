using eshop.Persistence.Core.Models;
using eshop.Persistence.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Persistence.Persistence.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly eshopContext _context;

        public OrderItemRepository(eshopContext context)
        {
            _context = context;
        }


        public async Task<OrderItem> GetById(int id)
        {
            return await _context.OrderItems
                .Include(p => p.Product)
                .Include(p => p.Order)
                .FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task<IEnumerable<OrderItem>> GetAll()
        {
            return await _context.OrderItems
                .Include(p => p.Product)
                .Include(p => p.Order)
                .ToListAsync();
        }

        public async Task Add(OrderItem orderItem)
        {
            await _context.OrderItems.AddAsync(orderItem);
        }

        public void Update(OrderItem orderItem)
        {
            _context.OrderItems.Attach(orderItem);
            _context.Entry(orderItem).State = EntityState.Modified;
        }

        public void Delete(OrderItem orderItem)
        {
            _context.OrderItems.Remove(orderItem);
        }
    }
}
