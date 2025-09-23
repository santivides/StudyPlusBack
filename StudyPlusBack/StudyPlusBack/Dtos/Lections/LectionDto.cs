using StudyPlusBack.Dtos.LectionProgess;
using StudyPlusBack.Models;

namespace StudyPlusBack.Dtos.Lections
{
    public class LectionDto
    {
        public int? CourseId { get; set; }

        public string Title { get; set; } = null!;

        public string? Content { get; set; }

        public int? Lorder { get; set; }

        public List<LectionPDto> lectionProgresses { get; set; } = new List<LectionPDto>();
    }
}
