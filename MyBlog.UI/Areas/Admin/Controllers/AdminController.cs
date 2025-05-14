using System.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlog.Application.Utilities.IUnitOfWorks;
using MyBlog.Core.CoreEntities.Entities;
using MyBlog.UI.Areas.Admin.Models;
using MyBlog.UI.Controllers;
using MyBlog.UI.Models.VMs;

namespace MyBlog.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : BaseController
    {
        //private readonly IUnitOfWorkService _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(IUnitOfWorkService unitOfWork, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager): base(unitOfWork) 
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }


        public IActionResult Index(string loadPartial = null)
        {
            ViewBag.LoadPartial = loadPartial;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ArticleListBasic() 
        {
            var articlesDto = await _unitOfWork.ArticleService.GetAllAsync();

            var articles = new List<ArticleListVM>();

            foreach (var article in articlesDto) {

                var category = await _unitOfWork.CategoryService.GetByIdAsync(article.CategoryId);
                articles.Add(new ArticleListVM { Title = article.Title, Id = article.Id, CategoryName = category.Name });

            }

            return PartialView(articles);
        }

    }
}
