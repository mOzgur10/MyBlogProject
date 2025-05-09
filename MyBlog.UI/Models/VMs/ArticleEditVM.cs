using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.UI.Models.VMs
{
    public class ArticleEditVM
    {
        public ArticleEditVM()
        {
            Categories = new List<SelectListItem>();
        }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        [Required(ErrorMessage = "Lütfen bir kategori seçiniz.")]
        public string CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }

        public string ImageUrl { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public string AppUserId { get; set; }
    }
}
