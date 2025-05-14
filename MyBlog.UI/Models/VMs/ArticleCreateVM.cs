using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyBlog.UI.Models.VMs
{
    public class ArticleCreateVM
    {
        public ArticleCreateVM()
        {
            Categories = new List<SelectListItem>();
        }
        public string? Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        [Required(ErrorMessage = "Please select a category")]
        public string CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }

        [Required(ErrorMessage = "Please upload a photo for article.")]
        public string ImageUrl { get; set; }
        public string Description { get; set; }


    }
}
