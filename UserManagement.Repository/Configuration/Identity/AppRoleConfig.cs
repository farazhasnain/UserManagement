
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using UserManagement.Domain.Identity;

namespace UserManagement.Repository.Configuration.Identity
{

    //write  all seeding data related to Role table when database create first time 
    public class AppRoleConfig : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasData(new AppRole
            {
                Id = 1,
                is_active = true,
                Name = "Admin",
                NormalizedName = "Admin".ToUpper()

            }
           , new AppRole
           {
               Id = 2,
               is_active = true,
               Name = "SuperAdmin",
               NormalizedName = "SuperAdmin".ToUpper()
           }, new AppRole
           {
               Id = 3,
               is_active = true,
               Name = "User",
               NormalizedName = "User".ToUpper()
           }
           );
        }
    }
}
