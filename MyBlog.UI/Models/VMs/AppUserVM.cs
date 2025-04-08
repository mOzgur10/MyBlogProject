using MyBlog.Core.CoreEntities.Entities;

namespace MyBlog.UI.Models.VMs
{
    public class AppUserVM
    {
        public string Email { get; set; }

        public IList<Article> Articles { get; set; }
    }
}
