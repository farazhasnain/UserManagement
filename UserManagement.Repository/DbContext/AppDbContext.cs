

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UserManagement.Domain.Identity;

namespace UserManagement.Repository.DbContext
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public AppDbContext()
        {
            
        }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=DESKTOP-5BTC8DT\\SQLEXPRESS;Database=UserManagement;Trusted_Connection=True;MultipleActiveResultSets=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);

            //define appuserrole relationship with user and role table;
            builder.Entity<AppUserRole>().HasOne(u => u.Users).WithMany(m => m.UserRoles).HasForeignKey(key => key.UserId).IsRequired();
            builder.Entity<AppUserRole>().HasOne(u => u.Roles).WithMany(m => m.UserRoles).HasForeignKey(key => key.RoleId).IsRequired();


            // Customize the column name for discriminator
            builder.Entity<AppUserRole>(entity =>
            {
                entity.Property<string>("Discriminator")
                      .HasDefaultValue("App UserRole");
            });
        }
    }
}
