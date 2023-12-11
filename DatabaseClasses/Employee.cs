using System;
using System.Collections.Generic;

namespace OBD;

public partial class Employee
{
    public int Id { get; set; }

    public string SecondName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string FatherName { get; set; } = null!;

    public int? IdProf { get; set; }

    public int Salary { get; set; }

    public virtual ICollection<EmployeeToHall> EmployeeToHalls { get; } = new List<EmployeeToHall>();

    public virtual Profession? IdProfNavigation { get; set; }
}
