namespace CoursePlatform.Core.DTO
{
    public class FavouriteResponse
    {
        public Guid CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string CourseDescription { get; set; }
        public string CourseImageUrl { get; set; }
        public string CategoryName { get; set; }
       
    }

    public static class FavouriteResponseExtensions
    {
        public static List<FavouriteResponse> ToFavouriteResponseList(this List<Favorite> favorites)
        {
            return favorites.Select(f => new FavouriteResponse
            {
                CourseId = f.Courses.Id,
                CourseTitle = f.Courses.Title,
                CourseDescription = f.Courses.Description,
                CourseImageUrl = f.Courses.ImageUrl,
                CategoryName = f.Courses.Category?.Name
            }).ToList();
        }
    }

}
