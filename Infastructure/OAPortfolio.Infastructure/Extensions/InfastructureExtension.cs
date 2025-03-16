using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OAPortfolio.Application.Interfaces.IServices.Tokens;
using OAPortfolio.Infastructure.Managers.Tokens;

namespace OAPortfolio.Infastructure.Extensions;

public static class InfastructureExtension
{
    public static void AddInfastructureLayer(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddTransient<ITokenService, TokenService>();
    }
}
