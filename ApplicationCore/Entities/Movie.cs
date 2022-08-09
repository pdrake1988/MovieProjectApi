using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

public class Movie
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    public string Overview { get; set; }

    [Column(TypeName = "varchar(MAX)")]
    public string Tagline { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Budget { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Revenue { get; set; }

    [Column(TypeName = "varchar(2084)")]
    public string ImdbUrl { get; set; }

    [Column(TypeName = "varchar(2084)")]
    public string TmdbUrl { get; set; }

    [Column(TypeName = "varchar(2084)")]
    public string PosterUrl { get; set; }

    [Column(TypeName = "varchar(2084)")]
    public string BackdropUrl { get; set; }

    [Column(TypeName = "varchar(64)")]
    public string OriginalLanguage { get; set; }

    public DateTime ReleaseDate { get; set; }

    public int Runtime { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal Price { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    [Column(TypeName = "varchar(MAX)")]
    public string UpdatedBy { get; set; }

    [Column(TypeName = "varchar(MAX)")]
    public string CreatedBy { get; set; }

    public List<Crew> Crew { get; set; }

    public List<Genre> Genres { get; set; }

    public List<Cast> Cast { get; set; }

    public List<Trailer> Trailers { get; set; }

    public List<Review> Reviews { get; set; }

    public List<Purchase> Purchases { get; set; }

    public List<Favorite> Favorites { get; set; }
}
