
using CoursePlatform.Core.Domain.IdentityEntites;
using CoursePlatform.Infrastructure.Configration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CoursePlatform.Infrastructure.Data
{
    public class AppDbContext: IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {


        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set;}
        public DbSet<Course> Courses { get; set;}
        public DbSet<ApplicationUser> Users{ get; set; }
        public DbSet<Favorite> Favorites { get; set; }


       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
       
       
    }
}
