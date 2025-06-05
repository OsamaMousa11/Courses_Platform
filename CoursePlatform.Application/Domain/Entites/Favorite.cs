


namespace CoursePlatform.Core.Domain.Entites
{
    public class Favorite
    {

   
        public Guid User_Id { get; set; }
        public Guid Course_Id { get; set; }
      
        public User Users { get; set; } 
        public Course Courses { get; set; }
    }
}
