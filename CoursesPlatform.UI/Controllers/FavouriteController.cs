using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoursesPlatform.UI.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize]
    public class FavouriteController : Controller
    {
        private readonly IFavouriteService _favouriteService;
        private readonly IHttpContextAccessor _http;

        public FavouriteController(IFavouriteService favouriteService, IHttpContextAccessor http)
        {
            _favouriteService = favouriteService;
            _http = http;
        }

        [HttpPost]
public async Task<IActionResult> Toggle(Guid courseId)
{
    var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

    var userFavs = await _favouriteService.GetUserFavoriteCourseIds(userId);

    if (userFavs.Contains(courseId))
        await _favouriteService.RemoveFromFavourite(userId, courseId);
    else
        await _favouriteService.AddToFavourite(userId, courseId);

    return RedirectToAction("Index", "Home");
}

        public async Task<IActionResult> Wishlist()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var result = await _favouriteService.GetUserFavourites(userId);
            return View(result);
        }
    }

}
