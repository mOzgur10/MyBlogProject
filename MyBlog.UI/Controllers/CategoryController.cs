using Humanizer;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Application.DTOs;
using MyBlog.Application.Utilities.IUnitOfWorks;
using MyBlog.Core.CoreEntities.Entities;
using MyBlog.UI.Models.VMs;

namespace MyBlog.UI.Controllers
{
    public class CategoryController : BaseController
    {
        
        public CategoryController(IUnitOfWorkService unitOfWork):base(unitOfWork)
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task <IActionResult> CategoryList()
        {
            var categoriesDTO = await _unitOfWork.CategoryService.GetAllAsync();


            var categories = new List<CategoryVM>();

            foreach (var category in categoriesDTO)
            {
                var categoryVM = new CategoryVM
                {
                    Id= category.Id,
                    Name = category.Name
                };

                categories.Add(categoryVM);
            }

            return PartialView(categories);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(string Id, string name)
        {
            var dto = new CategoryDTO { Id = Id, Name = name };
            _unitOfWork.CategoryService.Update(dto);
            await _unitOfWork.CommitChangesAsync();

            return RedirectToAction("Index", "Admin", new { area = "Admin", loadPartial = "/Category/CategoryList" });
        }
        

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategory(string name)
            {
                
                    var category = new CategoryDTO()
                    {
                        Name = name,
                        Id =Guid.NewGuid().ToString()//??????
                    };

                    
            await _unitOfWork.CategoryService.CreateAsync(category);
            await _unitOfWork.CommitChangesAsync();

            return RedirectToAction("Index", "Admin", new { area = "Admin", loadPartial = "/Category/CategoryList" });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(string Id)
        {
            await _unitOfWork.CategoryService.DeleteAsync(Id);
            await _unitOfWork.CommitChangesAsync();
            return RedirectToAction("Index", "Admin", new { area = "Admin", loadPartial = "/Category/CategoryList" });
        }




    }
}
