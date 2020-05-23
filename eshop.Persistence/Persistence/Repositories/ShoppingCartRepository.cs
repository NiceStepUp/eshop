using eshop.Persistence.Core.Models;
using eshop.Persistence.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eshop.Persistence.Persistence.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly eshopContext _context;

        public ShoppingCartRepository(eshopContext context)
        {
            _context = context;
        }


        public async Task<ShoppingCart> GetById(Guid id)
        {
            return await _context.ShoppingCarts
                .Include(s => s.ShoppingCartItems)
                .ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task<IEnumerable<ShoppingCart>> GetAll()
        {
            return await _context.ShoppingCarts
                .Include(p => p.ShoppingCartItems)
                .ToListAsync();
        }

        public async Task Add(ShoppingCart shoppingCart)
        {
            await _context.AddAsync(shoppingCart);
        }

        public void Update(ShoppingCart shoppingCart)
        {
            _context.ShoppingCarts.Attach(shoppingCart);
            _context.Entry(shoppingCart).State = EntityState.Modified;
        }

        public void Delete(ShoppingCart shoppingCart)
        {
            _context.ShoppingCarts.Remove(shoppingCart);
        }
    }
}
