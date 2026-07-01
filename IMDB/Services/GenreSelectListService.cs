using IMDB.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Services;

public class GenreSelectListService(IMDBContext _context) : IGenreSelectListService
{
    public IEnumerable<SelectListItem> GetGenres(IEnumerable<Movie> movies)
    {
        return movies.Select(m => m.Genre)
                           .Distinct()
                           .Select(g => new SelectListItem
                           {
                               Text = g.ToString(),
                               Value = g.ToString()
                           })
                           .ToList();
    }

    public async Task<IEnumerable<SelectListItem>> GetGenresAsync()
    {
        return await _context.Movie
                           .Select(m => m.Genre)
                           .Distinct()
                           .Select(g => new SelectListItem
                           {
                               Text = g.ToString(),
                               Value = g.ToString()
                           })
                           .ToListAsync();
    }
}
