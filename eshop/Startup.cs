using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using eshop.Common.Constants;
using eshop.Common.Service.Business;
using eshop.Infrastructure;
using eshop.Infrastructure.CustomExceptionMiddleware;
using eshop.Infrastructure.Helpers;
using eshop.Infrastructure.Logging;
using eshop.Infrastructure.Miscellaneous;
using eshop.Mappings;
using eshop.Persistence.Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using NLog;

namespace eshop
{
    public class Startup
    {
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Constants.SecretKey));
        private IHostingEnvironment _env;


        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            LogManager.LoadConfiguration(String.Concat(env.ContentRootPath, "/nlog.config"));
            Configuration = configuration;
            _env = env;
        }



        // This method gets called by the runtime. Use this method to add services to the container.        
        public void ConfigureServices(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DomainToDtoMappingProfile());
                mc.AddProfile(new DtoToDomainMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", build =>
            {
                build.WithOrigins(new string[] { "http://localhost:4200", "http://stepup-001-site2.atempurl.com/" }).AllowAnyMethod().AllowAnyHeader();
            }));

            services.AddDbContext<eshopContext>(options =>
                options.UseSqlServer(
                        Configuration.GetConnectionString("EshopDatabase")
                )
            );

            services.AddSingleton<ILoggerManager, LoggerManager>();
            var builder = services.AddIdentityCore<Customer>(o =>
            {
                // configure identity options
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
            });
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
            builder.AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<eshopContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = Constants.SecurityTokenIssuer,
                    ValidAudience = Constants.SecurityTokenAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.SecretKey))
                };
            });

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options => options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore);

            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });

            var emailConfig = Configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.Configure<AppSettingsModel>(Configuration.GetSection("ApplicationSettings"));
            services.RegisterDependencies();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider provider, DbInitializer dbSeeder)
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider provider)
        {   
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            });            
            
            // CreateRoles(provider);
            app.ConfigureCustomExceptionMiddleware();            
            app.UseCors("ApiCorsPolicy");
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {                
                FileProvider = new PhysicalFileProvider(Path.Combine(_env.ContentRootPath, @"StaticFiles")),
                RequestPath = new PathString(Path.Combine(_env.ContentRootPath, "/StaticFiles"))
            });
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
            // dbSeeder.Seed().Wait();
        }


        private void CreateRoles(IServiceProvider serviceProvider)
        {
            // Initializing custom roles 
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<Customer>>();
            string[] roleNames = { "Admin", "Manager", "Member" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = RoleManager.RoleExistsAsync(roleName);
                if (!roleExist.Result)
                {
                    //create the roles and seed them to the database: Question 1
                    roleResult = RoleManager.CreateAsync(new IdentityRole(roleName)).Result;
                }
            }

            //Here you could create a super user who will maintain the web app
            /*var poweruser = new AppUser
            {

                UserName = Configuration["AppSettings:UserName"],
                Email = Configuration["AppSettings:UserEmail"],
            };
            //Ensure you have these values in your appsettings.json file
            string userPWD = Configuration["AppSettings:UserPassword"];
            var _user = await UserManager.FindByEmailAsync(Configuration["AppSettings:AdminUserEmail"]);

            if (_user == null)
            {
                var createPowerUser = await UserManager.CreateAsync(poweruser, userPWD);
                if (createPowerUser.Succeeded)
                {
                    //here we tie the new user to the role
                    await UserManager.AddToRoleAsync(poweruser, "Admin");
                }
            }*/
        }
    }
}
