using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;

namespace BuberDinner.Domain.DinnerAggregate.Entities;
public class Location : Entity<LocationId>
{
    public string Name { get; }
    public string Address { get; }
    public double Latitude { get; }
    public double Longitude { get; }

    private Location(LocationId locationId,
                     string name,
                     string address,
                     double latitude,
                     double longitude) : base(locationId)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
    }

    public static Location Create(string name, string address, double latitude, double longitude)
    {
        return new Location(LocationId.CreateUnique(), name, address, latitude, longitude);
    }
}