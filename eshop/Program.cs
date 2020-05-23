using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using eshop.Persistence.Core.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace eshop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            WebHost.CreateDefaultBuilder(args)
                .UseSetting(WebHostDefaults.DetailedErrorsKey, "true");

            host.Run();
        }


        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<eshopContext>();
                    context.Database.EnsureCreated();

                    if (context.Categories.Any())
                        return;

                    var categories = new Category[]
                    {
                        new Category{ Name = "Bread" },
                        new Category{ Name = "Dairy" },
                        new Category{ Name = "Fruits" },
                        new Category{ Name = "Seasonings and Spices" },
                        new Category{ Name = "Vegetables" }
                    };
                    foreach (var item in categories)
                    {
                        context.Categories.Add(item);
                    }
                    //context.Categories.AddRange(categories);
                    context.SaveChanges();

                }
                catch (Exception)
                {
                    /*var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");*/
                    throw;
                }
            }
        }


        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
