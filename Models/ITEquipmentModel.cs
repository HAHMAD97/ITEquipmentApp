namespace ITEquipmentBorrowApp.Models;
public class ITEquipment
{
    public int EquipmentId { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Availability { get; set; }
}
