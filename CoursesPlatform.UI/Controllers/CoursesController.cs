namespace CoursesPlatform.UI.Controllers
{
    [Route("[controller]/[action]")]
    public class CoursesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ICourseService _courseService;

        public CoursesController(ICategoryService categoryService, ICourseService courseService)
        {
            _categoryService = categoryService;
            _courseService = courseService;

        }

        public async Task<IActionResult> Index()
        {
            var courses = await _courseService.GetAllCourses();
            return View(courses);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _categoryService.GetAllCategories();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
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
    }
}
