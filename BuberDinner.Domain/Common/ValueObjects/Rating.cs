using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;

namespace BuberDinner.Domain.Common.ValueObjects;

public class Rating : ValueObject
{
    public double Value { get; private set; }
    public HostId HostId { get; private set; }
    public DinnerId DinnerId { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Rating(double value, HostId hostId, DinnerId dinnerId)
    {
        Value = value;
        HostId = hostId;
        DinnerId = dinnerId;
    }

    // public void Create()
    // {
    //     return new Rating( Value, HostId, DinnerId);
    // }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}