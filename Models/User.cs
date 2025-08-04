using System.ComponentModel.DataAnnotations;

namespace StudentsApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty; 

        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = "User";

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
