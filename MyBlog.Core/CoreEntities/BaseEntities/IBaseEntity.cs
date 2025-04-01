using MyBlog.Core.CoreEntities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Core.CoreEntities.BaseEntities
{
    public interface IBaseEntity
    {

        string Id { get; set; }
        DateTime CreateDate { get; set; }
        DateTime? UpdateDate { get; set; }
        DateTime? DeleteDate { get; set; }
        EntityStatus Status { get; set; }

    }
}
