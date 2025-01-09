
using Microsoft.AspNetCore.Identity;

namespace UserManagement.Domain.Identity
{

    //describe many to many relationship betwenn AppUser and AppRole table
    public class AppUserRole:IdentityUserRole<int>
    {
        public AppUser Users { get; set; } = null!;
        public AppRole Roles { get; set; } = null!;
    }
}
