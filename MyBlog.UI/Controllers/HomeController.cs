using Microsoft.AspNetCore.Mvc;
using MyBlog.Application.Utilities.IUnitOfWorks;

using MyBlog.UI.Models;
using MyBlog.UI.Models.VMs;
using System.Diagnostics;

namespace MyBlog.UI.Controllers
{
    
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        

        public HomeController(ILogger<HomeController> logger, IUnitOfWorkService unitOfWork) :base(unitOfWork)
        {
            _logger = logger;
        }

       [HttpGet]
        public async Task <IActionResult> Index()
        {
            var categories = await _unitOfWork.CategoryService.GetAllAsync();
            var categoriesVM = new List<CategoryVM>();
            foreach (var category in categories)
            {
                var categoryVM = new CategoryVM { Name = category.Name, Id = category.Id };
                categoriesVM.Add(categoryVM);
            }

            return View(categoriesVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
