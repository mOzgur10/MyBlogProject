using System.ComponentModel.DataAnnotations;

namespace MyBlog.UI.Models.VMs
{
    public class ResetPasswordVM
    {
        public string Email { get; set; }
        public string Token { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match!")]
        public string ConfirmPassword { get; set; }
    }
}
