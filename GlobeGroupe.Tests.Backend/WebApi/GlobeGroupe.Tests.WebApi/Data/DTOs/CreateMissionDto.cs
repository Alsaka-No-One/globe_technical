namespace GlobeGroupe.Tests.WebApi.Data.DTOs;

public class CreateMissionDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int? PromoterId { get; set; }
    public int InterventionPointId { get; set; }
} 