using StudyPlusBack.Models;
using System.ComponentModel.DataAnnotations;

namespace StudyPlusBack.Dtos.Lections
{
    public class BaseLectionDto
    {

        [Required]
        [MinLength(10, ErrorMessage = "the title must be at least 10 characters")]
        [MaxLength(200, ErrorMessage = "The title can have a maximum of 200 characters")]
        public string Title { get; set; } = null!;

        [Required]
        [Range(10, 10000)]
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
