

namespace CoursePlatform.Core.ServiceContract
{
    public interface ICourseService
    {
        Task<List<CourseResponse>> GetAllCourses();
        Task<List<CourseResponse>> GetFilteredCourses(string searchBy, string searchString);
        Task<List<CourseResponse>> SortCourses(List<CourseResponse> Course, string sortBy, SortedOption sortedOption);
        Task<CourseResponse> AddCourse(CourseAddRequest courseRequest);

        Task<CourseResponse> GetCourseById(Guid id);


    }
}
