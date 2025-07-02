using CoursePlatform.Core.Domain.IdentityEntites;
using CoursePlatform.Core.DTO;
using CoursePlatform.Core.Enum;
using CoursesPlatform.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesPlatform.UI.Controllers
{

    [AllowAnonymous]
    [Route("[Controller]/[action]")]
    
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
  
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Authorize("NotAuthenticated")]

        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return View(registerDto);
            }

            var user = new ApplicationUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                PhoneNumber = registerDto.Phone
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {

               
                string selectedRole = registerDto.UserType.ToString(); 

                
                if (await _roleManager.FindByNameAsync(selectedRole) is null)
                {
                    ApplicationRole applicationRole = new ApplicationRole() { Name = selectedRole };
                    await _roleManager.CreateAsync(applicationRole);
                }

                
                await _userManager.AddToRoleAsync(user, selectedRole);

     
                await _signInManager.SignInAsync(user, isPersistent: false);

                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(registerDto);
        }

        [HttpGet]
        [Authorize("NotAuthenticated")]
        public IActionResult Login()
        {
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("NotAuthenticated")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
               
                return View(loginDto);
            }

            var result = await _signInManager.PasswordSignInAsync(
                loginDto.UserName,
                loginDto.Password,
                loginDto.RememberMe,
                lockoutOnFailure: false);

            if (result.Succeeded)
            {
                ApplicationUser user = await _userManager.FindByNameAsync(loginDto.UserName);
                if ((user!=null))
                {
                    if(await _userManager.IsInRoleAsync(user,UserTypeOptions.Admin.ToString() ))
                        {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                }

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid email or password.");
          
            return View(loginDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
      
        
        public async Task<IActionResult> IsEmailAvailable(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
             if(user==null)
               return Json(true);
            return Json(false);
        }
    }
}