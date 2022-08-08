using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

public class Review
{
    public int Id { get; set; }

    public int MovieId { get; set; }

    public Movie Movie { get; set; }

    public int UserId { get; set; }

    public User User { get; set; }

    [Column(TypeName = "decimal(3, 2)")]
    public decimal Rating { get; set; }

    [Column(TypeName = "varchar(max)")]
    public string ReviewText { get; set; }
}
