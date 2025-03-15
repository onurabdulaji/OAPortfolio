using OAPortfolio.Domain.Commons.Concretes;

namespace OAPortfolio.Domain.Entities;

public class Project : EntityBase
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? SmallImage { get; set; }
    public string? Category { get; set; }
    public string? Client { get; set; }
    public DateTime? Date { get; set; }
    public string? Link { get; set; }
    public ICollection<string>? Images { get; set; } // 'ProjectImage1', 'ProjectImage2'
    public Project() { }
    public Project(string? title, string? description, string? smallImage, string? category, string? client, DateTime? date, string? link, ICollection<string>? images)
    {
        Title = title;
        Description = description;
        SmallImage = smallImage;
        Category = category;
        Client = client;
        Date = date;
        Link = link;
        Images = images ?? new List<string>(); // Default empty list
    }
}
