using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Core.CoreEntities.Entities;
using MyBlog.Infrastructure.Configurations;
using MyBlog.Infrastructure.DataSeeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.Contexts
{
    public class AppDbContext: IdentityDbContext<AppUser>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            var adminRoleId = "cf0c57f4-f011-4d8a-bc5b-d5cb3d4188fc";
            var editorRoleId = "558b5f08-f36d-401f-9908-e472e74c3469";
            var writerRoleId = "b42ccf3b-987c-4d9e-a5f6-5be02e62cb29";

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = editorRoleId,
                    Name = "Editor",
                    NormalizedName = "EDITOR"
                },
                new IdentityRole
                {
                    Id = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "WRITER"
                }
            );

            
            var adminUserId = "c0f8b9e0-9d45-4b2a-bfa3-1a2bb8b5d001"; 
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = adminUserId,
                    RoleId = adminRoleId
                }
            );


            builder.ApplyConfiguration(new CategoryConfig());
            builder.ApplyConfiguration(new ArticleConfig());
            builder.ApplyConfiguration(new CommentConfig());
            builder.ApplyConfiguration(new AppUserConfig());
            base.OnModelCreating(builder);
        }
        
    }
}
