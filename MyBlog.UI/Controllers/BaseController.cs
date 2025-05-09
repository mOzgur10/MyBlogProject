using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyBlog.Application.Utilities.IUnitOfWorks;

namespace MyBlog.UI.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IUnitOfWorkService _unitOfWork;
        public BaseController(IUnitOfWorkService unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!string.IsNullOrEmpty(userId))
            {
                var user = _unitOfWork.AppUserService.GetByIdAsync(userId).Result;
                ViewBag.UserImage = user.ImageUrl;
            }

            base.OnActionExecuting(context);
        }
    }
}
