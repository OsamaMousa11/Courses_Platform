

namespace CoursePlatform.Core.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _CategoryRepository;
        public CategoryService(ICategoryRepository db)
        {
            _CategoryRepository = db;
        }

        public async Task<CategoryResponse> AddCategory(CategoryAddRequest categoryRequest)
        {
            if (categoryRequest == null)
            {
                throw new ArgumentNullException(nameof(categoryRequest));
            }
            ValidationHelper.ModelValidation(categoryRequest);

            var existingCategory = (await _CategoryRepository.GetAllCategories())
             .FirstOrDefault(c => c.Name.Equals(categoryRequest.Name, StringComparison.OrdinalIgnoreCase));


            var category = categoryRequest.ToCategory();
            category.DisplayOrder = await _CategoryRepository.GetNextDisplayOrder();
            category.Id = Guid.NewGuid();


            await _CategoryRepository.Add(category);
            return category.ToCategoryResponse();
        }

        public async Task<bool> DeleteCategory(Guid id)
        {
            var category = await _CategoryRepository.GetCategoryById(id);
            if (category == null)
                return false;

            await _CategoryRepository.DeleteCategory(category);
            return true;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _CategoryRepository.GetAllCategories();
        }



        public async Task<CategoryResponse> GetCategoryById(Guid? id)
        {
            if (id == null) return null;
            Category? category = await _CategoryRepository.GetCategoryById(id.Value);
            if (category == null) return null;

            return category.ToCategoryResponse();
        }

        public async Task<List<CategoryResponse>> GetFilteredCategory(string searchBy, string? searchString)
        {
            
            List<Category> category = searchBy switch
            {
                nameof(CategoryResponse.Name) =>
                 await _CategoryRepository.GetFilteredCategory(
                 temp =>
                 temp.Name.Contains(searchString)),

                nameof(CategoryResponse.DisplayOrder) =>
               await _CategoryRepository.GetFilteredCategory(
               temp =>
               temp.DisplayOrder.ToString().Contains(searchString)),

                _ => await _CategoryRepository.GetAllCategories()
            };
            
            return category.Select(temp => temp.ToCategoryResponse()).ToList();
        }

     
        public async Task<List<CategoryResponse>> GetSortedCategory(List<CategoryResponse> allCategory, string sortBy, SortedOption sortOrder)
        {
            

            if (string.IsNullOrEmpty(sortBy))
                return allCategory;

            List<CategoryResponse> sortedPersons = (sortBy, sortOrder) switch
            {
                (nameof(CategoryResponse.Name), SortedOption.Asc) =>
                    allCategory.OrderBy(temp => temp.Name, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(CategoryResponse.Name), SortedOption.Desc) =>
                    allCategory.OrderByDescending(temp => temp.Name, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(CategoryResponse.DisplayOrder), SortedOption.Asc) =>
                    allCategory.OrderBy(temp => temp.DisplayOrder).ToList(),

                (nameof(CategoryResponse.DisplayOrder), SortedOption.Desc) =>
                    allCategory.OrderByDescending(temp => temp.DisplayOrder).ToList(),

                _ => allCategory
            };
            return sortedPersons;
;
        }

        public async Task<CategoryResponse> UpdateCategory(CategoryUpdateRequest? categoryUpdateRequest)
        {
            if(categoryUpdateRequest==null)
            {
                throw new ArgumentNullException(nameof(categoryUpdateRequest));
            }
            ValidationHelper.ModelValidation(categoryUpdateRequest);
             
            Category? matchingCategory = await _CategoryRepository.GetCategoryById(categoryUpdateRequest.Id);
            if(matchingCategory==null)
                throw   new ArgumentNullException(nameof(matchingCategory));
            matchingCategory.Id = categoryUpdateRequest.Id;
            matchingCategory.Name = categoryUpdateRequest.Name;
            
            await _CategoryRepository.UpdateCategory(matchingCategory);
             
            return matchingCategory.ToCategoryResponse();
        }
    }
}
