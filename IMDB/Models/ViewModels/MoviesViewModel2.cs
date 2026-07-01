using IMDB.Models.Entities;

namespace IMDB.Models.ViewModels;

public class MoviesViewModel2
{
    public required IEnumerable<Movie> Movies { get; set; }

    public string? Title { get; set; }
    public Genre? Genre { get; set; }

}
