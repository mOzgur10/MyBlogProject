using MyBlog.Core.CoreEntities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Core.CoreEntities.Entities
{
    public class Comment : BaseEntity, IBaseEntity
    {
        public string Content { get; set; }

        public virtual Article Article { get; set; }
        public string ArticleId { get; set; }

        public virtual AppUser AppUser { get; set; }
        public string AppUserId { get; set; }

        public int LikeCount { get; set; }
    }
}
