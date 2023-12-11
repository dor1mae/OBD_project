using System;
using System.Collections.Generic;

namespace OBD;

public partial class Organizator
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public int? IdDirectory { get; set; }

    public string Email { get; set; } = null!;

    public virtual Exhibit? Exhibit { get; set; }

    public virtual Exhibition? Exhibition { get; set; }

    public virtual Directory? IdDirectoryNavigation { get; set; }
}
