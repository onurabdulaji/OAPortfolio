using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using OAPortfolio.Application.Interfaces.IServices.Tokens;
using OAPortfolio.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OAPortfolio.Infastructure.Managers.Tokens;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<TokenService> _logger;

    public TokenService(IConfiguration configuration, ILogger<TokenService> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<JwtSecurityToken> CreateToken(User user, IList<string> roles)
    {
        try
        {
            if (user == null || string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Email))
            {
                _logger.LogError("Invalid user credentials.");
                return null;
            }

            var jwtSettings = _configuration.GetSection("JWT");
            var jwtKey = jwtSettings["SecretKey"];

            if (string.IsNullOrEmpty(jwtKey))
            {
                _logger.LogError("JWT configuration is invalid or missing.");
                return null;
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpirationMinutes"])),
                signingCredentials: credentials
            );

            return token;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Token generation failed.");
            return null;
        }
    }
}
