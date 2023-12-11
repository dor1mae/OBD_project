using System;
using System.Collections.Generic;

namespace OBD;

public partial class Hall
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int NumberExhibits { get; set; }

    public int? IdExhibit { get; set; }

    public virtual Directory? Directory { get; set; }

    public virtual ICollection<EmployeeToHall> EmployeeToHalls { get; } = new List<EmployeeToHall>();

    public virtual ICollection<HallToExhibition> HallToExhibitions { get; } = new List<HallToExhibition>();

    public virtual Exhibit? IdExhibitNavigation { get; set; }
}
