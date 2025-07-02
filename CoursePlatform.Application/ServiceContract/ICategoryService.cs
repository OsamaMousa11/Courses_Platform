
namespace CoursePlatform.Core.ServiceContract
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();
        Task<CategoryResponse>AddCategory(CategoryAddRequest? Add);
        Task<List<CategoryResponse>> GetFilteredCategory(string searchBy, string? searchString);
        Task<List<CategoryResponse>> GetSortedCategory(List<CategoryResponse> allPersons, string sortBy, SortedOption sortOrder);
        Task<CategoryResponse> GetCategoryById(Guid? id);
        Task<CategoryResponse> UpdateCategory(CategoryUpdateRequest? request );
        Task<bool> DeleteCategory(Guid id);

    }

}
