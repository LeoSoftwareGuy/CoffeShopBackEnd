using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Identity;

namespace Persistence.SqlDataBase
{
    public class CoffeeBackEndDbContext : IdentityDbContext<ApplicationUser>
    {
        public CoffeeBackEndDbContext(DbContextOptions<CoffeeBackEndDbContext> options) : base(options)
        {
        }
        public DbSet<CoffeeBrand> CoffeeBrands { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");
        }
    }
}