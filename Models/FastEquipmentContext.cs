using Microsoft.EntityFrameworkCore;
namespace ITEquipmentBorrowApp.Models;

public class FastEquipmentContext : DbContext
{
    public FastEquipmentContext(DbContextOptions<FastEquipmentContext>
    options) : base(options) { }
    public DbSet<ITEquipment> Equipments => Set<ITEquipment>();
    public DbSet<ITEquipmentRequest> Requests => Set<ITEquipmentRequest>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ITEquipmentRequest>().OwnsOne(e => e.Borrow);
        modelBuilder.Entity<ITEquipmentRequest>().OwnsOne(e => e.Requester);
    }
}