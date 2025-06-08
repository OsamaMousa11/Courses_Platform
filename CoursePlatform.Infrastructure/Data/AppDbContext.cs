
namespace CoursePlatform.Infrastructure.Data
{
    public class AppDbContext:DbContext
    {


        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set;}
        public DbSet<Course> Courses { get; set;}
        public DbSet<User> Users { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
       
       
    }
}
