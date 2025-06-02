using Lab11_MiguelQuispe.Application.DTOs;
using Lab11_MiguelQuispe.Application.UsesCases.Tickets.Commands;
using Lab11_MiguelQuispe.Application.UsesCases.Tickets.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab11_MiguelQuispe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TicketsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<TicketDto>>> GetAll()
    {
        var tickets = await _mediator.Send(new GetAllTicketsQuery());
        return Ok(tickets);
    }

    // GET: api/tickets/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<TicketDto>> GetById(Guid id)
    {
        var ticket = await _mediator.Send(new GetTicketByIdQuery(id));
        if (ticket == null) return NotFound();
        return Ok(ticket);
    }

    // POST: api/tickets
    [HttpPost]
    public async Task<ActionResult<Guid>> Create(AddTicketCommand command)
    {
        var newId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = newId }, newId);
    }

    // PUT: api/tickets/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, UpdateTicketCommand command)
    {
        if (id != command.TicketId)
            return BadRequest("Ticket ID mismatch.");

        var result = await _mediator.Send(command);
        if (!result) return NotFound();

        return NoContent();
    }

    // DELETE: api/tickets/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteTicketCommand(id));
        if (!result) return NotFound();

        return NoContent();
    }
}