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

        [Required(ErrorMessage = "Address line is required.")]
        [StringLength(100, ErrorMessage = "Address line cannot exceed 100 characters.")]
        public string? Address_Line { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [StringLength(45, ErrorMessage = "City cannot exceed 45 characters.")]
        public string? City { get; set; }

        [Required(ErrorMessage = "ZIP/Postcode is required.")]
        [StringLength(45, ErrorMessage = "ZIP/Postcode cannot exceed 45 characters.")]
        public string? Zip_Postcode { get; set; }

        [Required(ErrorMessage = "State is required.")]
        [StringLength(45, ErrorMessage = "State cannot exceed 45 characters.")]
        public string? State { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; }
        [JsonIgnore]

        public virtual Student? Student { get; set; }

    }
}
