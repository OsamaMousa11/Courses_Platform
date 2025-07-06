
namespace CoursePlatform.Core.Domain.RepositoryContract
{
    public  interface ICourseRepository
    {
        Task<List<Course>> GetAllCourses();
        Task<List<Course>> GetFilteredCourses(Expression<Func<Course, bool>> predict);

        Task Add(Course course);
        Task<Course> GetById(Guid id);

        Task<Course> Update(Course course);

        Task Delete(Course course);
      }
    }

