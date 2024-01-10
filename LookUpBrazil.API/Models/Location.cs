using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LookUpBrazil.API.Models
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(2)]
        public string State { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(80)]
        public string City { get; set; } = string.Empty;
    }
}
