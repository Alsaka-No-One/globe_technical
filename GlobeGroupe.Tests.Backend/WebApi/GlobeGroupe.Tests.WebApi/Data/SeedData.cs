using GlobeGroupe.Tests.WebApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace GlobeGroupe.Tests.WebApi.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using ApplicationDbContext context = new(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

        if (context.Promoters.Any())
        {
            return;
        }

        string jsonData = File.ReadAllText("Data/datasource.json");
        Root? data = JsonSerializer.Deserialize<Root>(jsonData);

        if (data != null)
        {
            context.Promoters.AddRange(data.Promoters);
            context.InterventionPoints.AddRange(data.InterventionPoints);
            context.Missions.AddRange(data.Missions);
            context.SaveChanges();
        }
    }

    private class Root
    {
        public List<Promoter> Promoters { get; set; }
        public List<InterventionPoint> InterventionPoints { get; set; }
        public List<Mission> Missions { get; set; }
    }
}
