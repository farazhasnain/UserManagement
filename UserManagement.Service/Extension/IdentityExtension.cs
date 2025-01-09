

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using UserManagement.Domain.Identity;
using UserManagement.Repository.DbContext;

namespace UserManagement.Service.Extension
{
    public static  class IdentityExtension
    {
        public static IServiceCollection AddIdentity(this IServiceCollection service, IConfiguration config)
        {
            //inject Dbcontext
            service.AddDbContext<AppDbContext>(op => op.UseSqlServer(config.GetConnectionString("DefaultConnection")));



            //Inject Identity
            service.AddIdentity<AppUser, AppRole>(options =>
            {
                options.SignIn.RequireConfirmedEmail = true;


                //password requirement
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 0;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireDigit = false;

                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_@.";

                ////lockout requirement
                //options.Lockout.DefaultLockoutTimeSpan=TimeSpan.FromMinutes(10);
                //options.Lockout.MaxFailedAccessAttempts = 5;

            })
                .AddRoleManager<RoleManager<AppRole>>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            //inject idenity cookie
            service.ConfigureApplicationCookie(option =>
            {
                var cookieBuilder = new CookieBuilder();
                cookieBuilder.Name = "UserManagementCookie";

                option.Cookie = cookieBuilder;
              option.LoginPath = new PathString("/Account/Login");
              option.AccessDeniedPath = new PathString("/Account/AccessDenied");
                option.Cookie.HttpOnly = true;  // Ensures cookie is only sent over HTTP(S), not accessible via JavaScript
                option.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;  // Use secure cookies for HTTPS requests
                option.Cookie.SameSite = SameSiteMode.Strict;  // Prevents CSRF attacks
                option.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                option.SlidingExpiration = true;
            });

            //token lifetime
            service.Configure<DataProtectionTokenProviderOptions>(option =>
            {
                option.TokenLifespan = TimeSpan.FromMinutes(30);
            });


            return service;
        }
    }
}
