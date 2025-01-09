

namespace UserManagement.Service.ViewModel.Account
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public bool RememberMe { get; set; } = false;

    }
}
