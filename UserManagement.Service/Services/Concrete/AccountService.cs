
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Threading.Tasks;
using System;
using UserManagement.Domain.Identity;
using UserManagement.Service.Services.Abstract;
using UserManagement.Repository.UnitOfWorks.Abstract;
using UserManagement.Service.ViewModel.Account;
using UserManagement.Service.ViewModel;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace UserManagement.Service.Services.Concrete
{
    public class AccountService:IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork unitOfWork;

        public AccountService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<AuthResultViewModel> LoginAsync(LoginViewModel  request)
        {
            var user = await unitOfWork.UserManager.FindByEmailAsync(request.Email);
            if (user == null)
                return new AuthResultViewModel() { error = true, message = "email is already taken" };

            var result = await unitOfWork.UserManager.CheckPasswordAsync(user, request.Password);
            if (!result)
                return new AuthResultViewModel() { error = true, message = "password is not valid" };

            await unitOfWork.SignInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, false);
            await unitOfWork.SignInManager.SignInAsync(user,request.RememberMe);
            return new AuthResultViewModel() { error = false, message = "login successed" };



        }
        public async Task<AuthResultViewModel> RegisterAsync(RegisterViewModel request)
        {

            var user = _mapper.Map<AppUser>(request);
            var result = await unitOfWork.UserManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                return new AuthResultViewModel() { error = true, message = result.Errors.Select(x => x.Description).FirstOrDefault() };
        
            //add default role\
            var register_user= await unitOfWork.UserManager.FindByEmailAsync(request.Email);
            await unitOfWork.UserManager.AddToRoleAsync(register_user, "User");
            return new AuthResultViewModel() { error = false, message = "register successed" };


        }
        public async Task<bool> LogOutAsync()
        {
             await unitOfWork.SignInManager.SignOutAsync();
            return true;
        }
    }
}
