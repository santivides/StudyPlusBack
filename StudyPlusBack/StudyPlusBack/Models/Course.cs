using System;
using System.Collections.Generic;

namespace StudyPlusBack.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int? Courselevel { get; set; }

    public bool Active { get; set; }

    public string? ImgUrl { get; set; }

    public virtual ICollection<Inscription> Inscriptions { get; set; } = new List<Inscription>();

    public virtual ICollection<Lection> Lections { get; set; } = new List<Lection>();
}
