

using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using UserManagement.Domain.Identity;

namespace UserManagement.Repository.UnitOfWorks.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        UserManager<AppUser> UserManager { get; }
        RoleManager<AppRole> RoleManager { get; }
        SignInManager<AppUser> SignInManager { get; }

        Task<int> Complete();
    }
}
