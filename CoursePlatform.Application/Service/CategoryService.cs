namespace CoursePlatform.Core.Service
{
    public class CategoryService : ICategoryService
    {  
        private readonly ICategoryRepository _db;
        public CategoryService(ICategoryRepository db)
        {
            _db = db;
        }

        public async Task<CategoryResponse>AddCategory(CategoryAddRequest categoryRequest)
        {
            if (categoryRequest == null)
            {
                throw new ArgumentNullException(nameof(categoryRequest));
            }

            var category = categoryRequest.ToCategory();
            category.DisplayOrder =await _db.GetNextDisplayOrder();
            category.Id= Guid.NewGuid();

            await _db.Add(category);  
            return  category.ToCategoryResponse();
        }

        public  async Task<bool> DeleteCategory(Guid id)
        {
            var category = await _db.GetCategoryById(id);
            if (category == null)
                return false;

            await _db.DeleteCategory(category);
            return true;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _db.GetAllCategories();
        }



        public  async Task<CategoryResponse> GetCategoryById(Guid? id)
        {
            if (id == null) return null;
            Category? category = await _db.GetCategoryById(id.Value);
            if (category == null) return null;

            return category.ToCategoryResponse();
        }

        public async Task<List<CategoryResponse>> GetFilteredSortedCategories(string? search, string? sortOrder)
        {
            var categories = await _db.GetAllCategories();

            if (!string.IsNullOrWhiteSpace(search))
            {
                categories = categories
                    .Where(c => c.Name.ToLower().Contains(search.ToLower()))
                    .ToList();
            }

            categories = sortOrder switch
            {
                "name_asc" => categories.OrderBy(c => c.Name).ToList(),
                "name_desc" => categories.OrderByDescending(c => c.Name).ToList(),
                "displayOrder_asc" => categories.OrderBy(c => c.DisplayOrder).ToList(),
                "displayOrder_desc" => categories.OrderByDescending(c => c.DisplayOrder).ToList(),
                _ => categories.OrderBy(c => c.DisplayOrder).ToList(),
            };

            return categories.Select(c => c.ToCategoryResponse()).ToList(); 
        }

        public async Task<CategoryResponse> UpdateCategory(CategoryUpdateRequest? request)
        {
            if(request==null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            Category? matchingCategory = await _db.GetCategoryById(request.Id);
            if(matchingCategory==null)
                throw new ArgumentNullException(nameof(matchingCategory));
            matchingCategory.Id = request.Id;
            matchingCategory.Name = request.Name;
            
            await _db.UpdateCategory(matchingCategory);
             
            return matchingCategory.ToCategoryResponse();
        }
    }
}
