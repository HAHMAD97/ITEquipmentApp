using ITEquipmentBorrowApp.Models;

public interface IRequestRepository
{
    IQueryable<ITEquipmentRequest> GetAll();
    IQueryable<ITEquipmentRequest> GetPending();
    void Add(ITEquipmentRequest request);
    void UpdateStatus(int id, RequestStatus status);
}