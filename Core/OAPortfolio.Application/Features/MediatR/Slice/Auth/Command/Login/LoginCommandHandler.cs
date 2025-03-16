using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using OAPortfolio.Application.Features.MediatR.Slice.Auth.Command.Login.Rules;
using OAPortfolio.Application.Interfaces.IServices.Tokens;
using OAPortfolio.Domain.Entities;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;

namespace OAPortfolio.Application.Features.MediatR.Slice.Auth.Command.Login;

public static class LoginCommandHandler
{
    public class LoginCommandRequest : IRequest<LoginCommandResponse>
    {
        [DefaultValue("onurabdulaji@gmail.com")]
        public string Email { get; set; }
        [DefaultValue("Admin123!@#")]
        public string Password { get; set; }
    }

    public class LoginCommandResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
    }

    public class Handler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly UserManager<User> userManager;
        private readonly AuthRules authRules;
        private readonly RoleManager<Role> roleManager;
        private readonly ITokenService tokenService;
        private readonly IConfiguration configuration;

        public Handler(UserManager<User> userManager, AuthRules authRules, RoleManager<Role> roleManager, ITokenService tokenService, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.authRules = authRules;
            this.roleManager = roleManager;
            this.tokenService = tokenService;
            this.configuration = configuration;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            // Kullanıcı kontrolü
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }
            // Şifre kontrolü
            var checkPassword = await userManager.CheckPasswordAsync(user, request.Password);
            if (!checkPassword)
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }
            // Kullanıcının rollerini al
            var roles = await userManager.GetRolesAsync(user);
            if (roles == null || !roles.Any())
            {
                throw new UnauthorizedAccessException("User does not have any roles assigned.");
            }
            // Token oluştur
            var token = await tokenService.CreateToken(user, roles);
            var refreshToken = tokenService.GenerateRefreshToken();

            if (!int.TryParse(configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays))
            {
                refreshTokenValidityInDays = 7; // Default değer
            }
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

            await userManager.UpdateAsync(user);
            await userManager.UpdateSecurityStampAsync(user);

            var _token = new JwtSecurityTokenHandler().WriteToken(token);
            await userManager.SetAuthenticationTokenAsync(user, "Bearer", "Token", _token);

            return new LoginCommandResponse
            {
                Token = _token,
                RefreshToken = refreshToken,
                Expiration = token.ValidTo
            };
        }
    }
    public class Endpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/auth/login", async (LoginCommandRequest command, ISender sender) =>
            {
                var response = await sender.Send(command);
                return Results.Ok(response);
            });
        }
    }
}
