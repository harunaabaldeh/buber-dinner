using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuReviewAggregate;
public sealed class MenuReview : AggregateRoot<MenuReviewId>
{
    public double Rating { get; }
    public string Comment { get; }
    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public GeustId GeustId { get; }
    public DinnerId DinnerId { get; }
    DateTime CreatedDateTime { get; }
    DateTime UpdatedDateTime { get; }
    private MenuReview(MenuReviewId menuReviewId,
                       double rating,
                       string comment,
                       HostId hostId,
                       MenuId menuId,
                       GeustId geustId,
                       DinnerId dinnerId,
                       DateTime createdDateTime,
                       DateTime updatedDateTime) : base(menuReviewId)
    {
        Rating = rating;
        Comment = comment;
        HostId = hostId;
        MenuId = menuId;
        GeustId = geustId;
        DinnerId = dinnerId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static MenuReview Create(double rating,
                                    string comment,
                                    HostId hostId,
                                    MenuId menuId,
                                    GeustId geustId,
                                    DinnerId dinnerId,
                                    DateTime createdDateTime,
                                    DateTime updatedDateTime)
    {
        return new MenuReview(MenuReviewId.CreateUnique(),
                              rating,
                              comment,
                              hostId,
                              menuId,
                              geustId,
                              dinnerId,
                              DateTime.UtcNow,
                              DateTime.UtcNow);
    }
}