using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.MenuReview;
public class MenuReview : AggregateRoot<MenuReviewId>
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