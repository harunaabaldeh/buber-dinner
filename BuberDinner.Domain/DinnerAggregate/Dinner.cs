using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.Entities;
using BuberDinner.Domain.DinnerAggregate.Entities;
using BuberDinner.Domain.DinnerAggregate.Enum;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.DinnerAggregate;
public sealed class Dinner : AggregateRoot<DinnerId>
{
    public string Name { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime? StartedDateTime { get; }
    public DateTime? EndedDateTime { get; }
    public Status Status { get; }
    public bool IsPublic { get; }
    public int MaxGuests { get; }
    public Price Price { get; }
    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public string ImageUrl { get; }
    public Location Location { get; }
    public Reservation Reservation { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Dinner(DinnerId dinnerId,
                   string name,
                   string description,
                   DateTime startDateTime,
                   DateTime endDateTime,
                   DateTime? startedDateTime,
                   DateTime? endedDateTime,
                   Status status,
                   bool isPublic,
                   int maxGuests,
                   Price price,
                   HostId hostId,
                   MenuId menuId,
                   string imageUrl,
                   Location location,
                   Reservation reservation,
                   DateTime createdDateTime,
                   DateTime updatedDateTime) : base(dinnerId)
    {
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        StartedDateTime = startedDateTime;
        EndedDateTime = endedDateTime;
        Status = status;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        HostId = hostId;
        MenuId = menuId;
        ImageUrl = imageUrl;
        Location = location;
        Reservation = reservation;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Dinner Create(string name,
                                string description,
                                DateTime startDateTime,
                                DateTime endDateTime,
                                DateTime? startedDateTime,
                                DateTime? endedDateTime,
                                Status status,
                                bool isPublic,
                                int maxGuests,
                                Price price,
                                HostId hostId,
                                MenuId menuId,
                                string imageUrl,
                                Location location,
                                Reservation reservation,
                                DateTime createdDateTime,
                                DateTime updatedDateTIme
                                )
    {
        return new Dinner(DinnerId.CreateUnique(),
                          name,
                          description,
                          startDateTime,
                          endDateTime,
                          startedDateTime,
                          endedDateTime,
                          status,
                          isPublic,
                          maxGuests,
                          price,
                          hostId,
                          menuId,
                          imageUrl,
                          location,
                          reservation,
                          DateTime.UtcNow,
                          DateTime.UtcNow);
    }
}