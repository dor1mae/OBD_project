using System;
using System.Collections.Generic;

namespace OBD;

public partial class Profession
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Worktime { get; set; } = null!;

    public virtual Employee? Employee { get; set; }
}
