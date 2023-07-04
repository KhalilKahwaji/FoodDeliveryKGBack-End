
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryKG.Models;

    public class FoodDeliveryKGContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
            /*modelBuilder.Entity<User>().HasKey(u => new
            {
                u.username,
                u.password
            });*/
            
            modelBuilder.Entity<User>().HasKey(u => new
            {
                u.userid
            });
            
            modelBuilder.Entity<Restaurant>().HasKey(u => new
            {
                u.username,
                u.password,
            });
            
            modelBuilder.Entity<Restaurant>().HasKey(u => new
            {
                u.restaurantid
            });
            modelBuilder.Entity<RestaurantCategory>().HasKey(u => new
            {
               u.categoryid
            });
            
            modelBuilder.Entity<FoodCategory>().HasKey(u => new
            {
                u.categoryid
            });
            
            modelBuilder.Entity<OrderStatus>().HasKey(u => new
            {
                u.statusid
            });
            
            modelBuilder.Entity<Items>().HasKey(u => new
            {
                u.itemid
            });

            modelBuilder.Entity<Orders>().HasKey(u => new
            {
                u.orderid
            });
            
            modelBuilder.Entity<OrderDetail>().HasKey(u => new
            {
                u.orderdetailid
            });

            
        }

        public FoodDeliveryKGContext(DbContextOptions<FoodDeliveryKGContext> options) : base(options) {}

        public DbSet<User> user { get; set; }
        public DbSet<Restaurant> restaurant { get; set; }
        
        public DbSet<RestaurantCategory> restaurantcategory { get; set; }
        
        public DbSet<FoodCategory> foodcategory { get; set; }
        
        public DbSet<OrderStatus>orderstatus { get; set; }
        
        public DbSet<Items>item { get; set; }
        
        public DbSet<Orders>order { get; set; }

        public DbSet<OrderDetail>orderdetail { get; set; }
    }




