using CoursePlatform.Core.Domain.IdentityEntites;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePlatform.Core.Service
{
    public class UserService:IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<UserResponse>> GetAllUsers()
        {
            var users = _userManager.Users.ToList();
            return users.Select(u => new UserResponse
            {
                Id = u.Id,
                Email = u.Email,
                UserName = u.UserName
            }).ToList();
        }

        public async Task<UserResponse> GetUserById(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null) return null;

            return new UserResponse
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName
            };
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null) return false;

            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> ChangeUserRole(Guid id, string newRole)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null) return false;

            var roles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, roles);
            var result = await _userManager.AddToRoleAsync(user, newRole);

            return result.Succeeded;
        }
    }
}
