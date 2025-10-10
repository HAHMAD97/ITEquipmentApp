using Microsoft.EntityFrameworkCore;
namespace ITEquipmentBorrowApp.Models;

public static class SeedData
{
    public static void EnsurePopulated(IApplicationBuilder app)
    {
        FastEquipmentContext context = app.ApplicationServices
            .CreateScope().ServiceProvider
            .GetRequiredService<FastEquipmentContext>();

        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }

        if (!context.Equipments.Any())
        {
            context.Equipments.AddRange(
                new ITEquipment { Id = 1, Type = EquipmentType.Laptop, Description = "Dell XPS 13", IsAvailable = true },
                new ITEquipment { Id = 2, Type = EquipmentType.Laptop, Description = "HP Spectre x360", IsAvailable = false },
                new ITEquipment { Id = 3, Type = EquipmentType.Phone, Description = "iPhone 13", IsAvailable = true },
                new ITEquipment { Id = 4, Type = EquipmentType.Phone, Description = "Samsung Galaxy S21", IsAvailable = true },
                new ITEquipment { Id = 5, Type = EquipmentType.Tablet, Description = "iPad Air 2022", IsAvailable = false },
                new ITEquipment { Id = 6, Type = EquipmentType.Tablet, Description = "Samsung Galaxy Tab S7", IsAvailable = true },
                new ITEquipment { Id = 7, Type = EquipmentType.Another, Description = "Logitech Wireless Mouse", IsAvailable = true },
                new ITEquipment { Id = 8, Type = EquipmentType.Another, Description = "Dell Monitor 24-inch", IsAvailable = false }
            );

            context.SaveChanges();
        }
    }
}