

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using UserManagement.Domain.Identity;

namespace UserManagement.Repository.Configuration.Identity
{
    //write  all seeding data related to User table when database create first time 
    public class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            var admin = new AppUser
            {

                Id =1,
                is_active= true,    
                first_name = "Admin",
                last_name = "Uddin",
                Email = "admin@gmail.com",
                UserName = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com".ToUpper(),
                NormalizedUserName = "admin@gmail.com".ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
                PhoneNumber = "283748927387",


            };

            var superadmin = new AppUser
            {



                Id = 2,
                is_active = true,
                first_name = "SuperAdmin",
                last_name = "Uddin",
                Email = "superadmin@gmail.com",
                UserName = "superadmin@gmail.com",
                NormalizedEmail = "superadmin@gmail.com".ToUpper(),
                NormalizedUserName = "superadmi@gmail.com".ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
                PhoneNumber = "283748927387"

            };

            var user = new AppUser
            {

                Id =3,
                is_active = true,
                first_name = "User",
                last_name = "Uddin",
                Email = "user@gmail.com",
                UserName = "user@gmail.com",
                NormalizedEmail = "user@gmail.com".ToUpper(),
                NormalizedUserName = "user@gmail.com".ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
                PhoneNumber = "283748927387"

            };

            user.PasswordHash = GenerateHash(user, "user@123");
            admin.PasswordHash = GenerateHash(admin, "admin@123");
            superadmin.PasswordHash = GenerateHash(superadmin, "superadmin@123");

            builder.HasData(user, admin, superadmin);


        }
        private string GenerateHash(AppUser appUser, string password)
        {
            var hash = new PasswordHasher<AppUser>();
            return hash.HashPassword(appUser, password);

        }
    }
}
