using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Infrastructure.Identity;
using LibraryManagementSystem.Infrastructure.Persistence;
using LibraryManagementSystem.Infrastructure.Persistence.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagementSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("LibraryManagementSystem"));
            });

            services.AddIdentity<AppUser, IdentityRole>()
                .AddDefaultTokenProviders()
                .AddUserManager<UserManager<AppUser>>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBorrowRepository, BorrowRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddAuthentication();

            return services;
        }
    }
}
