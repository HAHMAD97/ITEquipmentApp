namespace ITEquipmentBorrowApp.Models;

public class RequestWithEquipmentViewModel
{
    public int RequestId { get; set; }
    public string RequesterName { get; set; }
    public string RequesterRole { get; set; }
    public string EquipmentType { get; set; }
    public int DurationDays { get; set; }
    public RequestStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
}