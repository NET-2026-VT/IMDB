namespace IMDB.Models.Entities;

public class Movie
{
    public int Id { get; set; }
    public required string Title { get; set; } 
    public required DateTime ReleaseDate { get; set; }
    public Genre Genre { get; set; }
    public int Rating { get; set; }
}
