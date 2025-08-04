using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using StudentsApp.Models;
using System.Text.Json.Serialization;

namespace StudentsApp.Models
{
    public class Phone
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [StringLength(15, ErrorMessage = "Phone number cannot exceed 15 digits.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Phone number must contain only digits.")]
        public string? Phone_Number { get; set; }

        [Required(ErrorMessage = "Area code is required.")]
        [StringLength(5, ErrorMessage = "Area code cannot exceed 5 characters.")]
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
