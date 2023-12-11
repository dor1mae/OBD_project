using System;
using System.Collections.Generic;

namespace OBD;

public partial class EmployeeToHall
{
    public int Id { get; set; }

    public int? IdEmp { get; set; }

    public int? IdHall { get; set; }

    public virtual Employee? IdEmpNavigation { get; set; }

    public virtual Hall? IdHallNavigation { get; set; }
}
