using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Core.CoreEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.Configurations
{
    public class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasMany(a => a.Articles).WithOne(u => u.AppUser).HasForeignKey(u => u.AppUserId).OnDelete(DeleteBehavior.NoAction);

            var adminUserId = "c0f8b9e0-9d45-4b2a-bfa3-1a2bb8b5d001"; 
            var hasher = new PasswordHasher<AppUser>();

            var adminUser = new AppUser
            {
                Id = adminUserId,
                UserName = "admin@example.com",
                NormalizedUserName = "ADMIN@EXAMPLE.COM",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                ImageUrl = "/images/user/default-profile-photo.jpg",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            adminUser.PasswordHash = hasher.HashPassword(adminUser, "123");

            builder.HasData(adminUser);

        }
    }
}
