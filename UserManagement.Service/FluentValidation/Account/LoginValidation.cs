using FluentValidation;
using UserManagement.Service.Messages;
using UserManagement.Service.ViewModel.Account;

namespace UserManagement.Service.FluentValidation.Account
{
    public class LoginValidation : AbstractValidator<RegisterViewModel>
    {
        public LoginValidation()
        {
            RuleFor(x => x.Email).NotNull().WithMessage(FluentMessage.Required("Email"));
          

            RuleFor(x => x.Password).NotNull().WithMessage(FluentMessage.Required("Password"));
        }
    }
}
