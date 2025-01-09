

using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using UserManagement.Domain.Identity;
using UserManagement.Service.Services.Abstract;
using UserManagement.Repository.UnitOfWorks.Abstract;
using UserManagement.Service.ViewModel.Identity.AppUsers;
using UserManagement.Service.ViewModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace UserManagement.Service.Services.Concrete
{
    public class UserService:IUserService
    {


        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AuthResultViewModel> CreateAsync(CreateUserViewModel rquest)
        {
            var isUserExist = await unitOfWork.UserManager.FindByEmailAsync(rquest.Email);
            if (isUserExist != null)
                return new AuthResultViewModel() { error = true,message="email is already taken" };

            var appUser = _mapper.Map<AppUser>(rquest);
            var result = await unitOfWork.UserManager.CreateAsync(appUser, rquest.Password);
            if (!result.Succeeded)
            {
                var register_user =await  unitOfWork.UserManager.FindByEmailAsync(rquest.Email);
                await unitOfWork.UserManager.AddToRoleAsync(register_user, "User");
                return new AuthResultViewModel() { error = true, message = result.Errors.Select(x => x.Description).FirstOrDefault() };

            }

            return new AuthResultViewModel() { error = false, message = "user create successfully" };

        }
        public async Task<AuthResultViewModel> UpdateUserAsync(UpdateUserViewModel request)
        {
            AppUser user = await unitOfWork.UserManager.FindByIdAsync(request.Id.ToString());
            if (user == null)
                return new AuthResultViewModel() { error = true, message = "user is not found" };

            var result = await unitOfWork.UserManager.UpdateAsync(_mapper.Map(request, user));
            if (!result.Succeeded)
                return new AuthResultViewModel() { error = true, message = result.Errors.Select(x => x.Description).FirstOrDefault() };

               return new AuthResultViewModel() { error = false, message = "user update successfully" }; 
        }
        public async Task<AuthResultViewModel> DeleteUserAsync(int id)
        {
            AppUser user = await unitOfWork.UserManager.Users.FirstOrDefaultAsync(x=>x.Id==id);
            if (user == null)
                return new AuthResultViewModel() { error = true, message = "user is not found" };

            user.is_active = false;
            var result = await unitOfWork.UserManager.UpdateAsync(user);
            if (!result.Succeeded)
                 return new AuthResultViewModel() { error = true, message = result.Errors.Select(x => x.Description).FirstOrDefault() };

            return new AuthResultViewModel() { error = false, message = "user delete successfully" };

        }


        public async Task<List<UserResponseViewModel>> GetUserAsync() => _mapper.Map<List<UserResponseViewModel>>(await unitOfWork.UserManager.Users.OrderByDescending(x=>x.Create_on).ToListAsync());
     
        
        public async Task<UserResponseViewModel> GetUserByIdAsync(int id)
        {
            AppUser user = await unitOfWork.UserManager.Users.FirstOrDefaultAsync(x=>x.Id==id) ;
            return _mapper.Map<UserResponseViewModel>(user);

        }
        public async Task<List<int>> GetUserRoleAsync(int user_id)
        {
            AppUser user = await unitOfWork.UserManager.Users.FirstOrDefaultAsync(x => x.Id == user_id);
            IList<string> user_role = await  unitOfWork.UserManager.GetRolesAsync(user);
            return  unitOfWork.RoleManager.Roles.Where(x=>user_role.Contains(x.Name)).Select(x=>x.Id).ToList();

        }


        public async Task<bool> AssignRoleAsync(int user_id,List<int> role_id)
        {
            AppUser user = await unitOfWork.UserManager.Users.FirstOrDefaultAsync(x => x.Id == user_id);
            var current_userrole = await unitOfWork.UserManager.GetRolesAsync(user);
            foreach(var item in current_userrole)
            {
                await unitOfWork.UserManager.RemoveFromRoleAsync(user, item);
            }

            
            var roles = await unitOfWork.RoleManager.Roles.Where(r => role_id.Contains(r.Id)).ToListAsync();
            foreach (var role in roles)
            {
                if (!await unitOfWork.UserManager.IsInRoleAsync(user, role.Name))
                   await unitOfWork.UserManager.AddToRoleAsync(user, role.Name);
                
            }
            return true;
        }

    }
}
