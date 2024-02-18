using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BuberDinner.Infrastracture.Authentication;

public class JwtTokenGenerators : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;
    private readonly IDateTimeProvider _dateTimeProvider;

    public JwtTokenGenerators(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jtwOptions)
    {
        _dateTimeProvider = dateTimeProvider;
        _jwtSettings = jtwOptions.Value;
    }

    public string GenerateToken(User user)
    {
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
         SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
           new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
           new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
           new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryInMinutes),
            claims: claims,
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
