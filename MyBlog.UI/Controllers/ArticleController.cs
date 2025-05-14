using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBlog.Application.DTOs;
using MyBlog.Application.Utilities.Helpers;
using MyBlog.Application.Utilities.IUnitOfWorks;
using MyBlog.Core.CoreEntities.Entities;
using MyBlog.Core.CoreEntities.Enums;
using MyBlog.UI.Models.VMs;

namespace MyBlog.UI.Controllers
{
    public class ArticleController : BaseController
    {
        
        private readonly UserManager<AppUser> _userManager;
        public ArticleController(IUnitOfWorkService unitOfWork, UserManager<AppUser> userManager):base(unitOfWork)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var sessionKey = $"Viewed_Article_{id}";

            
            if (HttpContext.Session.GetString(sessionKey) == null)
            {
                
                HttpContext.Session.SetString(sessionKey, "true");

                await _unitOfWork.ArticleService.IncreaseViewCountAsync(id);
                await _unitOfWork.CommitChangesAsync();
            }

            var articleDTO = await _unitOfWork.ArticleService.GetByIdAsync(id);
            var user = await _userManager.FindByIdAsync(articleDTO.AppUserId);
            var category = await _unitOfWork.CategoryService.GetByIdAsync(articleDTO.CategoryId);

            var article = new ArticleVM
            {
                Description = articleDTO.Description,
                Title = articleDTO.Title,
                Content = articleDTO.Content,
                Id = articleDTO.Id,
                ImageUrl = articleDTO.ImageUrl,
                AppUserId = articleDTO.AppUserId,
                AppUserName = user.UserName,
                CategoryName = category.Name,
                AppUserImage = ImageHelper.GetThumbnailUrl(user.ImageUrl),
                Date = TimeHelper.ToTimeAgo(articleDTO.CreateDate),
                ReadTime = TimeHelper.CalculateReadingTime(articleDTO.Content).ToString()
            };

            return View(article);
        }

        
        [HttpGet]
        public async Task<IActionResult> CreateArticle()
        {
            var categoryDtos = await _unitOfWork.CategoryService.GetAllAsync();

            var model = new ArticleCreateVM
            {
                Categories = categoryDtos.Select(c => new SelectListItem
                {
                    Value = c.Id,
                    Text = c.Name
                })
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle(ArticleCreateVM article, IFormFile image)
        {
            var user = await _userManager.GetUserAsync(User);

            

            var articleDTO = new ArticleDTO()
            {
                Id = Guid.NewGuid().ToString(),
                Content = article.Content,
                Title = article.Title,
                CategoryId = article.CategoryId,
                AppUserId = user.Id,
                Description = article.Description,
                ImageUrl = await ImageHelper.SaveImageWithThumbnailAsync(image, "article")
            };

            await _unitOfWork.ArticleService.CreateAsync(articleDTO);
            await _unitOfWork.CommitChangesAsync();

            return RedirectToAction("Details", "Article", new { id = articleDTO.Id });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteArticle(string id)
        {
            await _unitOfWork.ArticleService.DeleteAsync(id);
            await _unitOfWork.CommitChangesAsync();
            return Ok();
        }


        [HttpGet]
        public async Task<IActionResult> UpdateArticle(string id)
        {
            var categoryDtos = await _unitOfWork.CategoryService.GetAllAsync();
            var articleDto = await _unitOfWork.ArticleService.GetByIdAsync(id);
            var article = new ArticleEditVM
            {
                AppUserId = articleDto.AppUserId,
                Content = articleDto.Content,
                CreateDate = articleDto.CreateDate,
                Title = articleDto.Title,
                CategoryId = articleDto.CategoryId,
                Description = articleDto.Description,
                ImageUrl = articleDto.ImageUrl,
                Id = id,
                Categories = categoryDtos.Select(c => new SelectListItem
                {
                    Value = c.Id,
                    Text = c.Name
                })

            };
            return View(article);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateArticle(ArticleEditVM model, IFormFile image)
        {
            
            var dto = new ArticleDTO
            {
                Content = model.Content,
                Title = model.Title,
                CategoryId = model.CategoryId,
                Description = model.Description,
                CreateDate= model.CreateDate,
                AppUserId = model.AppUserId,
                ImageUrl = model.ImageUrl,
                Id = model.Id
            };

            if (image != null)
            {
                
                dto.ImageUrl = await ImageHelper.SaveImageWithThumbnailAsync(image, "article");  // Gerçek görsel URL'sini buraya ekleyin
            }
           

                _unitOfWork.ArticleService.Update(dto);
            await _unitOfWork.CommitChangesAsync();



            return RedirectToAction("Details","Article", new { id = model.Id });
        }

        [HttpGet]
        public async Task<IActionResult> ArticleList(string categoryId = null, string userId = null, string filter = null)
        {
           
            var articlesDto = await _unitOfWork.ArticleService.GetFilteredListAsync(
                where: query => (string.IsNullOrEmpty(categoryId) || query.CategoryId == categoryId) &&(string.IsNullOrEmpty(userId) || query.AppUserId == userId) && (string.IsNullOrEmpty(filter) || query.Title.ToLower().Contains(filter.ToLower())),
                orderBy: query => query.OrderByDescending(article => article.CreateDate)
            );

          
            var articlesVM = new List<ArticleVM>();

            foreach (var article in articlesDto)
            {
                var category = await _unitOfWork.CategoryService
                    .GetByIdAsync(article.CategoryId);
                var user = await _userManager.FindByIdAsync(article.AppUserId);
                var commentCount = await _unitOfWork.CommentService.CountAsync(x => (x.ArticleId==article.Id)&&(x.Status!=EntityStatus.Deleted));

                var articleVM = new ArticleVM
                {
                    CommentCount = commentCount.ToString(),
                    Title = article.Title,
                    Content = article.Content,
                    AppUserImage = ImageHelper.GetThumbnailUrl(user.ImageUrl),
                    AppUserName = user.UserName,
                    CategoryName = category.Name,
                    Id = article.Id,
                    AppUserId = article.AppUserId,
                    ImageUrl = ImageHelper.GetThumbnailUrl(article.ImageUrl),
                    Description = article.Description,
                    Date = TimeHelper.ToTimeAgo(article.CreateDate),
                    ReadTime = TimeHelper.CalculateReadingTime(article.Content).ToString()
                };

                if (userId != null)
                {
                    articleVM.ShowUserInfo = false;
                }
                articlesVM.Add(articleVM);

            }

            return PartialView(articlesVM);
        }

        [HttpGet]
        public async Task<IActionResult> MostViewedArticles()
        {
            var articlesVM = new List<ArticleVM>();
            var articlesDto = await _unitOfWork.ArticleService.GetFilteredListAsync(
                orderBy: query => query.OrderByDescending(article => article.ViewCount).ThenByDescending(article => article.CreateDate), take: 5
            );
            foreach (var article in articlesDto) 
            {
                var user = await _userManager.FindByIdAsync(article.AppUserId);
                var articleVM = new ArticleVM
                {
                    Title = article.Title,
                    AppUserName = user.UserName,
                    Id = article.Id,
                    
                    Date = TimeHelper.ToTimeAgo(article.CreateDate),
                    
                    AppUserImage = ImageHelper.GetThumbnailUrl(user.ImageUrl)
                };
                articlesVM.Add(articleVM);
            }
            return PartialView(articlesVM);
        }

      

    }
}
