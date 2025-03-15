using OAPortfolio.Domain.Commons.Concretes;

namespace OAPortfolio.Domain.Entities;

public class Summary : EntityBase
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public Summary()
    {

    }
    public Summary(string name, string description, string address, string phone, string email)
    {
        Name = name;
        Description = description;
        Address = address;
        Phone = phone;
        Email = email;
    }
}
