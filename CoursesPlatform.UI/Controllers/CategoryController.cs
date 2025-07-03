
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
        
        public async Task<IActionResult> Index(string searchBy, string? searchString, string sortBy = nameof(CategoryResponse.Name),SortedOption sortOrder = SortedOption.Asc)
        {   
            ViewBag.SortBy = sortBy;
            ViewBag.SortOrder = sortOrder;
            ViewBag.SearchBy = searchBy;
            ViewBag.SearchString = searchString;

            var categories=await _categoryService.GetFilteredCategory(searchBy, searchString);
            var sortedCategories = await _categoryService.GetSortedCategory(categories, sortBy, sortOrder);

            return View(sortedCategories);

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
        public async Task<IActionResult> Edit(CategoryUpdateRequest request)
        {    
            CategoryResponse categoryResponse=await _categoryService.GetCategoryById(request.Id);
            if(categoryResponse==null)
            {
                return RedirectToAction("Index");
            }
           
            CategoryResponse Updatecategory=await  _categoryService.UpdateCategory(request);

           return RedirectToAction("Index");

        }

        [HttpGet]
        [Route("[action]/{Id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _categoryService.DeleteCategory(id);
            if (!result)
                return NotFound();

            return RedirectToAction("Index");
        }




    }
}
