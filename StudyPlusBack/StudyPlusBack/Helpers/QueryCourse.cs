namespace StudyPlusBack.Helpers
{
    public class QueryCourse
    {
        public string? Id { get; set; } = null;
        public string? Name { get; set; } = null;
        public bool Active { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
