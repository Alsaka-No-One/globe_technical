using GlobeGroupe.Tests.WebApi.Data;
using GlobeGroupe.Tests.WebApi.Data.DTOs;
using GlobeGroupe.Tests.WebApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlobeGroupe.Tests.WebApi.Services;

/// <summary>
/// Service gérant les opérations liées aux missions.
/// </summary>
public class MissionService : IMissionService
{
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// Initialise une nouvelle instance du service des missions.
    /// </summary>
    /// <param name="context">Le contexte de base de données.</param>
    public MissionService(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Récupère toutes les missions avec des filtres optionnels.
    /// </summary>
    /// <param name="id">ID de la mission à rechercher.</param>
    /// <param name="name">Nom ou partie du nom de la mission.</param>
    /// <param name="dateAfter">Date de début minimale.</param>
    /// <param name="dateBefore">Date de fin maximale.</param>
    /// <param name="country">ID du pays.</param>
    /// <param name="interventionPointName">Nom ou partie du nom du point d'intervention.</param>
    /// <param name="hasPromoter">Indique si la mission doit avoir un promoteur assigné.</param>
    /// <returns>Une collection de missions correspondant aux critères de filtrage.</returns>
    public async Task<IEnumerable<Mission>> GetAllMissionsAsync(
        int? id,
        string? name,
        DateTime? dateAfter,
        DateTime? dateBefore,
        string? country,
        string? interventionPointName,
        bool? hasPromoter)
    {
        IQueryable<Mission> missionsQuery = _context.Missions
            .Include(m => m.Promoter)
            .Include(m => m.InterventionPoint)
            .AsQueryable();

        if (id.HasValue)
        {
            missionsQuery = missionsQuery.Where(m => m.Id == id.Value);
        }

        if (!string.IsNullOrEmpty(name))
        {
            missionsQuery = missionsQuery.Where(m => m.Name.Contains(name));
        }

        if (dateAfter.HasValue)
        {
            missionsQuery = missionsQuery.Where(m => m.StartDate >= dateAfter.Value);
        }

        if (dateBefore.HasValue)
        {
            missionsQuery = missionsQuery.Where(m => m.EndDate <= dateBefore.Value);
        }

        if (!string.IsNullOrEmpty(country))
        {
            missionsQuery = missionsQuery.Where(m => m.InterventionPoint.CountryId.ToString() == country);
        }

        if (!string.IsNullOrEmpty(interventionPointName))
        {
            missionsQuery = missionsQuery.Where(m => m.InterventionPoint.Name.Contains(interventionPointName));
        }

        if (hasPromoter.HasValue)
        {
            missionsQuery = missionsQuery.Where(m => hasPromoter.Value ? m.PromoterId.HasValue : !m.PromoterId.HasValue);
        }

        return await missionsQuery.ToListAsync();
    }

    /// <summary>
    /// Récupère une mission spécifique par son ID.
    /// </summary>
    /// <param name="id">ID de la mission à récupérer.</param>
    /// <returns>La mission si trouvée, null sinon.</returns>
    public async Task<Mission?> GetMissionByIdAsync(int id)
    {
        return await _context.Missions
            .Include(m => m.Promoter)
            .Include(m => m.InterventionPoint)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    /// <summary>
    /// Crée une nouvelle mission.
    /// </summary>
    /// <param name="missionDto">Les données de la mission à créer.</param>
    /// <returns>La mission créée avec ses relations.</returns>
    /// <exception cref="ArgumentException">Lancée si les dates sont invalides ou si le promoteur/point d'intervention n'existe pas.</exception>
    /// <exception cref="InvalidOperationException">Lancée si la mission n'a pas pu être créée.</exception>
    public async Task<Mission> CreateMissionAsync(CreateMissionDto missionDto)
    {
        if (missionDto.StartDate >= missionDto.EndDate)
        {
            throw new ArgumentException("La date de début doit être antérieure à la date de fin.");
        }

        if (missionDto.PromoterId.HasValue)
        {
            Promoter? promoter = await _context.Promoters.FindAsync(missionDto.PromoterId);
            if (promoter == null)
            {
                throw new ArgumentException("Le promoteur spécifié n'existe pas.");
            }
        }

        InterventionPoint? interventionPoint = await _context.InterventionPoints.FindAsync(missionDto.InterventionPointId);
        if (interventionPoint == null)
        {
            throw new ArgumentException("Le point d'intervention spécifié n'existe pas.");
        }

        Mission newMission = new Mission
        {
            Name = missionDto.Name,
            Description = missionDto.Description,
            StartDate = missionDto.StartDate,
            EndDate = missionDto.EndDate,
            PromoterId = missionDto.PromoterId,
            InterventionPointId = missionDto.InterventionPointId
        };

        _context.Missions.Add(newMission);
        await _context.SaveChangesAsync();

        Mission? createdMission = await GetMissionByIdAsync(newMission.Id);
        if (createdMission == null)
        {
            throw new InvalidOperationException("La mission n'a pas pu être créée.");
        }

        return createdMission;
    }
} 
