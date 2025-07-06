using CoursePlatform.Core.Domain.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoursesPlatform.UI.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class CoursesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ICourseService _courseService;

        public CoursesController(ICategoryService categoryService, ICourseService courseService)
        {
            _categoryService = categoryService;
            _courseService = courseService;

        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var courses = await _courseService.GetAllCourses();
            return View(courses);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _categoryService.GetAllCategories();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create( CourseAddRequest courseAddRequest)
        {
            var allCourses = await _courseService.GetAllCourses();
            if (allCourses.Any(c => c.Title.Equals(courseAddRequest.Title, StringComparison.OrdinalIgnoreCase)))
            {
                ModelState.AddModelError("Title", "This course title already exists.");
            }
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _categoryService.GetAllCategories();
                return View(courseAddRequest);
            }

                await _courseService.AddCourse(courseAddRequest);
                return RedirectToAction("Index");            
         }

        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid id)
        {  
            var course = await _courseService.GetCourseById(id);

            return View(course);
        }
       

        public  async Task<IActionResult> Edit(Guid id)
        {
           var courses=  await _courseService.GetCourseById(id);
            var categories = await _categoryService.GetAllCategories();
            Guid? selectedCategoryId = courses.CategoryId;
            if (courses == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Categories = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name,
                Selected = (c.Id == selectedCategoryId)
            }).ToList();
           CourseUpdateRequest  courseUpdateRequest = courses.ToCourseUpdateRequest();
            return View(courseUpdateRequest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(CourseUpdateRequest courseUpdateRequest)
        {   
            if(!ModelState.IsValid)
            {

                var categories = await _categoryService.GetAllCategories();
                ViewBag.Categories = categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();

                ViewBag.Errors = ModelState.Values
                   .SelectMany(x => x.Errors)
                   .Select(x => x.ErrorMessage);

                return View(courseUpdateRequest);

            }
            

            await _courseService.UpdateCourse(courseUpdateRequest);

            return RedirectToAction("Index");
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _courseService.DeleteCourse(id);
            if (!result)
                return NotFound();

            TempData["Message"] = "Course deleted successfully.";
            return RedirectToAction("Index");
        }




    }
}
