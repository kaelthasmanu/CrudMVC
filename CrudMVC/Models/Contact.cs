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
}