namespace GlobeGroupe.Tests.WebApi.Data.Entities;

public class InterventionPoint
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public int CountryId { get; set; }
    //public Country Country { get; set; }
    public string Brand { get; set; }
}

public class Country
{
    public int Id { get; set; }
    public string Name { get; set; }
}
