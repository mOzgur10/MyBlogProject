using System.ComponentModel.DataAnnotations;

namespace MyBlog.UI.Models.VMs
{
    public class RegisterVM
    {
        //[Required(ErrorMessage = "Required")]
        //[Display(Name = "Name")]
        //public string FirstName { get; set; }

        //[Required(ErrorMessage = "Required")]
        //[Display(Name = "Surname")]
        //public string LastName { get; set; }

        [Required(ErrorMessage = "Required")]
        [EmailAddress]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }

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
