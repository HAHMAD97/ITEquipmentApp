using ITEquipmentBorrowApp.Models;

public class EFEquipmentRepository : IEquipmentRepository
{
    private readonly FastEquipmentContext context;

    public EFEquipmentRepository(FastEquipmentContext ctx)
    {
        context = ctx;
    }

    public IQueryable<ITEquipment> GetAll() => context.Equipments;

    public IQueryable<ITEquipment> GetAvailable() =>
        context.Equipments.Where(e => e.IsAvailable);

    public ITEquipment FindById(int id) =>
        context.Equipments.FirstOrDefault(e => e.Id == id);

    public void Add(ITEquipment equipment)
    {
        context.Equipments.Add(equipment);
        context.SaveChanges();
    }

    public void Update(ITEquipment equipment)
    {
        context.Equipments.Update(equipment);
        context.SaveChanges();
    }

    public void Delete(ITEquipment equipment)
    {
        context.Equipments.Remove(equipment);
        context.SaveChanges();
    }
}
