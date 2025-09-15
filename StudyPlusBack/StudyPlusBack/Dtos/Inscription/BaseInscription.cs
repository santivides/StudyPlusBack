namespace StudyPlusBack.Dtos.Inscription
{
    public class BaseInscription
    {
        public int? UserId { get; set; }

        public int? CourseId { get; set; }

        public DateOnly? InscriptionDate { get; set; }

        public int? Progress { get; set; }
    }

    public class createInscriptionDto : BaseInscription
    {
    }

    public class updateInscriptionDto : BaseInscription
    {
    }
}
