using System.ComponentModel.DataAnnotations;

namespace MyBlog.UI.Models.VMs
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Required!")]
        [EmailAddress]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required!")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; } = false;
    }
}
