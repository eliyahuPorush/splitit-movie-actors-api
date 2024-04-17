using AutoMapper;
using Dal;
using Dal.Schemas;
using Domain.Dtos;
using Domain.Exceptions;
using Domain.Models.RequestModels;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Services;

public class ActorsService(ApplicationDbContext db, IMapper mapper) : IActorsService
{
    public async Task<ActorDetailsDto> GetActorAsync(Guid id)
    {
        try
        {
            var actor = await db.Actors.FindAsync(id);
            if (actor is null)
            {
                throw new ActorNotExistException($"No actor with id {id}");
            }
            var mappedActor = mapper.Map<ActorDetailsDto>(actor);
            return mappedActor;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<List<ActorDto>> GetActorsAsync(ActorsQueryOptions options)
    {
        var query = db.Actors.AsQueryable();
        if (!string.IsNullOrEmpty(options.Name))
        {
            query = query.Where(actor => actor.Name.Equals(options.Name));
        }

        if (options.MaxRank > 0)
        {
            query = query.Where(actor => actor.Rank <= options.MaxRank);
        }
        if (options.MinRank >= 0)
        {
            query = query.Where(actor => actor.Rank >= options.MinRank);
        }

        if (!string.IsNullOrEmpty(options.Provider))
        {
            query = query.Where(actor => actor.Source.Equals(options.Provider));
        }

        query = query.Skip(options.Skip).Take(options.Take);
        return query
            .Select(actor => mapper.Map<ActorDto>(actor))
            .ToListAsync();
    }

    public async Task<ActorDetailsDto> AddActorAsync(ActorDetailsDto actor)
    {
        try
        {
            var actorWithSameRank = await db.Actors.FirstOrDefaultAsync(a => a.Rank.Equals(actor.Rank));
            if (actorWithSameRank is not null)
            {
                throw new DuplicateRankException($"An Actor with rank value {actor.Rank} already exists.");
            }
            var mappedActor = mapper.Map<Actor>(actor);
            var addedActor = await db.Actors.AddAsync(mappedActor);
            await db.SaveChangesAsync();
            return mapper.Map<ActorDetailsDto>(addedActor.Entity);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> AddActorsAsync(IEnumerable<ActorDetailsDto> actors)
    {
        try
        {
            var mappedActors = actors.Select(mapper.Map<Actor>);
            await db.Actors.AddRangeAsync(mappedActors);
            await db.SaveChangesAsync();
            return true;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ActorDetailsDto?> UpdateActorAsync(ActorDetailsDto actor)
    {
        var mappedActor = mapper.Map<Actor>(actor);
        var existingActor = await db.Actors.FindAsync(actor.Id);
        if (existingActor is null)
        {
            throw new ActorNotExistException($"Actor with id {actor.Id} not exist and cannot be updated");
        }
        db.Actors.Entry(existingActor).CurrentValues.SetValues(mappedActor);
        await db.SaveChangesAsync();
        return mapper.Map<ActorDetailsDto>(existingActor);
    }

    public async Task DeleteActorAsync(Guid id)
    {
        var actorToDelete = await db.Actors.FindAsync(id);
        if (actorToDelete is null)
        {
            throw new ActorNotExistException($"Actor with id {id} not exist and cannot be deleted");
        }

        db.Actors.Remove(actorToDelete);
        await db.SaveChangesAsync();
    }
}