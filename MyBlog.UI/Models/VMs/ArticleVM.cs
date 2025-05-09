namespace MyBlog.UI.Models.VMs
{
    public class ArticleVM
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public bool ShowUserInfo { get; set; } = true;
        public string AppUserId { get; set; }
        public string CategoryName { get; set; }
        public string AppUserName { get; set; }
        public string AppUserImage { get; set; }
        public  string Id { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string ReadTime { get; set; }
    }
}
