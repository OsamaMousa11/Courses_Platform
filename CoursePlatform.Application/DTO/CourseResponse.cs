using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePlatform.Core.DTO
{
    public  class CourseResponse
    {

        public Guid CourseId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public double? Rating { get; set; }
        public string? ImageUrl { get; set; }
        public Guid? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public double? ProducedSince { get; set; }


        public override bool Equals(object? obj)
        {
            return obj is CourseResponse response &&
                   CourseId.Equals(response.CourseId) &&
                   Title == response.Title &&
                   Description == response.Description &&
                   CreatedAt == response.CreatedAt &&
                   Rating == response.Rating &&
                   ImageUrl == response.ImageUrl &&
                   EqualityComparer<Guid?>.Default.Equals(CategoryId, response.CategoryId) &&
                   CategoryName == response.CategoryName&&
                   ProducedSince == response.ProducedSince;

        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(CategoryId);
            hash.Add(Title);
            hash.Add(Description);
            hash.Add(CreatedAt);
            hash.Add(Rating);
            hash.Add(ImageUrl);
            hash.Add(CategoryId);
            hash.Add(CategoryName);
            hash.Add(ProducedSince);
            return hash.ToHashCode();
        }

       
    }

    public static class CourseExtension
    {
        public static CourseResponse ToCourseResponse(this Course course)
        {
            return new CourseResponse
            {
                CourseId = course.Id,
                Title = course.Title,
                Description = course.Description,
                CreatedAt = course.CreatedAt,
                ImageUrl = course.ImageUrl,
                Rating = course.Rating,
                CategoryId = course.CategoryId,
                CategoryName = course.CategoryId != null ? course.Category?.Name : string.Empty,
                ProducedSince = (course.CreatedAt.HasValue) ? Math.Round((DateTime.Now - course.CreatedAt.Value).TotalDays / 365.25) : null,
            };
        }
    }

}
