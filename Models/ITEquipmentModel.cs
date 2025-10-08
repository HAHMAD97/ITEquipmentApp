namespace ITEquipmentBorrowApp.Models;
public class ITEquipment
{
    public int Id { get; set; }
    
    [Required]
    public EquipmentType Type { get; set; }
   
    [Required, StringLength(200, MinimumLength = 10)]
    public string Description { get; set; } 
    
    [Required]
    public bool IsAvailable { get; set; }
    
}

public enum EquipmentType
{
    Laptop,
    Phone,
    Tablet,
    Another
}



