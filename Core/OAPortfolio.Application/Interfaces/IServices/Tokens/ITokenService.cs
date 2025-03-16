using OAPortfolio.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace OAPortfolio.Application.Interfaces.IServices.Tokens;

public interface ITokenService
{
    Task<JwtSecurityToken> CreateToken(User user, IList<string> roles);
}
