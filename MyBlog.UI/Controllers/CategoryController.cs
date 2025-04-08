using Microsoft.AspNetCore.Mvc;
using MyBlog.Application.Utilities.IUnitOfWorks;
using MyBlog.Core.CoreEntities.Entities;
using MyBlog.UI.Models.VMs;

namespace MyBlog.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWork;
        public CategoryController(IUnitOfWorkService unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IList<CategoryVM>> GetCategories()
        {

            var categories = await _unitOfWork.CategoryService.GetAllAsync();

            var categoryVMs = categories.Select(c => new CategoryVM
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();

            return categoryVMs;
        }
    }
}
