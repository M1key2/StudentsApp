using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace StudentsApp.Models
{
    public class Email
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "Formato de correo electrónico no válido.")]
        [StringLength(100, ErrorMessage = "El correo electrónico no puede exceder los 100 caracteres.")]
        public string? Mail { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Email_Type EmailType { get; set; }
        public enum Email_Type
        {
            Personal = 1,
            Trabajo = 2,
            Escuela = 3,
            Otro = 4
        }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        [JsonIgnore]
        public virtual Student? Student { get; set; }
    }
}
