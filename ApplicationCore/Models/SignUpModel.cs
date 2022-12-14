using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models;

public class SignUpModel
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    [Compare("ConfirmedPassword")]
    public string Password { get; set; }

    [Required]
    public string ConfirmedPassword { get; set; }
}
