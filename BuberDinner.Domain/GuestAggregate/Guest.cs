using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;
using BuberDinner.Domain.UserAggregate.ValueObjects;

namespace BuberDinner.Domain.GuestAggregate;
public sealed class Guest : AggregateRoot<GeustId>
{
    private readonly List<DinnerId> _pastDinnerIds = new();
    private readonly List<DinnerId> _pendingDinnerIds = new();
    private readonly List<BillId> _billIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public double AverageRating { get; }
    public UserId UserId { get; }
    public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
    public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();
    public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public string Ratings { get; }
    DateTime CreatedDateTime { get; }
    DateTime UpdatedDateTime { get; }



    private Guest(GeustId geustId,
                  string firstName,
                  string lastName,
                  string profileImage,
                  double averageRating,
                  UserId userId,
                  string ratings,
                  DateTime createdDateTime,
                  DateTime updatedDateTime) : base(geustId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        UserId = userId;
        Ratings = ratings;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Guest Create(string firstName,
                               string lastName,
                               string profileImage,
                               double averageRating,
                               UserId userId,
                               string ratings,
                               DateTime createdDateTime,
                               DateTime updatedDateTIme)
    {
        return new Guest(GeustId.CreateUnique(),
                         firstName,
                         lastName,
                         profileImage,
                         averageRating,
                         userId,
                         ratings,
                         DateTime.UtcNow,
                         DateTime.UtcNow);
    }
}