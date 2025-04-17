using Humanizer;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Application.DTOs;
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


        [HttpGet]
        public async Task <IActionResult> CategoryList()
        {
            var categoriesDTO = await _unitOfWork.CategoryService.GetAllAsync();

            //var categories = new List<CategoryVM>();

            //foreach (var category in categoriesDTO)
            //{
            //    var categoryVM = new CategoryVM
            //    {
            //        Id = category.Id,
            //        Name = category.Name
            //    };

            //    categories.Add(categoryVM);
            //}

            //return View(categories);
            return Json(categoriesDTO);
        }

        [HttpPost]
        public IActionResult UpdateInline(string Id, string name)
        {
            var dto = new CategoryDTO { Id = Id, Name = name };
            int result = _unitOfWork.CategoryService.Update(dto);

            if (result > 0)
                return Ok();
            else
                return BadRequest("Güncelleme başarısız.");
        }
        

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreateCategory(string name)
            {
                
                    var category = new CategoryDTO()
                    {
                        Name = name,
                        Id =Guid.NewGuid().ToString()
                    };

                    
            var result = _unitOfWork.CategoryService.Create(category);

            if (result > 0)
                return Ok();
            else
                return BadRequest("Güncelleme başarısız.");
            }

        
    }
}
