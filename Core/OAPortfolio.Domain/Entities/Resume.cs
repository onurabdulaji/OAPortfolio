using OAPortfolio.Domain.Commons.Concretes;

namespace OAPortfolio.Domain.Entities;

public class Resume : EntityBase
{
    public string? Title { get; set; }
    public string? City { get; set; }
    public DateTime? YearsFromDate { get; set; }
    public DateTime? YearsFromToDate { get; set; }
    public string? ResponsibleTitle1 { get; set; }
    public string? ResponsibleTitle2 { get; set; }
    public string? ResponsibleTitle3 { get; set; }
    public string? ResponsibleTitle4 { get; set; }
    public string? ResponsibleTitle5 { get; set; }
    public string? ResponsibleTitle6 { get; set; }
    public Resume()
    {

    }
    public Resume(string title, string city, DateTime fromDate, DateTime fromToDate, string rTitle1,
        string rTitle2, string rTitle3, string rTitle4, string rTitle5, string rTitle6)
    {
        Title = title;
        City = city;
        YearsFromDate = fromDate;
        YearsFromToDate = fromToDate;
        ResponsibleTitle1 = rTitle1;
        ResponsibleTitle2 = rTitle2;
        ResponsibleTitle3 = rTitle3;
        ResponsibleTitle4 = rTitle4;
        ResponsibleTitle5 = rTitle5;
        ResponsibleTitle6 = rTitle6;
    }
}
