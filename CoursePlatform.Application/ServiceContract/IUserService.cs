using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePlatform.Core.ServiceContract
{
    public interface IUserService
    {
        Task<List<UserResponse>> GetAllUsers();
        Task<UserResponse> GetUserById(Guid id);
        Task<bool> DeleteUser(Guid id);
        Task<bool> ChangeUserRole(Guid id, string newRole);
    }
}
