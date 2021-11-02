using Microsoft.EntityFrameworkCore;
using RestaurantsProjectApi.Entities;

namespace RestaurantsProjectApi.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Menu>()
        //        .HasMany(m => m.Restaurant)
        //        .WithOne()
        //        .HasForeignKey(re => re.MenuId);
        //}

    }
}
