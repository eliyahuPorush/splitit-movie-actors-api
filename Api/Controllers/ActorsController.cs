using Domain.Dtos;
using Domain.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ActorsController(IActorsService actorsService) : ControllerBase
{

    [HttpGet]
    [SwaggerOperation("Get A List Of Actors")]
    [SwaggerResponse(200, "Returns the list of actors", typeof(IEnumerable<ActorDto>))]
    public async Task<IActionResult> GetActors([FromQuery] ActorsQueryOptions options)
    {
        return Ok(await actorsService.GetActorsAsync(options));
    }
    
    [HttpGet, Route("{id}")]
    [SwaggerOperation("Get Actor By Id")]
    [SwaggerResponse(200, "Returns the actor with the specified ID", typeof(ActorDto))]
    [SwaggerResponse(400, "If the actor with the specified ID does not exist")]
    public async Task<IActionResult> GetActor([FromRoute] Guid id)
    {
        var actor = await actorsService.GetActorAsync(id);
        return Ok(actor);
    }

    [HttpPost]
    [SwaggerOperation("Add New Actor")]
    [SwaggerResponse(201, "Returns the newly created actor", typeof(ActorDto))]
    public async Task<IActionResult> AddActor([FromBody] ActorDetailsDto actor)
    {
        var createdActor = await actorsService.AddActorAsync(actor);
        return Created(string.Empty, createdActor);
    }

    [HttpPut, Route("{actorId}")]
    [SwaggerOperation("Update existing Actor")]
    [SwaggerResponse(201, "Returns the updated actor", typeof(ActorDto))]
    [SwaggerResponse(400, "If the actor with the specified ID does not exist")]
    public async Task<IActionResult> UpdateActor([FromBody] ActorDetailsDto actor, [FromRoute] Guid actorId)
    {
        actor.Id = actorId;
        var updatedActor = await actorsService.UpdateActorAsync(actor);
        return Created(string.Empty, updatedActor);
    }

    [HttpDelete, Route("{id}")]
    [SwaggerOperation("Delete The Actor With The Provided Id")]
    [SwaggerResponse(204, "No content")]
    [SwaggerResponse(400, "If the actor with the specified ID does not exist")]
    public async Task<IActionResult> DeleteActor([FromRoute] Guid id)
    {
        await actorsService.DeleteActorAsync(id);
        return NoContent();
    }
    
}