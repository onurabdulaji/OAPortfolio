using Carter;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OAPortfolio.Application.Features.MediatR.Slice.Auth.Command.Login.Rules;
using System.Reflection;

namespace OAPortfolio.Application.Extensions;

public static class ApplicationExtension
{
    public static void AddApplicationLayer(this IServiceCollection services,IConfiguration configuration)
    {
        var assembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        services.AddTransient<AuthRules>();  // AuthRules sınıfını DI konteynerine ekle

    }
}
