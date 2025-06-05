using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CoursePlatform.Infrastructure.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server = DESKTOP-HJ8FB72\\SQLEXPRESS; Database =CoursesPlatform; Integrated Security = SSPI; TrustServerCertificate = True;MultipleActiveResultSets=True;");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}