using System;
using System.Collections.Generic;

namespace FlightManagement.DAL.Entities;

public partial class Airplane
{
    public int AirplaneId { get; set; }

    public string? Model { get; set; }

    public string? Manufacturer { get; set; }

    public int? Capacity { get; set; }

    public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();

    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();
}
