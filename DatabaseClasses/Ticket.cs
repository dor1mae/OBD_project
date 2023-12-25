using System;
using System.Collections.Generic;

namespace OBD;

public partial class Ticket
{
    public int Id { get; set; }

    public int Cost { get; set; }

    public DateTime Day { get; set; }

    public int? IdExhibition { get; set; }

    public int? IdSettler { get; set; }

    public virtual Exhibition? IdExhibitionNavigation { get; set; }

    public virtual Settler? Settler { get; set; }
}
