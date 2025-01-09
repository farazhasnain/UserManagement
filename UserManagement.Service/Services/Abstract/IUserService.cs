
using System.Threading.Tasks;
using UserManagement.Service.ViewModel.Identity.AppUsers;
using UserManagement.Service.ViewModel;
using System.Collections.Generic;

namespace UserManagement.Service.Services.Abstract
{
    public interface IUserService
    {
        Task<AuthResultViewModel> CreateAsync(CreateUserViewModel rquest); 
        Task<AuthResultViewModel> UpdateUserAsync(UpdateUserViewModel request);
        Task<AuthResultViewModel> DeleteUserAsync(int id);
        Task<List<UserResponseViewModel>> GetUserAsync();
        Task<UserResponseViewModel> GetUserByIdAsync(int id);
        Task<List<int>> GetUserRoleAsync(int user_id);
        Task<bool> AssignRoleAsync(int user_id, List<int> role_id);
    }

}
