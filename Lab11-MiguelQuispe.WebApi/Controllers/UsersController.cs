using Lab11_MiguelQuispe.Application.UsesCases.Users.Commands;
using Lab11_MiguelQuispe.Application.UsesCases.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab11_MiguelQuispe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var result = await _mediator.Send(new GetUsersQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] AddUserCommand command)
    {
        var userId = await _mediator.Send(command);
        return Ok(userId);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserCommand command)
    {
        if (id != command.Id)
            return BadRequest("ID de la URL no coincide con el del cuerpo");

        var result = await _mediator.Send(command);
        if (!result)
            return NotFound("Usuario no encontrado");

        return NoContent();
    }

    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteUserCommand(id));
        if (!result)
            return NotFound();

        return NoContent();
    }

}