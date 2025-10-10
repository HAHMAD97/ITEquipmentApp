using ITEquipmentBorrowApp.Models;

public interface IEquipmentRepository
{
    IQueryable<ITEquipment> GetAll();
    IQueryable<ITEquipment> GetAvailable();
    ITEquipment FindById(int id);
    void Add(ITEquipment equipment);
    void Update(ITEquipment equipment);
    void Delete(ITEquipment equipment);
}
