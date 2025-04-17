using Microsoft.AspNetCore.Mvc;
using MyBlog.Application.Utilities.IUnitOfWorks;

namespace MyBlog.UI.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWork;
        public AdminPanelController(IUnitOfWorkService unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
