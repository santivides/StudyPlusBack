namespace StudyPlusBack.Helpers
{
    public class QueryLection
    {
        public String? Title { set; get; } = null;
        public String? Content { set; get; } = null;
        public string? SortBy { set; get; } = null;
        public bool IsDescending { set; get; }
    }
}
