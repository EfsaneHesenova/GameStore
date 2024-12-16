using System.ComponentModel.DataAnnotations;

namespace GameStoreMVC.ViewModels.UserVMs
{
    public class LoginVM
    {
        [Required]
        [Display(Prompt = "EmailOrUsername")]
        public string EmailOrUsername { get; set; }

        [DataType(DataType.Password), Required]
        [Display(Prompt = "Password")]
        public string Password { get; set; }
        [Required]
        public bool isPersistant { get; set; }
    }
}
