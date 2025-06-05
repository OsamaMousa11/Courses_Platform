
namespace CoursePlatform.Core.Domain.Entites
{
    public class Category:BaseEntity
    { 
        public int DisplayOrder { get; set; }
        public ICollection<Course> Courses{ get; set; } 
        
    }
}
