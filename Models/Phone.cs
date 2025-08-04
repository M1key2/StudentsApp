using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StudentsApp.Models
{
    public class Phone
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "El número de teléfono es obligatorio.")]
        [StringLength(15, ErrorMessage = "El número de teléfono no puede exceder los 15 dígitos.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El número de teléfono solo debe contener dígitos.")]
        public string? Phone_Number { get; set; }

        [Required(ErrorMessage = "El código de área es obligatorio.")]
        [StringLength(5, ErrorMessage = "El código de área no puede exceder los 5 caracteres.")]
        public string? AreaCode { get; set; }

        public enum PhoneType
        {
            Home = 1,
            Mobile = 2,
            Work = 3
        }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        [JsonIgnore]
        public virtual Student? Student { get; set; }
    }
}
