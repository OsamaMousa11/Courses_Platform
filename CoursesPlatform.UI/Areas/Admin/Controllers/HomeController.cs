using CoursePlatform.Core.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoursesPlatform.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;
        private readonly IFavouriteService _favouriteService;

        public DashboardController(ICourseService courseService, ICategoryService categoryService, IUserService userService, IFavouriteService favouriteService)
        {
            _courseService = courseService;
            _categoryService = categoryService;
            _userService = userService;
            _favouriteService = favouriteService;
        }

        public async Task<IActionResult> Index()
        {
            var courses = await _courseService.GetAllCourses();
            var users = await _userService.GetAllUsers();
            var favorites = await _favouriteService.GetAllFavourites();

            var stats = new DashboardViewModel
            {
                TotalCourses = courses.Count,
                TotalUsers = users.Count,
                TotalFavorites = favorites.Count,
                LatestCourses = courses.OrderByDescending(c => c.CreatedAt).Take(5).ToList()
            };

            return View(stats);
        }
    }
}
