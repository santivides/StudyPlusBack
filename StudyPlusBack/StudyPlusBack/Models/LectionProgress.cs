using System;
using System.Collections.Generic;

namespace StudyPlusBack.Models;

public partial class LectionProgress
{
    public int InscriptionId { get; set; }

    public int LectionId { get; set; }

    public bool Completed { get; set; }

    public int Id { get; set; }

    public virtual Inscription Inscription { get; set; } = null!;

    public virtual Lection Lection { get; set; } = null!;
}
