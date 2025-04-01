using GlobeGroupe.Tests.WebApi.Data.DTOs;
using GlobeGroupe.Tests.WebApi.Data.Entities;
using GlobeGroupe.Tests.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GlobeGroupe.Tests.WebApi.Controllers;

/// <summary>
/// Contrôleur gérant les opérations liées aux missions.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class MissionsController : ControllerBase
{
    private readonly IMissionService _missionService;

    /// <summary>
    /// Initialise une nouvelle instance du contrôleur des missions.
    /// </summary>
    /// <param name="missionService">Le service de gestion des missions.</param>
    public MissionsController(IMissionService missionService)
    {
        _missionService = missionService;
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
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Mission>>> GetMissions(
        [FromQuery] int? id,
        [FromQuery] string? name,
        [FromQuery] DateTime? dateAfter,
        [FromQuery] DateTime? dateBefore,
        [FromQuery] string? country,
        [FromQuery] string? interventionPointName,
        [FromQuery] bool? hasPromoter)
    {
        IEnumerable<Mission> missions = await _missionService.GetAllMissionsAsync(
            id,
            name,
            dateAfter,
            dateBefore,
            country,
            interventionPointName,
            hasPromoter);

        return Ok(missions);
    }

    /// <summary>
    /// Récupère une mission spécifique par son ID.
    /// </summary>
    /// <param name="id">ID de la mission à récupérer.</param>
    /// <returns>La mission si trouvée, sinon une réponse 404 Not Found.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Mission>> GetMission(int id)
    {
        Mission? mission = await _missionService.GetMissionByIdAsync(id);
        
        if (mission == null)
        {
            return NotFound($"La mission avec l'ID {id} n'a pas été trouvée.");
        }

        return Ok(mission);
    }

    /// <summary>
    /// Crée une nouvelle mission.
    /// </summary>
    /// <param name="missionDto">Les données de la mission à créer.</param>
    /// <returns>La mission créée avec un code 201 Created, ou une réponse d'erreur appropriée.</returns>
    [HttpPost]
    public async Task<ActionResult<Mission>> CreateMission(CreateMissionDto missionDto)
    {
        try
        {
            Mission mission = await _missionService.CreateMissionAsync(missionDto);
            return CreatedAtAction(nameof(GetMission), new { id = mission.Id }, mission);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
} 
