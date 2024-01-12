using System.ComponentModel.DataAnnotations;

namespace LookUpBrazil.API.ViewModels.Accounts
{
    public class UploadImageViewModel
    {
        [Required(ErrorMessage = "Imagem invalida")]
        public string Base64Image { get; set; }
    }
}
