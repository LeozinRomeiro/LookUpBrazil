using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LookUpBrazil.API.Models
{
    public class Location
    {
        [Key]
        [Column(TypeName = "varchar")]
        [StringLength(7)]
        public Guid Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(2)]
        public string State { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(80)]
        public string City { get; set; } = string.Empty;
    }
}
