using System.ComponentModel.DataAnnotations;
namespace ITEquipmentBorrowApp.Models;

public class ITEquipmentRequest
{

    public int Id { get; set; }

    [Required(ErrorMessage = "Please enter your name")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Please enter your email address")]
    [EmailAddress]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Please enter your phone number")]
    [Phone]
    [RegularExpression(@"^\d{3}-\d{3}-\d{4}$",
            ErrorMessage = "Phone number must be in format xxx-xxx-xxxx.")]
    public string? Phone { get; set; }

    [Required(ErrorMessage = "Please specify your role whether you're a student or professor")]
    public string? RequesterRole { get; set; }

    [Required(ErrorMessage = "Please enter the type of equipment being requested")]
    public string? EquipmentType { get; set; }

    [Required(ErrorMessage = "Please provide a reason for the request")]
    public string? RequestDetails { get; set; }

    [Required(ErrorMessage = "Please provide the duration (number of days) you need the equipment for")]
    [Range(1, int.MaxValue, ErrorMessage = "Duration must be greater than 0")]
    public int Duration { get; set; } 
    

}