using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePlatform.Core.DTO
{
    public class CourseAddRequest
    {

        [Required(ErrorMessage = "Title is required")]
        [StringLength(50, ErrorMessage = "Title cannot exceed 50 characters")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Release Date is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        public DateTime? CreatedAt { get; set; }


        [Required(ErrorMessage = "Rating is required")]
        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5")]
        public double? Rating { get; set; }
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Poster is required")]
        public IFormFile? Poster { get; set; } 

        [Required(ErrorMessage = "Category is required")]
        public Guid ? CategoryId { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is CourseAddRequest request &&
                   Title == request.Title &&
                   Description == request.Description &&
                   CreatedAt == request.CreatedAt &&
                   Rating == request.Rating &&
                   ImageUrl == request.ImageUrl &&
                   EqualityComparer<Guid?>.Default.Equals(CategoryId ,request.CategoryId);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Description, CreatedAt, Rating, ImageUrl, CategoryId);
        }

        public Course ToCourse()
        {
            return new Course()
            {
                Description = Description,
                Title = Title,
                CreatedAt = CreatedAt,
                Rating = Rating,
                CategoryId = CategoryId,
                ImageUrl = ImageUrl,
            };
        }
    }
}
