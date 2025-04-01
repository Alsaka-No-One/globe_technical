using GlobeGroupe.Tests.WebApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlobeGroupe.Tests.WebApi.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Promoter> Promoters { get; set; }
    public DbSet<InterventionPoint> InterventionPoints { get; set; }
    public DbSet<Mission> Missions { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
