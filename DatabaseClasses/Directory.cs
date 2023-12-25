using System;
using System.Collections.Generic;

namespace OBD;

public partial class Directory
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Descrip { get; set; } = null!;

    public int? IdHall { get; set; }

    public int Height { get; set; }

    public int Width { get; set; }

    public int Length { get; set; }

    public int Weigth { get; set; }

    public Hall? IdHallNavigation { get; set; }

    public Organizator? Organizator { get; set; }
}
