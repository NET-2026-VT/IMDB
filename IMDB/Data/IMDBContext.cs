using IMDB.Models.Entities;
using Microsoft.EntityFrameworkCore;

public class IMDBContext : DbContext
{
    public DbSet<Movie> Movie => Set<Movie>();

    public IMDBContext(DbContextOptions<IMDBContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Movie>().HasData
            (
                 new Movie
                 {
                     Id = 1,
                     Title = "Titanic",
                     Genre = Genre.Drama,
                     ReleaseDate = new DateTime(1997, 1, 16),
                     Rating = 7.9F
                 },
            new Movie
            {
                Id = 2,
                Title = "Scream",
                Genre = Genre.Horror,
                ReleaseDate = new DateTime(1997, 8, 1),
                Rating = 7.4F
            },
            new Movie
            {
                Id = 3,
                Title = "The Shining",
                Genre = Genre.Horror,
                ReleaseDate = new DateTime(1980, 9, 26),
                Rating = 8.4F
            },
            new Movie
            {
                Id = 4,
                Title = "300",
                Genre = Genre.Action,
                ReleaseDate = new DateTime(2007, 4, 4),
                Rating = 7.6F
            },
            new Movie
            {
                Id = 5,
                Title = "Interstellar",
                Genre = Genre.Drama,
                ReleaseDate = new DateTime(2014, 11, 7),
                Rating = 8.7F
            },
            new Movie
            {
                Id = 6,
                Title = "The Dark Knight",
                Genre = Genre.Action,
                ReleaseDate = new DateTime(2008, 7, 25),
                Rating = 9.1F
            }
            );
    }
}
