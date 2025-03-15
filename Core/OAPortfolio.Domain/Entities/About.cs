using OAPortfolio.Domain.Commons.Concretes;

namespace OAPortfolio.Domain.Entities;

public class About : EntityBase
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime? Birthday { get; set; }
    public int? Age { get; set; }
    public string? Website { get; set; }
    public string? Degree { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? City { get; set; }
    public bool? IsFreelanceAvailable { get; set; }

    public About() { }
    public About(
        string title,
        string description,
        DateTime? birthday,
        int? age,
        string? website,
        string? degree,
        string? phone,
        string? email,
        string? city,
        bool? isFreelanceAvailable
        )
    {
        Title = title;
        Description = description;
        Birthday = birthday;
        Age = age;
        Website = website;
        Degree = degree;
        Phone = phone;
        Email = email;
        City = city;
        IsFreelanceAvailable = isFreelanceAvailable;
    }
}
