using Microsoft.EntityFrameworkCore;
using ECommerceWeb.API.Models;


namespace ECommerceWeb.API.Data
{
# region DbContextClass
    public class ECommerceApplicationContext : DbContext
    {
        public ECommerceApplicationContext(DbContextOptions<ECommerceApplicationContext> options) : base(options)
        {

        }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<LogInModel> LogIn { get; set; }

        public DbSet<Product> Product { get; set; }
    }
    #endregion
}
