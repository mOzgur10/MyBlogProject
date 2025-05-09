using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.DTOs
{
    public class AppUserDTO : IBaseEntityDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
    }
}
