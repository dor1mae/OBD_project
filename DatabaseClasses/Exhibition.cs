using System;
using System.Collections.Generic;

namespace OBD;

public partial class Exhibition
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public DateTime TimeOfStart { get; set; }

    public DateTime TimeOfEnd { get; set; }

    public int NumberTickets { get; set; }

    public int? IdOrg { get; set; }

    public virtual ICollection<HallToExhibition> HallToExhibitions { get; } = new List<HallToExhibition>();

    public virtual Organizator? IdOrgNavigation { get; set; }

    public virtual Ticket? Ticket { get; set; }
}
