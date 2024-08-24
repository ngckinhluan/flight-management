using System;
using System.Collections.Generic;

namespace FlightManagement.DAL.Entities;

public partial class Flight
{
    public int FlightId { get; set; }

    public string? FlightNumber { get; set; }

    public int? AirplaneId { get; set; }

    public int? DepartureAirportId { get; set; }

    public int? ArrivalAirportId { get; set; }

    public DateTime? DepartureTime { get; set; }

    public DateTime? ArrivalTime { get; set; }

    public virtual Airplane? Airplane { get; set; }

    public virtual Airport? ArrivalAirport { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Airport? DepartureAirport { get; set; }

    public virtual ICollection<FlightCrew> FlightCrews { get; set; } = new List<FlightCrew>();

    public virtual ICollection<FlightSchedule> FlightSchedules { get; set; } = new List<FlightSchedule>();
}
