using StudyPlusBack.Dtos.Lections;
using StudyPlusBack.Models;

namespace StudyPlusBack.Dtos.Courses
{
    public class CourseDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public int? Courselevel { get; set; }

        public bool Active { get; set; }

        public string? ImgUrl { get; set; }

        public virtual ICollection<LectionDto> Lections { get; set; } = new List<LectionDto>();
    }
}
