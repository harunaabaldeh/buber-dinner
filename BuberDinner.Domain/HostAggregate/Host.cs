using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.UserAggregate.ValueObjects;

namespace BuberDinner.Domain.HostAggregate;
public sealed class Host : AggregateRoot<HostId>
{
    private readonly List<MenuId> _menuIds = new();
    private readonly List<DinnerId> _dinnerIds = new();
    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public double AverageRating { get; }
    public UserId UserId { get; }
    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Host(HostId hostId,
                 string firstName,
                 string lastName,
                 string profileImage,
                 double averageRating,
                 UserId userId,
                 DateTime createdDateTime,
                 DateTime updatedDateTime) : base(hostId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        UserId = userId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }


    public static Host Create(string firstName,
                              string lastName,
                              string profileImage,
                              double averageRating,
                              UserId userId,
                              DateTime createdDateTime,
                              DateTime updatedDateTIme)
    {
        return new Host(HostId.CreateUnique(),
                        firstName,
                        lastName,
                        profileImage,
                        averageRating,
                        userId,
                        DateTime.UtcNow,
                        DateTime.UtcNow);
    }
}