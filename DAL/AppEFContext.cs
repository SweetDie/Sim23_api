using DAL.Entities;
using DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AppEFContext : IdentityDbContext<UserEntity, RoleEntity, int,
        IdentityUserClaim<int>, UserRoleEntity, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public AppEFContext(DbContextOptions<AppEFContext> options) : base(options)
        {   
        }

        public DbSet<CategoryEntity> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserRoleEntity>(ur =>
            {
                ur.HasKey(ur => new { ur.UserId, ur.RoleId });

                ur.HasOne(ur => ur.Role)
                   .WithMany(r => r.UserRoles)
                   .HasForeignKey(r => r.RoleId)
                   .IsRequired();

                ur.HasOne(ur => ur.User)
                    .WithMany(u => u.UserRoles)
                    .HasForeignKey(u => u.UserId)
                    .IsRequired();
            });
        }
    }
}
