using MyBlog.Core.CoreEntities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Core.CoreEntities.BaseEntities
{
    public abstract class BaseEntity: IBaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        public EntityStatus Status { get; set; } = EntityStatus.Created;
    }
}
