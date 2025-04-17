using Microsoft.AspNetCore.Identity;
using MyBlog.Core.CoreEntities.Entities;
using MyBlog.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.DataSeeders
{
    public class AppUserSeeder : IDataSeeder
    {
        private readonly UserManager<AppUser> _userManager;

        public AppUserSeeder(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task SeedAsync(AppDbContext appDbContext)
        {
            if (!appDbContext.Users.Any())
            {
                var adminUser = new AppUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "admin",
                    Email = "admin@example.com"
                };

                var result = await _userManager.CreateAsync(adminUser, "Password123!");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }
}
