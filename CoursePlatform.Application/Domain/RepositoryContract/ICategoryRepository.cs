
namespace CoursePlatform.Core.Domain.RepositoryContract
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories();
        Task  Add(Category category);
        Task<int> GetNextDisplayOrder();
        Task<Category?> GetCategoryById(Guid id);
        Task<Category> UpdateCategory(Category category);
        Task DeleteCategory(Category category);



    }
}
