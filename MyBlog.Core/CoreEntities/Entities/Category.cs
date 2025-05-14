using MyBlog.Core.CoreEntities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Core.CoreEntities.Entities
{
    public class Category : BaseEntity, IBaseEntity
    {
        public Category()
        {
            Articles = new List<Article>();
        }
        public string Name { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
