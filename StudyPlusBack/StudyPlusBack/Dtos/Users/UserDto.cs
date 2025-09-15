using StudyPlusBack.Models;

namespace StudyPlusBack.Dtos.Users
{
    public class UserDto
    {

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public byte Role { get; set; }
    }
}
