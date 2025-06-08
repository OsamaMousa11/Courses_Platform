namespace CoursePlatform.Core.ServiceContract
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();
        Task<CategoryResponse>AddCategory(CategoryAddRequest? Add);
        Task<List<CategoryResponse>> GetFilteredSortedCategories(string? search, string? sortOrder);
        Task<CategoryResponse> GetCategoryById(Guid? id);
        Task<CategoryResponse> UpdateCategory(CategoryUpdateRequest? request );
        Task<bool> DeleteCategory(Guid id);

    }

}
