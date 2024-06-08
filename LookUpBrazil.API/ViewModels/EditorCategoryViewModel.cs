using System.ComponentModel.DataAnnotations;

namespace LookUpBrazil.Api.ViewModels
{
    public class EditorCategoryViewModel
    {
        [Required(ErrorMessage ="O nome é obrigatorio")]
        public string Name { get; set; }
    }
}
