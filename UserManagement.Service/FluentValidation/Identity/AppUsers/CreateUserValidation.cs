
using FluentValidation;
using UserManagement.Domain.Identity;
using UserManagement.Service.Messages;
using UserManagement.Service.ViewModel.Identity.AppUsers;

namespace UserManagement.Service.FluentValidation.Identity.AppUsers
{
    //describe to all  validation realted to AppUser table
    public class CreateUserValidation : AbstractValidator<CreateUserViewModel>
    {
        public CreateUserValidation()
        {
            RuleFor(x => x.Email).NotNull().WithMessage(FluentMessage.Required("Email"));
            RuleFor(x => x.PhoneNumber).NotNull().WithMessage(FluentMessage.Required("PhoneNumber"));
            RuleFor(x => x.first_name).NotNull() .WithMessage(FluentMessage.Required("First Name"));
            RuleFor(x => x.last_name).NotNull().WithMessage(FluentMessage.Required("Last Name"));

            RuleFor(x => x.Password).NotNull().WithMessage(FluentMessage.Required("Password"));

        }
    }
}
