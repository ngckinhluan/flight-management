using System;
using System.Collections.Generic;

namespace FlightManagement.DAL.Entities;

public partial class Booking
{
    public int BookingId { get; set; }

    public int? FlightId { get; set; }

    public int? PassengerId { get; set; }

    public DateTime? BookingDate { get; set; }

    public string? Status { get; set; }

    public virtual Flight? Flight { get; set; }

    public virtual Passenger? Passenger { get; set; }

    public virtual ICollection<SeatReservation> SeatReservations { get; set; } = new List<SeatReservation>();
}
