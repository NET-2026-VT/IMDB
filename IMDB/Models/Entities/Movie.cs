using System.ComponentModel.DataAnnotations;

namespace IMDB.Models.Entities;

public class Movie
{
    public int Id { get; set; }

    [StringLength(20)]
    public required string Title { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Release Date")]
    public required DateTime ReleaseDate { get; set; }
    public Genre Genre { get; set; }

    [Range(1, 10)]
    public float Rating { get; set; }
}
