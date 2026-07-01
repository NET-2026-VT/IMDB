using IMDB.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IMDB.Services;

public interface IGenreSelectListService
{
    Task<IEnumerable<SelectListItem>> GetGenresAsync();
    IEnumerable<SelectListItem> GetGenres(IEnumerable<Movie> movies);
}