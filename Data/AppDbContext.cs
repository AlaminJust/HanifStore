using HanifStore.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HanifStore.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<UserInformation> UserInformation { get; set; } 
        public DbSet<CustomersBuy> CustomersBuys { get; set; }
        public DbSet<CustomerDeposit> CustomerDeposits { get; set; } 
        public DbSet<Category> Categories { get; set; }  
        public DbSet<Product> Products { get; set; }   
        public DbSet<Specification> Specifications { get; set; }    
        public DbSet<Order> Orders { get; set; }    
        public DbSet<OrderItem> OrderItems { get; set; }    
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }     

    }
}
