
using CoursePlatform.Infrastructure.Data;

public class Seed_Category
{
    private readonly AppDbContext _context;

    public Seed_Category(AppDbContext context)
    {
        _context = context;
    }

    public void Seed()
    {
        _context.Database.EnsureCreated();

        if (!_context.Categories.Any())
        {
            Console.WriteLine("Seeding categories...");

            var categories = new List<Category>
            {
                new Category { Id = Guid.NewGuid(), Name = "Programming", DisplayOrder = 1 },
                new Category { Id = Guid.NewGuid(), Name = "Design", DisplayOrder = 2 },
                new Category { Id = Guid.NewGuid(), Name = "Marketing", DisplayOrder = 3 },
                new Category { Id = Guid.NewGuid(), Name = "Photography", DisplayOrder = 4 },
                new Category { Id = Guid.NewGuid(), Name = "Business", DisplayOrder = 5 },
                new Category { Id = Guid.NewGuid(), Name = "Personal Development", DisplayOrder = 6 },
            };

            _context.Categories.AddRange(categories);
            _context.SaveChanges();

            Console.WriteLine("Categories seeded successfully.");
        }
        else
        {
            Console.WriteLine("Categories already exist in database.");
        }
    }
}
