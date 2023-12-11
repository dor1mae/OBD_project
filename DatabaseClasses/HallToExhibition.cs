using System;
using System.Collections.Generic;

namespace OBD;

public partial class HallToExhibition
{
    public int Id { get; set; }

    public int? IdExh { get; set; }

    public int? IdHall { get; set; }

    public virtual Exhibition? IdExhNavigation { get; set; }

    public virtual Hall? IdHallNavigation { get; set; }
}
