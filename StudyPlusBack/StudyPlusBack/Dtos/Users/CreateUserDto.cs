using System.ComponentModel.DataAnnotations;

namespace StudyPlusBack.Dtos.Users
{
    public class CreateUserDto
    {
        [Required]
        [MinLength(10, ErrorMessage = "Name must have at least 10 characters")]
        [MaxLength(50, ErrorMessage = "Name can have a maximum of 50 characters")]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(15, ErrorMessage = "Mail must have at least 15 characters")]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        public byte Role { get; set; }
    }

    public class newUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
