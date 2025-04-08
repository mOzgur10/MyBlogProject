using Microsoft.AspNetCore.Mvc;
using MyBlog.Application.Utilities.IUnitOfWorks;

namespace MyBlog.UI.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWork;
        public ArticleController(IUnitOfWorkService unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        //public async Task<IActionResult> AddArticle()
        //{
        //    _unitOfWork.ArticleService.Create
        //}
    }
}
