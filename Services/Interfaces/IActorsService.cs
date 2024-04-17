using Dal.Schemas;
using Domain.Dtos;
using Domain.Models.RequestModels;

namespace Services.Interfaces;

public interface IActorsService
{
    Task<ActorDetailsDto> GetActorAsync(Guid id);
    Task<List<ActorDto>> GetActorsAsync(ActorsQueryOptions options);
    Task<ActorDetailsDto> AddActorAsync(ActorDetailsDto actor);
    Task<bool> AddActorsAsync(IEnumerable<ActorDetailsDto> actors);
    Task<ActorDetailsDto?> UpdateActorAsync(ActorDetailsDto actor);
    Task DeleteActorAsync(Guid id);
}