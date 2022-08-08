namespace ApplicationCore.Models;

public class MovieModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Overview { get; set; }
    public string Tagline { get; set; }
    public decimal Budget { get; set; }
    public decimal Revenue { get; set; }
    public string OriginalLanguage { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int Runtime { get; set; }
    public decimal Price { get; set; }
}
