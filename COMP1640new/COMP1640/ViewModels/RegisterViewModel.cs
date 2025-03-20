using System.ComponentModel.DataAnnotations;

namespace COMP1640.ViewModels;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Full Name is required")]
    public string FullName { get; set; }  // Added Full Name field

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; }
}
