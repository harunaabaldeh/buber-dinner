using BuberDinner.Application.Common.Interfaces.Services;

namespace BuberDinner.Infrastracture.Services;
public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}