using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Application.DTOs;
using MyBlog.Application.Utilities.Helpers;
using MyBlog.Application.Utilities.IUnitOfWorks;
using MyBlog.Core.CoreEntities.Entities;
using MyBlog.UI.Models.VMs;

namespace MyBlog.UI.Controllers
{
    public class CommentController : BaseController
    {

       
        private readonly UserManager<AppUser> _userManager;

        public CommentController(IUnitOfWorkService unitOfWork, UserManager<AppUser> userManager):base(unitOfWork)
        {
            
            _userManager = userManager;
            
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CommentList(string articleId)
        {
            var commentsDTO = await _unitOfWork.CommentService.GetFilteredListAsync(x=>x.ArticleId==articleId);

            var commentList = new List<CommentVM>();
            foreach (var commentDTO in commentsDTO)
            {
                var commentUser = await _userManager.FindByIdAsync(commentDTO.AppUserId);

                var comment = new CommentVM
                {
                    Content = commentDTO.Content,
                    AppUserName = commentUser.UserName,
                    Id= commentDTO.Id,
                    AppUserId= commentUser.Id,
                    AppUserImageUrl = ImageHelper.GetThumbnailUrl(commentUser.ImageUrl),
                    Date = TimeHelper.ToTimeAgo(commentDTO.CreateDate)
                };
                commentList.Add(comment);
            }

            return PartialView(commentList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(string articleId, string content)
        {
            var commentDTO = new CommentDTO
            {
                Content = content,
                ArticleId = articleId,
                AppUserId = User.FindFirstValue(ClaimTypes.NameIdentifier),

            };
            await _unitOfWork.CommentService.CreateAsync(commentDTO);
            await _unitOfWork.CommitChangesAsync();


            return Ok();
        }

        [HttpPost]
        public async Task DeleteComment(string commentId)
        {
            await _unitOfWork.CommentService.DeleteAsync(commentId);
            await _unitOfWork.CommitChangesAsync();

        } 
    }
}
