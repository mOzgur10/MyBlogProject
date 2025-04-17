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

        //[HttpPost]
        //public async Task<IActionResult> Create()
        //{
        //    _unitOfWork.ArticleService.Create
        //}

        public IActionResult ArticleList()
        {
            var articleList = _unitOfWork.ArticleService.GetAllAsync();
            return PartialView("_ArticleList", articleList);
        }
    }
}
