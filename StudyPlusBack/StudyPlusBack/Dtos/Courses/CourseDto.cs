using StudyPlusBack.Dtos.Lections;
using StudyPlusBack.Models;
using System.ComponentModel.DataAnnotations;

namespace StudyPlusBack.Dtos.Courses
{
    public class CourseDto
    {
        [Required]
        [MinLength(10, ErrorMessage = "the title must be at least 10 characters")]
        [MaxLength(200, ErrorMessage = "The title can have a maximum of 200 characters")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(500, ErrorMessage = "The description cannot be over 500 characters")]
        public string? Description { get; set; }

        public int? Courselevel { get; set; }

        public bool Active { get; set; }

        public string? ImgUrl { get; set; }

        public virtual ICollection<LectionDto> Lections { get; set; } = new List<LectionDto>();
    }
}
