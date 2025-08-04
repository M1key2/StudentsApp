using System.ComponentModel.DataAnnotations;

namespace StudentsApp.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        public string? Last_Name { get; set; }

        [StringLength(50, ErrorMessage = "Middle name cannot exceed 50 characters.")]
        public string? Middle_Name { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
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
