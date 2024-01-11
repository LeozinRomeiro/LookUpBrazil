using System.ComponentModel.DataAnnotations;

namespace LookUpBrazil.API.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Infome o Email")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe a senha")]
        public string Password { get; set; }
    }
}
