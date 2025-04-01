using GlobeGroupe.Tests.WebApi.Data.DTOs;
using GlobeGroupe.Tests.WebApi.Data.Entities;

namespace GlobeGroupe.Tests.WebApi.Services;

/// <summary>
/// Interface définissant les opérations disponibles pour la gestion des missions.
/// </summary>
public interface IMissionService
{
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
    Task<IEnumerable<Mission>> GetAllMissionsAsync(
        int? id,
        string? name,
        DateTime? dateAfter,
        DateTime? dateBefore,
        string? country,
        string? interventionPointName,
        bool? hasPromoter);

    /// <summary>
    /// Récupère une mission spécifique par son ID.
    /// </summary>
    /// <param name="id">ID de la mission à récupérer.</param>
    /// <returns>La mission si trouvée, null sinon.</returns>
    Task<Mission?> GetMissionByIdAsync(int id);

    /// <summary>
    /// Crée une nouvelle mission.
    /// </summary>
    /// <param name="missionDto">Les données de la mission à créer.</param>
    /// <returns>La mission créée avec ses relations.</returns>
    /// <exception cref="ArgumentException">Lancée si les dates sont invalides ou si le promoteur/point d'intervention n'existe pas.</exception>
    /// <exception cref="InvalidOperationException">Lancée si la mission n'a pas pu être créée.</exception>
    Task<Mission> CreateMissionAsync(CreateMissionDto missionDto);
} 