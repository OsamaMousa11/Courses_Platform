namespace CoursePlatform.Infrastructure.Repositories
{
    public class CategoryRepositoy : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepositoy(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetNextDisplayOrder()
        {
            if (!await _context.Categories.AnyAsync())
            {
                Console.WriteLine("No categories found, returning 1");
                return 1;
            }
            return await _context.Categories.MaxAsync(c => c.DisplayOrder) + 1;
        }

        public async Task Add(Category category)
        {
            if (await _context.Categories.AnyAsync(c => c.Name.ToLower() == category.Name.ToLower()))
            {
                throw new InvalidOperationException("this Category Already Exits");
            }
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
            if (mathingPerson == null)
            {
                return category;
            }
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
    }
}
