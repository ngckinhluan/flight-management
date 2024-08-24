using System;
using System.Collections.Generic;

namespace FlightManagement.DAL.Entities;

public partial class Passenger
{
    public int PassengerId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? PassportNumber { get; set; }

    public string? Nationality { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
