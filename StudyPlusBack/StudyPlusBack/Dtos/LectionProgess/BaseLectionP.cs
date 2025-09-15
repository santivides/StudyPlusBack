namespace StudyPlusBack.Dtos.LectionProgess
{
    public class BaseLectionP
    {
        public int InscriptionId { get; set; }

        public int LectionId { get; set; }

        public bool Completed { get; set; }
    }

    public class CreateLPDto : BaseLectionP
    {
    }
    public class UpdateLPDto : BaseLectionP
    {
    }
}
