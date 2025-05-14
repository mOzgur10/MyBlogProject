using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.DTOs
{
    public class CommentDTO : IBaseEntityDTO
    {
        public string? Id { get; set; }
        public string Content { get; set; }
        public  DateTime CreateDate { get; set; }

        public string ArticleId { get; set; }
        public string AppUserId { get; set; }
    }
}
