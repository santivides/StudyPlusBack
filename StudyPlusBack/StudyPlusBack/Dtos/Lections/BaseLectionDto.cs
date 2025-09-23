using StudyPlusBack.Models;

namespace StudyPlusBack.Dtos.Lections
{
    public class BaseLectionDto
    {

        public string Title { get; set; } = null!;

        public string? Content { get; set; }

        public int? Lorder { get; set; }

    }

    public class createLectionDto : BaseLectionDto
    {
    }

    public class updateLectionDto : BaseLectionDto
    {
    }
}
