using MyBlog.Application.DTOs;
using MyBlog.Core.CoreEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Services.IServices
{
    public interface IArticleService: IBaseService<ArticleDTO,Article>
    {
        Task IncreaseViewCountAsync(string id);
    }
}
