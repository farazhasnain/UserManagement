
using System.Threading.Tasks;
using UserManagement.Service.ViewModel.Identity.AppRole;
using UserManagement.Service.ViewModel;
using System.Collections.Generic;

namespace UserManagement.Service.Services.Abstract
{
    public interface IRoleService
    {
        Task<AuthResultViewModel> CreateRoleAsync(CreateRoleViewModel roleModel);
        Task<AuthResultViewModel> UpdateRoleAsync(UpdateRoleViewModel roleModel);
        Task<AuthResultViewModel> DeleteRoleAsync(int id);
        Task<List<RoleResponseViewModel>> GetRoleAsync();
        Task<RoleResponseViewModel> GetRoleByIdAsync(int id);

    }
}
