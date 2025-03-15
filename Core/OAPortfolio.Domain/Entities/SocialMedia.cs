using OAPortfolio.Domain.Commons.Concretes;

namespace OAPortfolio.Domain.Entities;

public class SocialMedia : EntityBase
{
    public string? Title { get; set; }
    public string? Icon { get; set; }
    public string? Link { get; set; }
    public SocialMedia()
    {
    }
    public SocialMedia(string title, string icon, string link)
    {
        Title = title;
        Icon = icon;
        Link = link;
    }
}