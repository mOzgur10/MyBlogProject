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
    public class CommentService : BaseService<CommentDTO,Comment>, ICommentService
    {
        public CommentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
