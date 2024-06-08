using System.ComponentModel.DataAnnotations;

namespace LookUpBrazil.Api.ViewModels.Accounts
{
    public class UploadImageViewModel
    {
        [Required(ErrorMessage = "Imagem invalida")]
        public string Base64Image { get; set; }
    }
}
