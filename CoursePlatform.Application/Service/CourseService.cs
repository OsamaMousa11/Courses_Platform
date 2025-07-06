
namespace CoursePlatform.Core.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IFileService _fileServices;

        public CourseService(ICourseRepository courseRepository , IFileService fileServices)
        {
            _courseRepository = courseRepository;
            _fileServices = fileServices;
        }

        public async Task<CourseResponse> AddCourse(CourseAddRequest courseRequest)
        {
            if (courseRequest == null)
                throw new ArgumentNullException(nameof(courseRequest));

            if (courseRequest.Poster == null)
                throw new ArgumentNullException(nameof(courseRequest.Poster));

            string imageUrl = await _fileServices.CreateFile(courseRequest.Poster);
            courseRequest.ImageUrl = imageUrl;

            ValidationHelper.ModelValidation(courseRequest);

            var existingCourse = (await _courseRepository.GetAllCourses())
                .FirstOrDefault(c => c.Title.Equals(courseRequest.Title, StringComparison.OrdinalIgnoreCase));

            if (existingCourse != null)
                throw new InvalidOperationException("Course with same title already exists");

            var course = courseRequest.ToCourse();
            course.Id = Guid.NewGuid();

            await _courseRepository.Add(course);

            return course.ToCourseResponse();


        }

        public  async Task<CourseResponse> UpdateCourse(CourseUpdateRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            ValidationHelper.ModelValidation(request);

            var course = await _courseRepository.GetById(request.CourseId);
            if (course == null)
                throw new KeyNotFoundException("Course not found");

            
            if (request.Poster != null)
            {
                string fileName = await _fileServices.Updatefile(request.Poster, course.ImageUrl);
                request.ImageUrl = fileName;
                course.ImageUrl = fileName;
            }

            course.Title = request.Title;
            course.Description = request.Description;
            course.CreatedAt = request.CreatedAt;
            course.Rating = request.Rating;
            course.CategoryId = request.CategoryId;

            await _courseRepository.Update(course);

            return course.ToCourseResponse();
        }
        

        public  async Task<List<CourseResponse>> GetAllCourses()
        {
            var courses= await _courseRepository.GetAllCourses();

            return  courses.Select(x=>x.ToCourseResponse()).ToList();
           
        }

        public async Task<CourseResponse> GetCourseById(Guid id)
        {
            if (id == null) return null;
            var course = await _courseRepository.GetById(id);
            if (course == null) return null;

            return course.ToCourseResponse();
        }

        public  async Task<List<CourseResponse>> GetFilteredCourses(string searchBy, string searchString)
        {
            if(!string.IsNullOrEmpty(searchString))
            {
                searchString= searchString.ToLower();
            }
            List<Course> matchcourses = searchBy switch
            {
                nameof(Course.Title) =>
                (await _courseRepository.GetFilteredCourses(temp =>
                temp.Title.ToLower().Contains(searchString))).ToList(),

                nameof(Course.Description) =>
                (await _courseRepository.GetFilteredCourses(temp =>
                temp.Description.ToLower().Contains(searchString))).ToList(),

                nameof(Course.Category) =>
                (await _courseRepository.GetFilteredCourses(temp =>
                temp.Category.Name.ToLower().Contains(searchString))).ToList(),

                
                _ => (await _courseRepository.GetAllCourses()).ToList()
            };

            return matchcourses.Select(temp => temp.ToCourseResponse()).ToList();
        }

     

        public async  Task<List<CourseResponse>> SortCourses(List<CourseResponse> course, string Sortby, SortedOption sortedOption)
        {
            if(course == null)
                throw new ArgumentNullException(nameof(course));

            var sortCourses = (Sortby, sortedOption) switch
            {
                (nameof(Course.Title), SortedOption.Asc) => course.OrderBy(c => c.Title, StringComparer.OrdinalIgnoreCase).ToList(),
                (nameof(Course.Title), SortedOption.Desc) => course.OrderByDescending(c => c.Title, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(Course.Rating), SortedOption.Asc) => course.OrderBy(c => c.Rating).ToList(),
                (nameof(Course.Rating), SortedOption.Desc) => course.OrderByDescending(c => c.Rating).ToList(),

                (nameof(Course.CreatedAt), SortedOption.Asc) => course.OrderBy(c => c.CreatedAt).ToList(),
                (nameof(Course.CreatedAt), SortedOption.Desc) => course.OrderByDescending(c => c.CreatedAt).ToList(),
                _=> course

            };
            return await Task.FromResult(sortCourses);
        }

        public async Task<bool> DeleteCourse(Guid id)
        {
            if (id == null)
                return false;
            var course = await _courseRepository.GetById(id);
            if (course == null)
                return false;
            await _courseRepository.Delete(course);
            return true;

        }
    }
}
