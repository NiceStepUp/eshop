using eshop.Persistence.Core.Models;
using eshop.Persistence.Core.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Persistence.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly eshopContext _context;
        private readonly UserManager<Customer> _userManager;


        public CustomerRepository(eshopContext context, UserManager<Customer> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public async Task Add(Customer customer, string password)
        {            
            var userIdentity = new Customer { UserName = customer.Email, Email = customer.Email, FirstName = customer.FirstName, LastName = customer.LastName };
            var result = await _userManager.CreateAsync(userIdentity, password);

            if (!result.Succeeded)
                throw new Exception(result.Errors.FirstOrDefault().Description);
        }


        public void Delete(Customer customer)
        {
             _context.Customers.Remove(customer);
        }


        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }


        public async Task<Customer> GetById(string id)
        {
            return await _context.Customers.FindAsync(id);
        }


        public async Task Update(Customer customer)
        {
            var appUser = await _userManager.FindByIdAsync(customer.Id);
            appUser.UserName = customer.UserName;
            appUser.FirstName = customer.FirstName;
            appUser.LastName = customer.LastName;
            await _userManager.UpdateAsync(appUser);
        }
    }
}
