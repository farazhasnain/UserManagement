using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Threading.Tasks;
using UserManagement.Service.Services.Abstract;
using UserManagement.Service.ViewModel.Account;

namespace UserManagemet.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;
        private readonly IToastNotification toastNotification;
        public AccountController(IAccountService accountService, IToastNotification toastNotification)
        {
            this.accountService = accountService;
            this.toastNotification = toastNotification;
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult Logout()
        {
            var  response= accountService.LogOutAsync();
            toastNotification.AddSuccessToastMessage("Logout Successed");
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
           var result= await accountService.LoginAsync(model);
            if (!result.error)
            {
                toastNotification.AddSuccessToastMessage(result.message);
                return RedirectToAction("Index", "Home");

            }

            return View(result);
        }



        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var result = await accountService.RegisterAsync(model);
            if (!result.error)
            {
                toastNotification.AddSuccessToastMessage(result.message);
                return RedirectToAction("Login", "Account");

            }
            return View(result);
        }

    }
}
