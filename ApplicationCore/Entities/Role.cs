using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

public class Role
{
    public int Id { get; set; }

    [Column(TypeName = "varchar(20)")]
    public string Name { get; set; }

    public List<User> Users { get; set; }
}
