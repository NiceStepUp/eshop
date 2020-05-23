using eshop.Common.Service.Business;
using eshop.Common.Service.Core;
using eshop.Infrastructure.CustomExceptionMiddleware;
using eshop.Infrastructure.Logging;
using eshop.Infrastructure.Miscellaneous;
using eshop.Persistence.Core.Dtos;
using eshop.Persistence.Core.Models;
using eshop.Persistence.Core.Repositories;
using eshop.Persistence.Core.UnitOfWork;
using eshop.Persistence.Persistence.Repositories;
using eshop.Persistence.Persistence.UnitOfWork;
using eshopService.Business;
using eshopService.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eshop.Infrastructure
{
    public static class Extensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }

        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<IShoppingCartItemService, ShoppingCartItemService>();
            services.AddScoped<IShoppingCartItemRepository, ShoppingCartItemRepository>();

            services.AddScoped<IShippingRepository, ShippingRepository>();

            services.AddScoped<IOrderItemService, OrderItemService>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();

            services.AddScoped<IUploadFileService, UploadFileService>();
            services.AddScoped<IEmailService, EmailService>();

            return services;
        }
    }

}
