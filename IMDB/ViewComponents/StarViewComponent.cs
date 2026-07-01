using Microsoft.AspNetCore.Mvc;

namespace IMDB.ViewComponents;

//[ViewComponent]
public class StarViewComponent : ViewComponent
{
    public StarViewComponent()
    {
        //Add services as usual if needed
    }

    public IViewComponentResult Invoke(float rating)
    {
        var roundedRating = (int)Math.Floor(rating);

        var model = new StarViewModel
        {
            Stars = roundedRating,
            IsHalfStar = rating % 1 >= 0.5f
        };

        return View(model);
    }
}
