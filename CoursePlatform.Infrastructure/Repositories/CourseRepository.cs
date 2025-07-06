
namespace CoursePlatform.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {   
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public  async Task Add(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public  async Task Delete(Course course)
        {
         
             _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }

        public async  Task<List<Course>> GetAllCourses()
        {
             return await _context.Courses
                .Include(c => c.Category)
                .AsNoTracking().ToListAsync();
        }

        public async  Task<Course> GetById(Guid id)
        {
           return await _context.Courses
                .Include(c => c.Category)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async  Task<List<Course>> GetFilteredCourses(Expression<Func<Course, bool>> predict)
        {
            return await _context.Courses
                .Where(predict)
                .Include(c => c.Category)
                .AsNoTracking().ToListAsync();
        }

        public async  Task<Course> Update(Course course)
        {
            _context.Courses.Update(course); 
            await _context.SaveChangesAsync();
            return course;
        }
    }
}
