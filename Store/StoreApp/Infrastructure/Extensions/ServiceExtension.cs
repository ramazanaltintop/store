using Business.Abstract;
using Business.Concrete;
using Business.ServiceManager;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Repositories.EntityFramework;
using DataAccess.RepositoryManager;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using StoreApp.Models;

namespace StoreApp.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("sqlconnection"),
                b => b.MigrationsAssembly("StoreApp"));
            });
        }

        public static void ConfigureSession(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = "StoreApp.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<Cart>(c => SessionCart.GetCart(c));
        }

        public static void ConfigureRepositoryRegistration(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IProductRepository, EfCoreProductRepository>();
            services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
            services.AddScoped<IOrderRepository, EfCoreOrderRepository>();
        }

        public static void ConfigureServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IOrderService, OrderManager>();
        }

        public static void ConfigureRouting(this IServiceCollection services)
        {
            services.AddRouting(options => {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = false;
            });
        }
    }
}