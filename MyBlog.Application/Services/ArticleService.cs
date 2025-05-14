using MyBlog.Application.DTOs;
using MyBlog.Application.Services.IServices;
using MyBlog.Application.Utilities.IUnitOfWorks;
using MyBlog.Core.CoreEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Services
{
    public class ArticleService : BaseService<ArticleDTO,Article>,IArticleService
    {
        public ArticleService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task IncreaseViewCountAsync(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var article = await _unitOfWork.GetRepository<Article>().GetByIdAsync(id);
                article.ViewCount++;
            }
        }
    }
}
