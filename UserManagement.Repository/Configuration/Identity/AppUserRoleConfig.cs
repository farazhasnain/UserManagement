
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using UserManagement.Domain.Identity;

namespace UserManagement.Repository.Configuration.Identity
{
    public class AppUserRoleConfig : IEntityTypeConfiguration<AppUserRole>
    {

        //write   seeding data related AppRole and AppUser table
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasData(new AppUserRole
            {
                RoleId = 1,
                UserId = 1
            }, new AppUserRole
            {
                RoleId = 2,
                UserId = 2

            }, new AppUserRole
            {
                RoleId = 3,
                UserId = 3

            }

            );
        }
    }
}
