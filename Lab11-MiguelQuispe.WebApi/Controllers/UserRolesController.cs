using Lab11_MiguelQuispe.Application.DTOs;
using Lab11_MiguelQuispe.Application.UsesCases.UseRol.Command;
using Lab11_MiguelQuispe.Application.UsesCases.UseRol.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab11_MiguelQuispe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserRolesController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserRolesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserRoleDto>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllUserRolesQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AssignUserRoleCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetAll), new { }, result);
    }
}
