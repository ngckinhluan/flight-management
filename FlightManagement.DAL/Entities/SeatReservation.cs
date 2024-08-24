using System;
using System.Collections.Generic;

namespace FlightManagement.DAL.Entities;

public partial class SeatReservation
{
    public int ReservationId { get; set; }

    public int? BookingId { get; set; }

    public int? SeatId { get; set; }

    public virtual Booking? Booking { get; set; }

    public virtual Seat? Seat { get; set; }
}
