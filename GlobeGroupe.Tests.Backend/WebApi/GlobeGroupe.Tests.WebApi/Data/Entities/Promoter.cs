namespace GlobeGroupe.Tests.WebApi.Data.Entities;

public class Promoter
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime Birthdate { get; set; }
    public List<Mission> Missions { get; set; } = [];
}
