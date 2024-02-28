using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;

namespace BuberDinner.Domain.Dinner.Entities;
public class Reservation : Entity<ReservationId>
{
    public int GuestCount { get; }
    public string ReservationStatus { get; }
    public GeustId GuestId { get; }
    public BillId BillId { get; }
    public DateTime? ArrivalDateTime { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdateDateTime { get; }

    private Reservation(ReservationId reservationId,
                        int guestCount,
                        string reservationStatus,
                        GeustId geustId,
                        BillId billId,
                        DateTime? arrivalDateTime,
                        DateTime createdDateTime,
                        DateTime UpdatedDateTime) : base(reservationId)
    {
        GuestCount = guestCount;
        ReservationStatus = reservationStatus;
        GuestId = geustId;
        BillId = billId;
        ArrivalDateTime = arrivalDateTime;
        CreatedDateTime = createdDateTime;
        UpdateDateTime = UpdatedDateTime;
    }

    public static Reservation Create(
                                     int guestCount,
                                     string reservationStatus,
                                     GeustId geustId,
                                     BillId billId
                                     )
    {
        return new Reservation(ReservationId.CreateUnique(),
                               guestCount,
                               reservationStatus,
                               geustId,
                               billId,
                               DateTime.UtcNow,
                               DateTime.UtcNow,
                               DateTime.UtcNow);
    }
}