using ErrorOr;

namespace BuberDinner.Domain.Common.Errors;
public static partial class Errors
{
    public static class User
    {
        public static Error DubplicateEmail(string email) => Error.Conflict(code: "User.DuplicateEmail", description: $"Email '{email}' already exists");
    }
}