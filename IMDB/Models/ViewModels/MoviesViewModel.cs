using IMDB.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IMDB.Models.ViewModels;

public class MoviesViewModel
{
    public required IEnumerable<Movie> Movies { get; set; }
    public required IEnumerable<SelectListItem> Genres { get; set; }

    public string? Title { get; set; }
    public Genre? Genre { get; set; }

}
