using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.DTOs
{
    public class ArticleDTO : IBaseEntityDTO
    {
        public string? Id { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }

        public DateTime CreateDate { get; set; }

        public string AppUserId { get; set; }
        public string CategoryId { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }

    }
}
