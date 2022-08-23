using ApplicationCore.Entities;

namespace ApplicationCore.Models;

public class MovieModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Overview { get; set; }
    public string Tagline { get; set; }
    public decimal Budget { get; set; }
    public decimal Revenue { get; set; }
    public string ImdbUrl { get; set; }
    public string PosterUrl { get; set; }
    public string OriginalLanguage { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int Runtime { get; set; }
    public decimal Price { get; set; }
    public int GenreId { get; set; }
    public List<Genre> Genres { get; set; }
    public int CastId { get; set; }
    public List<Cast> Cast { get; set; }
    public int PurchaseId { get; set; }
    public List<Purchase> Purchases { get; set; }
    public int FavoriteId { get; set; }
    public List<Favorite> Favorites { get; set; }
}
