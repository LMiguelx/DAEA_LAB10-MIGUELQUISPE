using Lab11_MiguelQuispe.Application.DTOs;
using Lab11_MiguelQuispe.Application.UsesCases.Roles.Commands;
using Lab11_MiguelQuispe.Application.UsesCases.Roles.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab11_MiguelQuispe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RolesController : ControllerBase
{
    private readonly IMediator _mediator;

    public RolesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<RoleDto>>> Get()
    {
        var roles = await _mediator.Send(new GetRolesQuery());
        return Ok(roles);
    }
    [HttpPost]
    public async Task<ActionResult<RoleDto>> Create([FromBody] AddRoleCommand command)
    {
        var createdRole = await _mediator.Send(command);
        return CreatedAtAction(nameof(Get), new { id = createdRole.RoleId }, createdRole);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<RoleDto>> Update(Guid id, [FromBody] UpdateRoleCommand command)
    {
        if (id != command.RoleId)
            return BadRequest("Mismatched role ID");

        var updatedRole = await _mediator.Send(command);
        return Ok(updatedRole);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteRoleCommand(id));
        if (!result)
            return NotFound();

        return NoContent();
    }
}