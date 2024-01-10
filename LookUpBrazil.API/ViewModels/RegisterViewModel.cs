using System.ComponentModel.DataAnnotations;

namespace LookUpBrazil.API.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="O nome é obrigatorio")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O Email é obrigatorio")]
        [EmailAddress(ErrorMessage ="O Email é inválido")]
        public string Email { get; set; }
    }
}
