namespace GlobeGroupe.Tests.WebApi.Data.Entities;

public class Mission
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int? PromoterId { get; set; }
    public Promoter? Promoter { get; set; }
    public int InterventionPointId { get; set; }
    public InterventionPoint InterventionPoint { get; set; }
}