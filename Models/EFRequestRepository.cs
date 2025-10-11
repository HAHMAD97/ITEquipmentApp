using Microsoft.EntityFrameworkCore;
using ITEquipmentBorrowApp.Models;

public class EFRequestRepository : IRequestRepository
{
    private readonly FastEquipmentContext context;

    public EFRequestRepository(FastEquipmentContext ctx)
    {
        context = ctx;
    }

    public IQueryable<ITEquipmentRequest> GetAll()
    {
        return context.Requests
            .OrderByDescending(r => r.CreatedAt);
    }

    public IQueryable<ITEquipmentRequest> GetPending() =>
        context.Requests.Where(r => r.Status == RequestStatus.Pending);


    public void Add(ITEquipmentRequest request)
    {
        context.Requests.Add(request);
        context.SaveChanges();
    }

    public void UpdateStatus(int id, RequestStatus status)
    {
        var request = context.Requests.Find(id);
        if (request != null)
        {
            request.Status = status;
            context.SaveChanges();
        }
    }
}
