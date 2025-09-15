namespace StudyPlusBack.Dtos.Inscription
{
    public class InscriptionDto
    {
        public int? UserId { get; set; }

        public int? CourseId { get; set; }

        public DateOnly? InscriptionDate { get; set; }

        public int? Progress { get; set; }
    }
}
