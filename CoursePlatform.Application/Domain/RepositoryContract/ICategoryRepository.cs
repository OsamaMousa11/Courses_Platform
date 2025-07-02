
using System;
using System.Linq.Expressions;

namespace CoursePlatform.Core.Domain.RepositoryContract
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories();
        Task Add(Category category);
        Task<int> GetNextDisplayOrder();
        Task<Category?> GetCategoryById(Guid id);
        Task<List<Category>> GetFilteredCategory (Expression<Func<Category, bool>> predicate);
        Task<Category> UpdateCategory(Category category);
        Task DeleteCategory(Category category);



    }
}
