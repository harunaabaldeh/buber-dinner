using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication;
public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // Validate the user does not exist
        if (_userRepository.GetByEmail(email) is not null)
        {
            throw new Exception("User already exists");
        }

        // Create user (generate unique id) and persist to database
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        // Generate JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        // 1. Validate user exists
        if (_userRepository.GetByEmail(email) is not User user)
        {
            throw new Exception("User does not exist");
        }

        // 2. Validate password is correct
        if (user.Password != password)
        {
            throw new Exception("Password is incorrect");
        }

        // 3. Generate JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}