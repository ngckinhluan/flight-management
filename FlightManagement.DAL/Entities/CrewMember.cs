using System;
using System.Collections.Generic;

namespace FlightManagement.DAL.Entities;

public partial class CrewMember
{
    public int CrewMemberId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Position { get; set; }

    public DateOnly? HireDate { get; set; }

    public virtual ICollection<FlightCrew> FlightCrews { get; set; } = new List<FlightCrew>();
}
