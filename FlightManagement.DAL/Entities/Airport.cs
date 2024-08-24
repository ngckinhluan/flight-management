using System;
using System.Collections.Generic;

namespace FlightManagement.DAL.Entities;

public partial class Airport
{
    public int AirportId { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public virtual ICollection<Flight> FlightArrivalAirports { get; set; } = new List<Flight>();

    public virtual ICollection<Flight> FlightDepartureAirports { get; set; } = new List<Flight>();
}
