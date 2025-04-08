using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Core.CoreEntities.Entities;
using MyBlog.UI.Models.VMs;

namespace MyBlog.UI.Controllers
{
    public class AppUserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AppUserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public async Task<IActionResult> UserProfile()
        //{
        //    var user = await _userManager.GetUserAsync(User); 
            

        //    var model = new AppUserVM()
        //    {
        //        Email = user.Email,
        //        Articles = user.Articles.ToList()
        //    };

        //    return View(model);
        //}
        //[HttpGet]
        //public async Task<IActionResult> ViewProfile(string id)
        //{
        //    var user = await _userManager.FindByIdAsync(id);

        //    var model = new AppUserVM()
        //    {
        //        Email = user.Email,
        //        Articles = user.Articles.ToList()
        //    };

        //    return View("UserProfile", model);
        //}
    }
}
