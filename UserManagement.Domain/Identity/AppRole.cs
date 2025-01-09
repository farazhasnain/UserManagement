
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace UserManagement.Domain.Identity
{
    //implement all custom property related to rolemanager 
    public class AppRole:IdentityRole<int>
    {
        public bool is_active { get; set; } = true;
        public DateTime Create_on { get; set; } = DateTime.Now;

        public ICollection<AppUserRole> UserRoles { get; set; } = null!;
    }
}
