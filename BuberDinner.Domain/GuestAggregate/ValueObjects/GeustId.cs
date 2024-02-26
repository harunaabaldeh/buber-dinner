using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.GuestAggregate.ValueObjects;
public class GeustId : ValueObject
{
    public Guid Value { get; }

    private GeustId(Guid value)
    {
        Value = value;
    }

    public static GeustId CreateUnique()
    {
        return new GeustId(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}