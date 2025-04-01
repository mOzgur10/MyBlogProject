using MyBlog.Application.IRepositories.BaseRepos;
using MyBlog.Core.CoreEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.IRepositories
{
    public interface ICommentRepo: IBaseRepo<Comment>
    {

    }
}
