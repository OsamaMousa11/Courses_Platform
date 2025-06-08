
namespace CoursesPlatform.UI.Controllers
{
    [Route("[controller]")]
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [Route("[action]")]
        public async Task<IActionResult> Index(string searchString, string sortOrder)
        {

            var categories = await _categoryService.GetFilteredSortedCategories(searchString, sortOrder);
            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentSort = sortOrder;
            return View(categories);
        }
        [Route("[action]")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        public async Task<IActionResult> Create(CategoryAddRequest request)
        {
                await _categoryService.AddCategory(request);
                return RedirectToAction("Index");

        }
        [Route("[action]/{Id}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            CategoryResponse? Response = await _categoryService.GetCategoryById(id);
            if(Response == null)
            {
                return RedirectToAction("Index");
            }
           CategoryUpdateRequest CategoryUpdateRequest = Response.TocategoryUpdateRequest();

            return View(CategoryUpdateRequest);

           
        }
        [HttpPost]
        [Route("[action]/{Id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryUpdateRequest request)
        {    
            CategoryResponse categoryResponse=await _categoryService.GetCategoryById(request.Id);
            if(categoryResponse==null)
            {
                return RedirectToAction("Index");
            }
            var _id= request.Id;
            CategoryResponse Updatecategory=await  _categoryService.UpdateCategory(request);

           return RedirectToAction("Index");

        }
     

        [HttpGet]
        [Route("[action]/{Id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _categoryService.DeleteCategory(id);
            if (!result)
                return NotFound();

            
            return RedirectToAction("Index");
        }





    }
}
