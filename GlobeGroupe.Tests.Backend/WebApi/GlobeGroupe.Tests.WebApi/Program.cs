using GlobeGroupe.Tests.WebApi.Data;
using GlobeGroupe.Tests.WebApi.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
       .AddJsonOptions(options =>
                       {
                           options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                       });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("InMemoryDb"));
builder.Services.AddScoped<IMissionService, MissionService>();

WebApplication app = builder.Build();

using (IServiceScope serviceScope = app.Services.CreateScope())
{
    IServiceProvider services = serviceScope.ServiceProvider;
    SeedData.Initialize(services);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
