namespace Lab11_MiguelQuispe.Application.DTOs;

public class TicketDto
{
    public Guid TicketId { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string Status { get; set; } = null!;
    public DateTime? CreatedAt { get; set; }
    public DateTime? ClosedAt { get; set; }
}