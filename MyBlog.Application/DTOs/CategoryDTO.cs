using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.DTOs
{
    public class CategoryDTO : IBaseEntityDTO
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        
    }
}
