
using System.Threading.Tasks;
using UserManagement.Service.ViewModel.Account;
using UserManagement.Service.ViewModel;

namespace UserManagement.Service.Services.Abstract
{
    public interface IAccountService
    {
        Task<bool> LogOutAsync();
        Task<AuthResultViewModel> LoginAsync(LoginViewModel request); 
        Task<AuthResultViewModel> RegisterAsync(RegisterViewModel request);

    }
}
