using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlog.Application.DTOs;
using MyBlog.Application.Utilities.Helpers;
using MyBlog.Application.Utilities.IUnitOfWorks;
using MyBlog.Core.CoreEntities.Entities;
using MyBlog.Core.CoreEntities.Enums;
using MyBlog.Infrastructure.Utilities.UnitOfWorks;
using MyBlog.UI.Models.VMs;

namespace MyBlog.UI.Controllers
{
    public class AppUserController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public AppUserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IUnitOfWorkService unitOfWork, RoleManager<IdentityRole> roleManager) :base(unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UserProfile(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var articlesDTO = await _unitOfWork.ArticleService.GetFilteredListAsync(where: x=>x.AppUserId==user.Id);
            var articles = new List<ArticleVM>();

            foreach (var articleDTO in articlesDTO)
            {
                var category = await _unitOfWork.CategoryService.GetByIdAsync(articleDTO.CategoryId);
                var article = new ArticleVM
                {
                    Description = articleDTO.Description,
                    Title = articleDTO.Title,
                    Content = articleDTO.Content,
                    Id = articleDTO.Id,
                    ImageUrl = articleDTO.ImageUrl,
                    AppUserName = user.UserName,
                    CategoryName = category.Name
                };
                articles.Add(article);

            }

            var model = new AppUserVM()
            {
                UserName = user.UserName,
                Email = user.Email,
                Articles = articles,
                ImageUrl = ImageHelper.GetThumbnailUrl(user.ImageUrl),
                Id = user.Id,
                AboutMe = user.AboutMe
            };

            return View(model);
        }
        

        [HttpGet]
        public async Task<IActionResult> AppUserList()
        {
            var users = await _userManager.Users
        .Where(u => u.Status != EntityStatus.Deleted)
        .ToListAsync();

            var usersVM = new List<AppUserVM>();
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var role = roles.FirstOrDefault();
                usersVM.Add( new AppUserVM() {  Email = user.Email, Id=user.Id, UserName=user.UserName, AboutMe=user.AboutMe, ImageUrl=user.ImageUrl, Role=role });
            }
            return PartialView(usersVM);
        }

        

        [HttpPost]
        public async Task<IActionResult> UpdateUser(AppUserEditVM model, IFormFile image)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user != null) 
            {
                user.AboutMe = model.AboutMe;
                user.UserName = model.UserName;
                user.Email = model.Email;
                if (image != null && image.Length > 0)
                {
                    user.ImageUrl = await ImageHelper.SaveImageWithThumbnailAsync(image, "user");

                }
                await _userManager.UpdateAsync(user);
            }
            
            return RedirectToAction("UserProfile", "AppUser", new { id = user.Id });

        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            user.Status = EntityStatus.Deleted;

            var articles = await _unitOfWork.ArticleService.GetAllAsync(x => x.AppUserId == id);
            foreach (var article in articles)
            {
                await _unitOfWork.ArticleService.DeleteAsync(article.Id);
            }

            await _unitOfWork.CommitChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetRolesForAssign()
        {
            var roles = await _roleManager.Roles.Select(x => x.Name).ToListAsync();
            return Json(roles);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var roles = await _userManager.GetRolesAsync(user);
            if (roles.Any())
            {
                await _userManager.RemoveFromRolesAsync(user, roles);
            }
            if (user != null)
            {
                await _userManager.AddToRoleAsync(user, role);
            }

            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult>  GetUserCard(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId); 
            var model = new AppUserVM()
            {
                UserName = user.UserName,
                Email = user.Email,
                ImageUrl = ImageHelper.GetThumbnailUrl(user.ImageUrl),
                Id = user.Id,
                AboutMe = user.AboutMe
            };
            return PartialView("UserCard", model);
        }

    }
}
