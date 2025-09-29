using System.ComponentModel.DataAnnotations;

namespace StudyPlusBack.Dtos.Users
{
    public class UpdateUserDto
    {
        [Required]
        [MinLength(10, ErrorMessage = "Name must have at least 10 characters")]
        [MaxLength(50, ErrorMessage = "Name can have a maximum of 50 characters")]
        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public byte Role { get; set; }
    }
}
