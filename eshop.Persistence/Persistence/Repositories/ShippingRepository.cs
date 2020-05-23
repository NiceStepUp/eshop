using eshop.Persistence.Core.Models;
using eshop.Persistence.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Persistence.Persistence.Repositories
{
    public class ShippingRepository : IShippingRepository
    {
        private readonly eshopContext _context;

        public ShippingRepository(eshopContext context)
        {
            _context = context;
        }


        public async Task<Shipping> GetById(int id)
        {
            return await _context.Shipping
                .FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task<IEnumerable<Shipping>> GetAll()
        {
            return await _context.Shipping
                .ToListAsync();
        }

        public async Task Add(Shipping shipping)
        {
            await _context.Shipping.AddAsync(shipping);
        }

        public void Update(Shipping shipping)
        {
            _context.Shipping.Attach(shipping);
            _context.Entry(shipping).State = EntityState.Modified;
        }

        public void Delete(Shipping shipping)
        {
            _context.Shipping.Remove(shipping);
        }
    }
}
