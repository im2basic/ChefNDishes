using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Models
{
    public class HomeContext : DbContext
    {
        public HomeContext(DbContextOptions options) : base(options) { }
        public DbSet<Dish> Dish {get;set;}
        public DbSet<Chef> Chef {get;set;}
    }
}