using System.ComponentModel.DataAnnotations;

namespace lab9kos.Models.ViewModels.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Wachtwoord")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Gegevens onthouden?")]
        public bool RememberMe { get; set; }
    }
}
