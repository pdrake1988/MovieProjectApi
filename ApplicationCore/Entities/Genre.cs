using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

public class Genre
{
    public int Id { get; set; }

    [Required]
    [Column(TypeName = ("varchar(64)"))]
    public string Name { get; set; }

    public List<Movie> Movies { get; set; }
}
