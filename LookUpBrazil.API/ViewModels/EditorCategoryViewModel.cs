using System.ComponentModel.DataAnnotations;

namespace LookUpBrazil.API.ViewModels
{
    public class EditorCategoryViewModel
    {
        [Required(ErrorMessage ="O nome é obrigatorio")]
        public string Name { get; set; }
    }
}
