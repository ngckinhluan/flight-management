using System;
using System.Collections.Generic;

namespace FlightManagement.DAL.Entities;

public partial class FlightCrew
{
    public int FlightCrewId { get; set; }

    public int? FlightId { get; set; }

    public int? CrewMemberId { get; set; }

    public string? Role { get; set; }

    public virtual CrewMember? CrewMember { get; set; }

    public virtual Flight? Flight { get; set; }
}
