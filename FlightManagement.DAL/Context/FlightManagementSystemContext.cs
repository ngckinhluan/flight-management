using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FlightManagement.DAL.Entities;

public partial class FlightManagementSystemContext : DbContext
{
    public FlightManagementSystemContext()
    {
    }

    public FlightManagementSystemContext(DbContextOptions<FlightManagementSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Airplane> Airplanes { get; set; }

    public virtual DbSet<Airport> Airports { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<CrewMember> CrewMembers { get; set; }

    public virtual DbSet<Flight> Flights { get; set; }

    public virtual DbSet<FlightCrew> FlightCrews { get; set; }

    public virtual DbSet<FlightSchedule> FlightSchedules { get; set; }

    public virtual DbSet<Passenger> Passengers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Seat> Seats { get; set; }

    public virtual DbSet<SeatReservation> SeatReservations { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local);uid=sa;pwd=12345;database=FlightManagementSystem;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Airplane>(entity =>
        {
            entity.HasKey(e => e.AirplaneId).HasName("PK__Airplane__5ED76B85B21E33C4");

            entity.Property(e => e.AirplaneId)
                .ValueGeneratedNever()
                .HasColumnName("AirplaneID");
            entity.Property(e => e.Manufacturer).HasMaxLength(100);
            entity.Property(e => e.Model).HasMaxLength(100);
        });

        modelBuilder.Entity<Airport>(entity =>
        {
            entity.HasKey(e => e.AirportId).HasName("PK__Airports__E3DBE08AA7708D6E");

            entity.HasIndex(e => e.Code, "UQ__Airports__A25C5AA75E2B7CB1").IsUnique();

            entity.Property(e => e.AirportId)
                .ValueGeneratedNever()
                .HasColumnName("AirportID");
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Bookings__73951ACD3CA81716");

            entity.Property(e => e.BookingId)
                .ValueGeneratedNever()
                .HasColumnName("BookingID");
            entity.Property(e => e.BookingDate).HasColumnType("datetime");
            entity.Property(e => e.FlightId).HasColumnName("FlightID");
            entity.Property(e => e.PassengerId).HasColumnName("PassengerID");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Flight).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.FlightId)
                .HasConstraintName("FK__Bookings__Flight__5812160E");

            entity.HasOne(d => d.Passenger).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.PassengerId)
                .HasConstraintName("FK__Bookings__Passen__59063A47");
        });

        modelBuilder.Entity<CrewMember>(entity =>
        {
            entity.HasKey(e => e.CrewMemberId).HasName("PK__CrewMemb__BE4E6E4C17903EF1");

            entity.Property(e => e.CrewMemberId)
                .ValueGeneratedNever()
                .HasColumnName("CrewMemberID");
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Position).HasMaxLength(50);
        });

        modelBuilder.Entity<Flight>(entity =>
        {
            entity.HasKey(e => e.FlightId).HasName("PK__Flights__8A9E148E7C2E030C");

            entity.Property(e => e.FlightId)
                .ValueGeneratedNever()
                .HasColumnName("FlightID");
            entity.Property(e => e.AirplaneId).HasColumnName("AirplaneID");
            entity.Property(e => e.ArrivalAirportId).HasColumnName("ArrivalAirportID");
            entity.Property(e => e.ArrivalTime).HasColumnType("datetime");
            entity.Property(e => e.DepartureAirportId).HasColumnName("DepartureAirportID");
            entity.Property(e => e.DepartureTime).HasColumnType("datetime");
            entity.Property(e => e.FlightNumber).HasMaxLength(10);

            entity.HasOne(d => d.Airplane).WithMany(p => p.Flights)
                .HasForeignKey(d => d.AirplaneId)
                .HasConstraintName("FK__Flights__Airplan__4E88ABD4");

            entity.HasOne(d => d.ArrivalAirport).WithMany(p => p.FlightArrivalAirports)
                .HasForeignKey(d => d.ArrivalAirportId)
                .HasConstraintName("FK__Flights__Arrival__5070F446");

            entity.HasOne(d => d.DepartureAirport).WithMany(p => p.FlightDepartureAirports)
                .HasForeignKey(d => d.DepartureAirportId)
                .HasConstraintName("FK__Flights__Departu__4F7CD00D");
        });

        modelBuilder.Entity<FlightCrew>(entity =>
        {
            entity.HasKey(e => e.FlightCrewId).HasName("PK__FlightCr__EBA8BEA85C3DB733");

            entity.ToTable("FlightCrew");

            entity.Property(e => e.FlightCrewId)
                .ValueGeneratedNever()
                .HasColumnName("FlightCrewID");
            entity.Property(e => e.CrewMemberId).HasColumnName("CrewMemberID");
            entity.Property(e => e.FlightId).HasColumnName("FlightID");
            entity.Property(e => e.Role).HasMaxLength(50);

            entity.HasOne(d => d.CrewMember).WithMany(p => p.FlightCrews)
                .HasForeignKey(d => d.CrewMemberId)
                .HasConstraintName("FK__FlightCre__CrewM__6A30C649");

            entity.HasOne(d => d.Flight).WithMany(p => p.FlightCrews)
                .HasForeignKey(d => d.FlightId)
                .HasConstraintName("FK__FlightCre__Fligh__693CA210");
        });

        modelBuilder.Entity<FlightSchedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__FlightSc__9C8A5B69A2E5FA87");

            entity.Property(e => e.ScheduleId)
                .ValueGeneratedNever()
                .HasColumnName("ScheduleID");
            entity.Property(e => e.DayOfWeek).HasMaxLength(10);
            entity.Property(e => e.FlightId).HasColumnName("FlightID");

            entity.HasOne(d => d.Flight).WithMany(p => p.FlightSchedules)
                .HasForeignKey(d => d.FlightId)
                .HasConstraintName("FK__FlightSch__Fligh__6D0D32F4");
        });

        modelBuilder.Entity<Passenger>(entity =>
        {
            entity.HasKey(e => e.PassengerId).HasName("PK__Passenge__88915F902A85E3C5");

            entity.Property(e => e.PassengerId)
                .ValueGeneratedNever()
                .HasColumnName("PassengerID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Nationality).HasMaxLength(50);
            entity.Property(e => e.PassportNumber).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3A0370CC64");

            entity.HasIndex(e => e.RoleName, "UQ__Roles__8A2B6160F016D9CB").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<Seat>(entity =>
        {
            entity.HasKey(e => e.SeatId).HasName("PK__Seats__311713D34A13D385");

            entity.Property(e => e.SeatId)
                .ValueGeneratedNever()
                .HasColumnName("SeatID");
            entity.Property(e => e.AirplaneId).HasColumnName("AirplaneID");
            entity.Property(e => e.Class).HasMaxLength(50);
            entity.Property(e => e.SeatNumber).HasMaxLength(10);

            entity.HasOne(d => d.Airplane).WithMany(p => p.Seats)
                .HasForeignKey(d => d.AirplaneId)
                .HasConstraintName("FK__Seats__AirplaneI__534D60F1");
        });

        modelBuilder.Entity<SeatReservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__SeatRese__B7EE5F04E2B62580");

            entity.Property(e => e.ReservationId)
                .ValueGeneratedNever()
                .HasColumnName("ReservationID");
            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.SeatId).HasColumnName("SeatID");

            entity.HasOne(d => d.Booking).WithMany(p => p.SeatReservations)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("FK__SeatReser__Booki__5BE2A6F2");

            entity.HasOne(d => d.Seat).WithMany(p => p.SeatReservations)
                .HasForeignKey(d => d.SeatId)
                .HasConstraintName("FK__SeatReser__SeatI__5CD6CB2B");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC626F545A");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E4B0841DA5").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(100);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UserRoles__RoleI__778AC167"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UserRoles__UserI__76969D2E"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PK__UserRole__AF27604F77309169");
                        j.ToTable("UserRoles");
                        j.IndexerProperty<int>("UserId").HasColumnName("UserID");
                        j.IndexerProperty<int>("RoleId").HasColumnName("RoleID");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
