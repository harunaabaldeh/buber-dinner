using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;

namespace BuberDinner.Domain.BillAggregate;
public sealed class Bill : AggregateRoot<BillId>
{
    public DinnerId DinnerId { get; }
    public GeustId GeustId { get; }
    public HostId HostId { get; }
    public Price Price { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Bill(BillId billId,
                 DinnerId dinnerId,
                 GeustId geustId,
                 HostId hostId,
                 Price price,
                 DateTime createdDateTime,
                 DateTime updatedDateTime
                ) : base(billId)
    {
        DinnerId = dinnerId;
        GeustId = geustId;
        HostId = hostId;
        Price = price;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Bill Create(DinnerId dinnerId, GeustId geustId, HostId hostId, Price price)
    {
        return new Bill(BillId.CreateUnique(), dinnerId, geustId, hostId, price, DateTime.UtcNow, DateTime.UtcNow);
    }

}