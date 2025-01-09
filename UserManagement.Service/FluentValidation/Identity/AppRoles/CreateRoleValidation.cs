
using FluentValidation;
using UserManagement.Domain.Identity;
using UserManagement.Service.Messages;
using UserManagement.Service.ViewModel.Identity.AppRole;

namespace UserManagement.Service.FluentValidation.Identity.AppRoles
{

    //describe to all  validation realted to AppRole table
    public class CreateRoleValidation : AbstractValidator<CreateRoleViewModel>
    {
        public CreateRoleValidation()
        {
            RuleFor(x => x.Name).NotNull().WithMessage(FluentMessage.Required("Name"));
        }
    }
}
