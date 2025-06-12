
namespace CoursePlatform.Core.Domain.Entites
{
    public class Course:BaseEntity
    {

        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? ImageUrl { get; set; } 
        public double?   Rating { get; set; } 
        public DateTime CreatedAt { get; set; } 

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
       


    }
}
