using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

public class Cast
{
    public int Id { get; set; }

    [Column(TypeName = "varchar(128)")]
    public string Name { get; set; }

    [Column(TypeName = "varchar(6)")]
    public string Gender { get; set; }

    [Column(TypeName = "varchar(MAX)")]
    public string TmdbUrl { get; set; }

    [Column(TypeName = "varchar(2084)")]
    public string ProfilePath { get; set; }

    public List<Movie> Movies { get; set; }
}
