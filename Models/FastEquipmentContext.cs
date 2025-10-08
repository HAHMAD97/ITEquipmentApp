using ITEquipmentBorrowApp.Models;
using Microsoft.EntityFrameworkCore;
namespace SportsStore.Models
{
    public class FastEquipmentContext : DbContext
    {
        public FastEquipmentContext(DbContextOptions<FastEquipmentContext>
        options) : base(options) { }
        public DbSet<ITEquipment> Equipments => Set<ITEquipment>();
        public DbSet<ITEquipmentRequest> Requests => Set<ITEquipmentRequest>();
    }
}