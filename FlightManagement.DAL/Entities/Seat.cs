using System;
using System.Collections.Generic;

namespace FlightManagement.DAL.Entities;

public partial class Seat
{
    public int SeatId { get; set; }

    public int? AirplaneId { get; set; }

    public string? SeatNumber { get; set; }

    public string? Class { get; set; }

    public bool? IsReserved { get; set; }

    public virtual Airplane? Airplane { get; set; }

    public virtual ICollection<SeatReservation> SeatReservations { get; set; } = new List<SeatReservation>();
}
