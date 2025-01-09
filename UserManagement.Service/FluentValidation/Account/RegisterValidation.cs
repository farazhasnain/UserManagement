

using FluentValidation;
using UserManagement.Service.Messages;
using UserManagement.Service.ViewModel.Account;

namespace UserManagement.Service.FluentValidation.Account
{
    public class RegisterValidation : AbstractValidator<RegisterViewModel>
    {
        public RegisterValidation()
        {
            RuleFor(x => x.Email).NotNull().WithMessage(FluentMessage.Required("Email"));
            RuleFor(x => x.PhoneNumber).NotNull().WithMessage(FluentMessage.Required("PhoneNumber"));
            RuleFor(x => x.first_name).NotNull().WithMessage(FluentMessage.Required("First Name"));
            RuleFor(x => x.last_name).NotNull().WithMessage(FluentMessage.Required("Last Name"));

            RuleFor(x => x.Password).NotNull().WithMessage(FluentMessage.Required("Password"));
        }
    }
}
