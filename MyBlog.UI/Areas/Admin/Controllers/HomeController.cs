using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlog.Application.Utilities.IUnitOfWorks;
using MyBlog.Core.CoreEntities.Entities;
using MyBlog.UI.Models.VMs;
using System.Text.Unicode;

namespace MyBlog.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
       
        private readonly IUnitOfWorkService _unitOfWork;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(IUnitOfWorkService unitOfWork, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        // Admin Index Sayfası
       
        public IActionResult Index()
        {
            return View(); // Orijinal Layout ile gelen sayfa
        }

        // Kategoriler
        //[HttpGet]
        //public async Task<IActionResult> LoadCategoryList()
        //{
        //    var categoriesDTO = await _unitOfWork.CategoryService.GetAllAsync();

        //    var categories = categoriesDTO
        //        .Select(c => new CategoryVM { Name = c.Name })
        //        .ToList();

        //    return PartialView("~/Areas/Admin/Views/Shared/_CategoryList.cshtml", categories);
        //}
      


        public IActionResult LoadUserList()
        {
            var users = _unitOfWork.AppUserService.GetAllAsync();
            return PartialView("_UserList", users); // Partial view olarak kullanıcı listesi render edilecek
        }

        // Makaleler
        public IActionResult LoadArticleList()
        {
            var articles = _unitOfWork.ArticleService.GetAllAsync();
            return PartialView("_ArticleList", articles); // Partial view olarak makale listesi render edilecek
        }
    }
}
