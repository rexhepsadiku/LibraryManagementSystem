using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
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
            base.OnModelCreating(builder);
            this.SeedUsers(builder);
            this.SeedRoles(builder);
            this.SeedUserRoles(builder);
        }

        private void SeedUsers(ModelBuilder builder)
        {
            AppUser user = new AppUser()
            {
                Id = "fbacdbdd-7ab5-468a-a21e-eb86233447d2",
                FirstName = "Rexhep",
                LastName = "Sadiku",
                UserName = "rexhep@admin.com",
                Email = "rexhep@admin.com",
                NormalizedEmail = "REXHEP@ADMIN.COM",
                NormalizedUserName = "REXHEP@ADMIN.COM"
            };

            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
            passwordHasher.HashPassword(user, "Pa$$w0rd");

            builder.Entity<AppUser>().HasData(user);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "ADMIN" },
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "User", ConcurrencyStamp = "2", NormalizedName = "USER" },
                new IdentityRole() { Id = "b74ddd14-6340-4840-95c2-db12554843e5", Name = "SuperAdmin", ConcurrencyStamp = "3", NormalizedName = "SUPERADMIN" }
                );
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "b74ddd14-6340-4840-95c2-db12554843e5", UserId = "fbacdbdd-7ab5-468a-a21e-eb86233447d2" }
                );
        }
    }
}
