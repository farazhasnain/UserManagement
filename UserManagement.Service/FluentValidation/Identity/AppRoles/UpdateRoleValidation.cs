

using FluentValidation;
using UserManagement.Service.Messages;
using UserManagement.Service.ViewModel.Identity.AppRole;

namespace UserManagement.Service.FluentValidation.Identity.AppRoles
{
    internal class UpdateRoleValidation : AbstractValidator<UpdateRoleViewModel>
    {
        public UpdateRoleValidation()
        {
            RuleFor(x => x.Name).NotNull().WithMessage(FluentMessage.Required("Name"));

        }
    }
}
