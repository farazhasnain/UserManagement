

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace UserManagement.Domain.Identity
{

    //implement all custom property related to usermanager 
    public class AppUser:IdentityUser<int>
    {
        public string  first_name { get; set; }
        public string last_name { get; set; }

        public bool is_active { get; set; } = true;
        public DateTime  Create_on { get; set; }=DateTime.Now;  


        public ICollection<AppUserRole> UserRoles { get; set; } = null!;
    }
}
