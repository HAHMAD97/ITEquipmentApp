using Microsoft.EntityFrameworkCore;
namespace SportsStore.Models
{
    public class FastEquipmentContext : DbContext
    {
        public FastEquipmentContext(DbContextOptions<FastEquipmentContext>
        options) : base(options) { }
        public DbSet<Product> Products => Set<Product>();
    }
}