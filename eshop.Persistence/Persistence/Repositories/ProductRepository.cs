using eshop.Persistence.Core.Models;
using eshop.Persistence.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace eshop.Persistence.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly eshopContext _context;

        public ProductRepository(eshopContext context)
        {
            _context = context;
        }


        public async Task<Product> GetById(int id)
        {
            return await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task Add(Product product)
        {
            product.Category = _context.Categories.FirstOrDefault(c => c.Id == product.Category.Id);
            await _context.AddAsync(product);
        }

        public void Update(Product product)
        {
            _context.Products.Attach(product);
            _context.Entry(product).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
                _context.Products.Remove(product);
        }
    }
}
