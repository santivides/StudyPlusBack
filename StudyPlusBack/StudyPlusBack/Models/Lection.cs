using System;
using System.Collections.Generic;

namespace StudyPlusBack.Models;

public partial class Lection
{
    public int Id { get; set; }

    public int? CourseId { get; set; }

    public string Title { get; set; } = null!;

    public string? Content { get; set; }

    public int? Lorder { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<LectionProgress> LectionProgresses { get; set; } = new List<LectionProgress>();
}
