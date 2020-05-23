using eshop.Persistence.Core.Models;
using eshop.Persistence.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Persistence.Persistence.Repositories
{
    public class ShoppingCartItemRepository : IShoppingCartItemRepository
    {
        private readonly eshopContext _context;

        public ShoppingCartItemRepository(eshopContext context)
        {
            _context = context;
        }


        public async Task<ShoppingCartItem> GetByIdAndProductId(Guid id, int productId)
        {
            return await _context.ShoppingCartItems
                .Include(p => p.Product)
                .Include(p => p.ShoppingCart)
                .FirstOrDefaultAsync(p => p.ShoppingCart.Id == id 
                    && p.Product.Id == productId);
        }


        public async Task<IEnumerable<ShoppingCartItem>> GetAll()
        {
            return await _context.ShoppingCartItems
                .Include(p => p.Product)
                .Include(p => p.ShoppingCart)
                .ToListAsync();
        }


        public async Task Add(ShoppingCartItem shoppingCart)
        {
            await _context.ShoppingCartItems.AddAsync(shoppingCart);
        }


        public void Update(ShoppingCartItem shoppingCart)
        {
            _context.ShoppingCartItems.Attach(shoppingCart);
            _context.Entry(shoppingCart).State = EntityState.Modified;
        }


        public void Delete(ShoppingCartItem shoppingCart)
        {
            _context.ShoppingCartItems.Remove(shoppingCart);
        }
    }
}
