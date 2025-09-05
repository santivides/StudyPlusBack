using System;
using System.Collections.Generic;

namespace StudyPlusBack.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public byte Role { get; set; }

    public virtual ICollection<Inscription> Inscriptions { get; set; } = new List<Inscription>();
}
