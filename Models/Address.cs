using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace StudentsApp.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria.")]
        [StringLength(100, ErrorMessage = "La dirección no puede exceder los 100 caracteres.")]
        public string? Address_Line { get; set; }

        [Required(ErrorMessage = "La ciudad es obligatoria.")]
        [StringLength(45, ErrorMessage = "La ciudad no puede exceder los 45 caracteres.")]
        public string? City { get; set; }

        [Required(ErrorMessage = "El código postal es obligatorio.")]
        [StringLength(45, ErrorMessage = "El código postal no puede exceder los 45 caracteres.")]
        public string? Zip_Postcode { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        [StringLength(45, ErrorMessage = "El estado no puede exceder los 45 caracteres.")]
        public string? State { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; }

        [JsonIgnore]
        public virtual Student? Student { get; set; }
    }
}
