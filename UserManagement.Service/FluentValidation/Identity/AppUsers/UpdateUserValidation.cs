

using FluentValidation;
using UserManagement.Service.Messages;
using UserManagement.Service.ViewModel.Identity.AppUsers;

namespace UserManagement.Service.FluentValidation.Identity.AppUsers
{
    public class UpdateUserValidation : AbstractValidator<UpdateUserViewModel>
    {
        public UpdateUserValidation()
        {
           
            RuleFor(x => x.PhoneNumber).NotNull().WithMessage(FluentMessage.Required("PhoneNumber"));
            RuleFor(x => x.first_name).NotNull().WithMessage(FluentMessage.Required("First Name"));
            RuleFor(x => x.last_name).NotNull().WithMessage(FluentMessage.Required("Last Name"));

        }
    }
}
