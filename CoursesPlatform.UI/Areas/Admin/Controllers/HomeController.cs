using CoursePlatform.Core.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoursesPlatform.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(UserTypeOptions.Admin))]
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
