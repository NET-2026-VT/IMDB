
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IMDB.Models.Entities;
using IMDB.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using IMDB.Services;

public class MoviesController : Controller
{
    private readonly IMDBContext _context;
    private readonly IGenreSelectListService _genreSelectList;

    public MoviesController(IMDBContext context, IGenreSelectListService genreSelectList)
    {
        _context = context;
        this._genreSelectList = genreSelectList;
    }

    // GET: MOVIES
    public async Task<IActionResult> Index()    
    {
        //ViewBag.Test = "Hej";
        //ViewBag.Testing = "Hej";
        //ViewData["Test2"] = "Hej2";
       
        //TempData["Test3"] = "Hej4";

        return View(await _context.Movie.ToListAsync());
    }
    public async Task<IActionResult> IndexWithViewModel()    
    {
        var movies = await _context.Movie.ToListAsync();

        var model = new MoviesViewModel
        {
            Movies = movies,
            Genres = _genreSelectList.GetGenres(movies)
        };
   
        return View(model);
    }

    public async Task<IActionResult> Filter(string? title, int? genre)
    {
        var model = string.IsNullOrWhiteSpace(title) ?
                        _context.Movie :
                        _context.Movie.Where(m => m.Title.StartsWith(title.Trim()));

        model = genre.HasValue ?
                        model.Where(m => (int)m.Genre == genre) :
                        model;

        return View(nameof(Index), await model.ToListAsync());
    }

    public async Task<IActionResult> FilterViewModel(MoviesViewModel viewModel)
    {
        IQueryable<Movie> movies = _context.Movie;

        if(!string.IsNullOrWhiteSpace(viewModel.Title))
                   movies = movies.Where(m => m.Title.StartsWith(viewModel.Title.Trim()));

        if(viewModel.Genre.HasValue)
                    movies = movies.Where(m => m.Genre == viewModel.Genre);

        var model = new MoviesViewModel
        {
            Movies = await movies.ToListAsync(),
            Genres = await _genreSelectList.GetGenresAsync(),
            Title = viewModel.Title,
            Genre = viewModel.Genre,
        };

        //ModelState.Clear();

        return View(nameof(IndexWithViewModel), model);
    }

    // GET: MOVIES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var movie = await _context.Movie
            .FirstOrDefaultAsync(m => m.Id == id);
        if (movie == null)
        {
            return NotFound();
        }

        return View(movie);
    }

    // GET: MOVIES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: MOVIES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Rating")] Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Add(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(movie);
    }

    // GET: MOVIES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var movie = await _context.Movie.FindAsync(id);
        if (movie == null)
        {
            return NotFound();
        }
        return View(movie);
    }

    // POST: MOVIES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Title,ReleaseDate,Genre,Rating")] Movie movie)
    {
        if (id != movie.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(movie);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(movie.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(movie);
    }

    // GET: MOVIES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var movie = await _context.Movie
            .FirstOrDefaultAsync(m => m.Id == id);
        if (movie == null)
        {
            return NotFound();
        }

        return View(movie);
    }

    // POST: MOVIES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var movie = await _context.Movie.FindAsync(id);
        if (movie != null)
        {
            _context.Movie.Remove(movie);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MovieExists(int? id)
    {
        return _context.Movie.Any(e => e.Id == id);
    }
}
