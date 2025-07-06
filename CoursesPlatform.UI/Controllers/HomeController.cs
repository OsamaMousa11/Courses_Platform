using CoursePlatform.Core.Domain.Entites;
using CoursePlatform.Core.Enum;
using CoursePlatform.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace CoursesPlatform.UI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {


        private readonly ICourseService _courseService;
        public HomeController(ICourseService courseService)
        {
           _courseService = courseService ;
        }
        [Route("/")]
       
        public async Task<IActionResult> Index(string? searchString, string sortBy = nameof(Course.Rating), string sorted = "DESC")
        {
            List<CourseResponse> courses = await _courseService.GetAllCourses();

            if (!string.IsNullOrEmpty(searchString))
            {
                courses = await _courseService.GetFilteredCourses(nameof(Course.Title), searchString);
            }

            /*   foreach (var c in courses)
               {
                   Console.WriteLine($"Course: {c.Title} | Category: {c.CategoryName}");
               }
            */
            var categories = courses
                .Where(c => !string.IsNullOrEmpty(c.CategoryName))
                .Select(c => c.CategoryName)
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            ViewBag.currentSearchString = searchString;
            ViewBag.currentSortBy = sortBy;
            ViewBag.currentSorted = sorted;
            ViewBag.Categories = categories;

            ViewBag.sortByList = new List<SelectListItem>
    {
        new SelectListItem { Text = "Title", Value = nameof(Course.Title) },
        new SelectListItem { Text = "Rating", Value = nameof(Course.Rating) },
        new SelectListItem { Text = "Release Date", Value = nameof(Course.CreatedAt) }
    };

            List<CourseResponse> sortedCourses = (await _courseService.SortCourses(
                courses.ToList(),
                sortBy,
                sorted == "ASC" ? SortedOption.Asc : SortedOption.Desc))
                .ToList();

            return View(sortedCourses);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
