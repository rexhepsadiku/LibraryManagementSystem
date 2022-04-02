using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<Author> Authors { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            SeedUsersAndRoles.Seed(builder);
            base.OnModelCreating(builder); 
        }
    }
}
