
namespace CoursePlatform.Infrastructure.Data
{
    public class AppDbContext:DbContext
    {
     
        public DbSet<Category> Categories { get; set;}
        public DbSet<Course> Courses { get; set;}
        public DbSet<User> Users { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
       
       
    }
}
