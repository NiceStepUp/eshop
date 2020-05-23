using eshop.Persistence.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eshop.Infrastructure.Miscellaneous
{
    public class DbInitializer
    {
        private eshopContext _context;

        public DbInitializer(eshopContext context)
        {
            _context = context;
        }


        public async Task Seed()
        {
            if (!_context.Products.Any())
            {
                _context.AddRange(_products);
                await _context.SaveChangesAsync();
            }
        }


        static Category breadCategory =  new Category{ Name = "Bread" };
        static Category dairyCategory = new Category { Name = "Dairy" };
        static Category fruitsCategory = new Category { Name = "Fruits" };
        static Category seasonAndSpicesCategory = new Category { Name = "Seasonings and Spices" };
        static Category vegatablesCategory = new Category { Name = "Vegetables" };

        List<Product> _products = new List<Product>
        {
            new Product{ Name = "Spinach", Price = 2.5m, Category = vegatablesCategory, ImageUrl = @"StaticFiles\Images\Vegetables\Spinach\Spinach.jpg" },
            new Product{ Name = "Freshly Baked Bread", Price = 3m, Category = breadCategory, ImageUrl = @"StaticFiles\Images\Bread\Freshly Baked Bread\Freshly Baked Bread.jpg" },
            new Product{ Name = "Avacado", Price = 1.75m, Category = fruitsCategory, ImageUrl = @"StaticFiles\Images\Fruits\Avacado\Avacado.jpg" },
            new Product{ Name = "Tomato", Price = 2.5m, Category = vegatablesCategory, ImageUrl = @"StaticFiles\Images\Vegetables\Tomato\Tomato.jpg" },
            new Product{ Name = "Lettuce", Price = 1m, Category = vegatablesCategory, ImageUrl = @"StaticFiles\Images\Vegetables\Lettuce\Lettuce.jpg" },
            new Product{ Name = "Cauliflower", Price = 1.75m, Category = vegatablesCategory, ImageUrl = @"StaticFiles\Images\Vegetables\Cauliflower\Cauliflower.jpg" },
            new Product{ Name = "Banana", Price = 1.25m, Category = fruitsCategory, ImageUrl = @"StaticFiles\Images\Fruits\Banana\Banana.jpg" },
            new Product{ Name = "Orange", Price = 1.7m, Category = fruitsCategory, ImageUrl = @"StaticFiles\Images\Fruits\Orange\Orange.jpg" },
            new Product{ Name = "Apple", Price = 2m, Category = fruitsCategory, ImageUrl = @"StaticFiles\Images\Fruits\Apple\Apple.jpg" },
            new Product{ Name = "Grape", Price = 2m, Category = fruitsCategory, ImageUrl = @"StaticFiles\Images\Fruits\Grape\Grape.jpg" },
            new Product{ Name = "Peach", Price = 2m, Category = fruitsCategory, ImageUrl = @"StaticFiles\Images\Fruits\Peach\Peach.jpg" },
            new Product{ Name = "Cinnamon Sticks", Price = 0.5m, Category = seasonAndSpicesCategory, ImageUrl = @"StaticFiles\Images\Seasonings and Spices\Cinnamon Sticks\Cinnamon Sticks.jpg" },
            new Product{ Name = "Saffron", Price = 3m, Category = seasonAndSpicesCategory, ImageUrl = @"StaticFiles\Images\Seasonings and Spices\Saffron\Saffron.jpg" },
            new Product{ Name = "Ground Turmeric", Price = 0.75m, Category = seasonAndSpicesCategory, ImageUrl = @"StaticFiles\Images\Seasonings and Spices\Ground Turmeric\Ground Turmeric.jpg" },
            new Product{ Name = "Coriander Seeds", Price = 0.5m, Category = seasonAndSpicesCategory, ImageUrl = @"StaticFiles\Images\Seasonings and Spices\Coriander Seeds\Coriander Seeds.jpg" },
            new Product{ Name = "Lavash Bread", Price = 1.25m, Category = breadCategory, ImageUrl = @"StaticFiles\Images\Bread\Lavash Bread\Lavash Bread.jpg" },
            new Product{ Name = "Bagel Bread", Price = 1m, Category = breadCategory, ImageUrl = @"StaticFiles\Images\Bread\Bagel Bread\Bagel Bread.jpg" },
            new Product{ Name = "Strawberry", Price = 1.95m, Category = fruitsCategory, ImageUrl = @"StaticFiles\Images\Fruits\Strawberry\Strawberry.jpg" },
            new Product{ Name = "Baguette Bread", Price = 1.25m, Category = breadCategory, ImageUrl = @"StaticFiles\Images\Bread\Baguette Bread\Baguette Bread.jpeg" },
        };
    }
}
