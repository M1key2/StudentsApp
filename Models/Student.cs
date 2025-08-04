using System.ComponentModel.DataAnnotations;

namespace StudentsApp.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(50, ErrorMessage = "El apellido no puede exceder los 50 caracteres.")]
        public string? Last_Name { get; set; }

        [StringLength(50, ErrorMessage = "El segundo nombre no puede exceder los 50 caracteres.")]
        public string? Middle_Name { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
        public string? First_Name { get; set; }

        public enum Gender
        {
            M,
            F
        }
        public Gender? StudentGender { get; set; }
        public virtual ICollection<Phone> Phones { get; set; } = new List<Phone>();
        public virtual ICollection<Email> Emails { get; set; } = new List<Email>();
        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
