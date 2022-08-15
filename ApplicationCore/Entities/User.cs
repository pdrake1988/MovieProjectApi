using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ApplicationCore.Entities;

public class User : IdentityUser
{
    [Column(TypeName = "varchar(128)")]
    public string FirstName { get; set; }

    [Column(TypeName = "varchar(128)")]
    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }

    [Column(TypeName = "varchar(256)")]
    public string Email { get; set; }

    [Column(TypeName = "varchar(1024)")]
    public string HashedPassword { get; set; }

    [Column(TypeName = "varchar(1024)")]
    public string Salt { get; set; }

    [Column(TypeName = "varchar(16)")]
    public string PhoneNumber { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTime LockoutEndDate { get; set; }

    public DateTime LastLoginDateTime { get; set; }

    public bool IsLocked { get; set; }

    public int AccessFailedCount { get; set; }

    public List<Review> Reviews { get; set; }

    public List<Purchase> Purchases { get; set; }

    public List<Favorite> Favorites { get; set; }

    public List<Role> Roles { get; set; }
}
