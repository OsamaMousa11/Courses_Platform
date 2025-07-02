
using CoursePlatform.Core.Domain.IdentityEntites;
using Microsoft.AspNetCore.Http;

namespace CoursePlatform.Core.Domain.Entites
{
    public class Course:BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public double?   Rating { get; set; } 
        public DateTime? CreatedAt { get; set; } 

        public Guid? CategoryId { get; set; }
        public Category Category { get; set; }

    
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
       


    }
}
