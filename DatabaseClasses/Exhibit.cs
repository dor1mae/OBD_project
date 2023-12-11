using System;
using System.Collections.Generic;

namespace OBD;

public partial class Exhibit
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int? IdOrg { get; set; }

    public virtual Hall? Hall { get; set; }

    public virtual Organizator? IdOrgNavigation { get; set; }
}
