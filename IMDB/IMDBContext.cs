using IMDB.Models.Entities;
using Microsoft.EntityFrameworkCore;

public class IMDBContext : DbContext
{
    public DbSet<Movie> Movie => Set<Movie>();

    public IMDBContext(DbContextOptions<IMDBContext> options) : base(options)
    {
    }
}
