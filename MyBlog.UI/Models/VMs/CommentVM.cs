namespace MyBlog.UI.Models.VMs
{
    public class CommentVM
    {
        public string Content { get; set; }
        public string AppUserName { get; set; }
        public string Id { get; set; }
        public string AppUserId { get; set; }

        public string? AppUserImageUrl { get; set; }
        public string Date { get; set; }
    }
}
