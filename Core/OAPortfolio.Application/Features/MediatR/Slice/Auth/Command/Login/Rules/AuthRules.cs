using OAPortfolio.Domain.Entities;

namespace OAPortfolio.Application.Features.MediatR.Slice.Auth.Command.Login.Rules;

public class AuthRules
{
    public Task EmailOrPasswordShouldNotBeInvalid(User? user , bool checkPassword)
    {
        if (user is null || !checkPassword) throw new Exception("Islem Basarisiz , Sifre yada Kullanici valid edilmedi");
        return Task.CompletedTask;
    }
}
