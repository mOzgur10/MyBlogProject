using MyBlog.Core.CoreEntities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Core.CoreEntities.Entities
{
    public class Article : BaseEntity, IBaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }

        public Category Category { get; set; }
        public string CategoryId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
