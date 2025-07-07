using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePlatform.Core.DTO
{
    public class DashboardViewModel
    {
        public int TotalCourses { get; set; }
        public int TotalUsers { get; set; }
        public int TotalFavorites { get; set; }

        public List<CourseResponse> LatestCourses { get; set; } = new();
        public List<UserResponse> LatestUsers { get; set; } = new();
    }
}
