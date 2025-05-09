using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Application.Utilities.IUnitOfWorks;
using MyBlog.Core.CoreEntities.Entities;

namespace MyBlog.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWork;
        private readonly UserManager<AppUser> _userManager;

        public AdminController(IUnitOfWorkService unitOfWork, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }


        public IActionResult Index(string loadPartial = null)
        {
            ViewBag.LoadPartial = loadPartial;
            return View();
        }


        
    }
}
