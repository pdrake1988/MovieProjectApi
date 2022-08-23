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

    public List<Review> Reviews { get; set; }

    public List<Purchase> Purchases { get; set; }

    public List<Favorite> Favorites { get; set; }

    public List<Role> Roles { get; set; }
}
