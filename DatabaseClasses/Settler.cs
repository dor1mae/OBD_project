using System;
using System.Collections.Generic;

namespace OBD;

public partial class Settler
{
    public int Id { get; set; }

    public string SecondName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string FatherName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public DateTime Birth { get; set; }

    public string Email { get; set; } = null!;

    public int? IdTicket { get; set; }

    public virtual Ticket? IdTicketNavigation { get; set; }
}
