

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UserManagement.Domain.Identity;
using UserManagement.Repository.DbContext;
using UserManagement.Repository.UnitOfWorks.Abstract;

namespace UserManagement.Repository.UnitOfWorks.Concrete
{

    // The UnitOfWork class is used to manage the database context and work with multiple repositories.
    // It provides a way to coordinate changes to different entities and commit them in a single transaction.
    public class UnitOfWork: IUnitOfWork
    {


        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _context = context;
            UserManager = userManager;
            RoleManager = roleManager;
            SignInManager = signInManager;
        }



        // Identity Managers
        public UserManager<AppUser> UserManager { get; }
        public RoleManager<AppRole> RoleManager { get; }
        public SignInManager<AppUser> SignInManager { get; }


        // Constructor injection
        // Commit changes to the database
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
