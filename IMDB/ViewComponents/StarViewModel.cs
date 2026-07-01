namespace IMDB.ViewComponents;

internal class StarViewModel
{
    public string FullStarUrl =>
      "https://upload.wikimedia.org/wikipedia/commons/e/e5/Full_Star_Yellow.svg";

    public string HalfStarUrl =>
        "https://upload.wikimedia.org/wikipedia/commons/d/d6/Half_Star_Yellow.svg";

    public int Stars { get; set; }
    public bool IsHalfStar { get; set; }
}