using eshop.Persistence.Core.Models;
using eshop.Persistence.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Persistence.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly eshopContext _context;

        public CategoryRepository(eshopContext context)
        {
            _context = context;
        }


        public async Task<Category> GetById(int id)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories
                .ToListAsync();
        }

        public async Task Add(Category category)
        {
            await _context.Categories.AddAsync(category);
        }

        public void Update(Category category)
        {
            _context.Categories.Attach(category);
            _context.Entry(category).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
                _context.Categories.Remove(category);
        }
    }
}
