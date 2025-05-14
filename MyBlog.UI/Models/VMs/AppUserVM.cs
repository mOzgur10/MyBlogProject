

namespace MyBlog.UI.Models.VMs
{
    public class AppUserVM
    {
        public AppUserVM()
        {
            Articles = new List<ArticleVM>();///?
        }
        public string Id { get; set; }
        public string Email { get; set; }

        public string? ImageUrl { get; set; }

        public IList<ArticleVM> Articles { get; set; }

        public string UserName { get; set; }

        public string AboutMe { get; set; }
        public string Role { get; set; }
    }
}
