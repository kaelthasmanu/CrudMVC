using System.ComponentModel.DataAnnotations;

namespace CrudMVC.Models;

public class Contact
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "The field Name is required")]
    [StringLength(100, ErrorMessage = "The field Name must be a maximum length of 100 characters")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "The field Email is required")]
    [EmailAddress(ErrorMessage = "The field Email is invalid")]
    [StringLength(100, ErrorMessage = "The field Email must be a maximum length of 100 characters")]
    public string Email { get; set; }
    
    [Phone(ErrorMessage = "Format phone is invalid")]
    [StringLength(20, ErrorMessage = "The field Phone must be a maximum length of 20 characters")]
    public string Phone { get; set; }
    
    [StringLength(100, ErrorMessage = "The field Message must be a maximum length of 100 characters")]
    public string Direction { get; set; }
}