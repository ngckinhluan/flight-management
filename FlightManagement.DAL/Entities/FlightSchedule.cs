using System;
using System.Collections.Generic;

namespace FlightManagement.DAL.Entities;

public partial class FlightSchedule
{
    public int ScheduleId { get; set; }

    public int? FlightId { get; set; }

    public string? DayOfWeek { get; set; }

    public TimeOnly? DepartureTime { get; set; }

    public TimeOnly? ArrivalTime { get; set; }

    public virtual Flight? Flight { get; set; }
}
