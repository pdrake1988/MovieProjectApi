using ApplicationCore.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class MovieDbContext : IdentityDbContext<User>
{
    public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) { }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Crew> Crew { get; set; }
    public DbSet<Cast> Cast { get; set; }
    public DbSet<Favorite> Favorite { get; set; }
    public DbSet<Movie> Movie { get; set; }
    public DbSet<Purchase> Purchase { get; set; }
    public DbSet<Review> Review { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<Trailer> Trailer { get; set; }
}
