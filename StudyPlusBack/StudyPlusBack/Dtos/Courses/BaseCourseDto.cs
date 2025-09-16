using StudyPlusBack.Models;

namespace StudyPlusBack.Dtos.Courses
{
    public class BaseCourseDto
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public int? Courselevel { get; set; }

        public bool Active { get; set; }

        public string? ImgUrl { get; set; }
    }

    public class CreateCourseDto : BaseCourseDto
    {
    }

    public class UpdateCourseDto : BaseCourseDto
    {
    }
}
