
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryKG.Models;

    public class FoodDeliveryKGContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
            modelBuilder.Entity<User>().HasKey(u => new
            {
                u.username,
                u.password,
            });
        }

        public FoodDeliveryKGContext(DbContextOptions<FoodDeliveryKGContext> options) : base(options) {}

        public DbSet<User> users { get; set; }
        public DbSet<Restaurant> restaurants { get; set; }

    }




