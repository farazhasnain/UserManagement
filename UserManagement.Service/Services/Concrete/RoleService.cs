
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Domain.Identity;
using UserManagement.Repository.UnitOfWorks.Abstract;
using UserManagement.Service.Services.Abstract;
using UserManagement.Service.ViewModel;
using UserManagement.Service.ViewModel.Identity.AppRole;

namespace UserManagement.Service.Services.Concrete
{
    public class RoleService:IRoleService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AuthResultViewModel> CreateRoleAsync(CreateRoleViewModel roleModel)
        {

           
            bool roleExists =  unitOfWork.RoleManager.Roles.Any(x=>x.Name== roleModel.Name && x.is_active==true);
            if (roleExists)
                return new AuthResultViewModel() { error = true, message = "role is already taken" };


            var appRole = _mapper.Map<AppRole>(roleModel);
            IdentityResult result = await unitOfWork.RoleManager.CreateAsync(appRole);
            if (!result.Succeeded)
                return new AuthResultViewModel() { error = true, message = result.Errors.Select(x => x.Description).FirstOrDefault() };


            return new AuthResultViewModel() { error = false, message = "role is inserted successfully" };

        }
        public async Task<AuthResultViewModel> UpdateRoleAsync(UpdateRoleViewModel roleModel)
        {
            AppRole role = await unitOfWork.RoleManager.FindByIdAsync(roleModel.Id.ToString());
            if (role == null)
                return new AuthResultViewModel() { error = true, message = "role is not found" };


            var result = await unitOfWork.RoleManager.UpdateAsync(_mapper.Map(roleModel, role));
            if (!result.Succeeded)
                return new AuthResultViewModel() { error = true, message = result.Errors.Select(x => x.Description).FirstOrDefault() };


            return new AuthResultViewModel() { error = false, message = "role update successfully" };
        }
        public async Task<AuthResultViewModel> DeleteRoleAsync(int id)
        {
            AppRole role = await unitOfWork.RoleManager.FindByIdAsync(id.ToString());
            if (role == null)
                return new AuthResultViewModel() { error = true, message = "role is not found" };

            role.is_active = false;
            var result = await unitOfWork.RoleManager.UpdateAsync(role);
            if (!result.Succeeded)
                return new AuthResultViewModel() { error = true, message = result.Errors.Select(x => x.Description).FirstOrDefault() };

            return new AuthResultViewModel() { error = false, message = "role deleted successfully" };

        }



        public async Task<List<RoleResponseViewModel>> GetRoleAsync() => _mapper.Map<List<RoleResponseViewModel>>(await unitOfWork.RoleManager.Roles.OrderByDescending(x=>x.Create_on).ToListAsync());
       
        public async Task<RoleResponseViewModel> GetRoleByIdAsync(int id)
        {
            AppRole role = await unitOfWork.RoleManager.FindByIdAsync(id.ToString()); 
            return _mapper.Map<RoleResponseViewModel>(role);

        }
      
    }
}
