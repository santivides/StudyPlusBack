using System;
using System.Collections.Generic;

namespace StudyPlusBack.Models;

public partial class Inscription
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? CourseId { get; set; }

    public DateOnly? InscriptionDate { get; set; }

    public int? Progress { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<LectionProgress> LectionProgresses { get; set; } = new List<LectionProgress>();

    public virtual User? User { get; set; }
}
