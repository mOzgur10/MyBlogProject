using Microsoft.AspNetCore.Identity;
using MyBlog.Core.CoreEntities.BaseEntities;
using MyBlog.Core.CoreEntities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Core.CoreEntities.Entities
{
    public class AppUser : IdentityUser , IBaseEntity
    {
        //public string FirstName { get; set; }
        //public string  LastName { get; set; }

        //[NotMapped]
        //public string FullName { get { return FirstName + " " + LastName; } }

        //public string Id { get; set; } 

        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        public EntityStatus Status { get; set; } = EntityStatus.Created;

        public virtual ICollection<Article> Articles { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
