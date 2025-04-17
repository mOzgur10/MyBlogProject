using MyBlog.Core.CoreEntities.Entities;

namespace MyBlog.UI.Models.VMs
{
    public class AppUserVM
    {
        public AppUserVM()
        {
            Articles = new List<Article>();///?
        }
        public string Email { get; set; }

        public IList<Article> Articles { get; set; }
    }
}
