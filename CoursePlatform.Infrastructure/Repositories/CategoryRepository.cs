using System.Linq.Expressions;

namespace CoursePlatform.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetNextDisplayOrder()
        {

            return await _context.Categories.MaxAsync(c => c.DisplayOrder) + 1;
        }

        public async Task Add(Category category)
        {      
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _context.Categories.OrderBy(c => c.DisplayOrder).ToListAsync();
        }

        public async Task<Category?> GetCategoryById(Guid id)
        {
            var Category = await _context.Categories.FirstOrDefaultAsync(d => d.Id == id);
            return Category;
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            Category? mathingPerson = await _context.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);
       
            mathingPerson.Name = category.Name;
            mathingPerson.DisplayOrder = category.DisplayOrder;
            mathingPerson.Id = category.Id;
            int countUpdated = await _context.SaveChangesAsync();
            return mathingPerson;

        }

        public  async Task DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetFilteredCategory(Expression<Func<Category, bool>> predicate)
        {
           return await _context.Categories.Where(predicate).ToListAsync();
        }

     
    }
}
