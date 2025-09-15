namespace StudyPlusBack.Dtos.LectionProgess
{
    public class LectionPDto
    {
        public int Id { get; set; }

        public int InscriptionId { get; set; }

        public int LectionId { get; set; }

        public bool Completed { get; set; }
    }
}
