using Lab11_MiguelQuispe.Domain.Interfaces;
using Lab11_MiguelQuispe.Infraestructure.Context;

namespace Lab11_MiguelQuispe.Infraestructure.Services;

public class DataCleanupService : IDataCleanupService
{
    private readonly TicketeraDb _context;

    public DataCleanupService(TicketeraDb context)
    {
        _context = context;
    }

    public void CleanOldData()
    {
        Console.WriteLine($"Iniciando limpieza de datos antiguos: {DateTime.Now}");

        var fechaLimite = DateTime.UtcNow.AddDays(-30);

        var ticketsAntiguos = _context.Tickets
            .Where(t => t.ClosedAt != null && t.ClosedAt < fechaLimite)
            .ToList();

        if (ticketsAntiguos.Count == 0)
        {
            Console.WriteLine("No hay tickets antiguos para eliminar.");
            return;
        }

        _context.Tickets.RemoveRange(ticketsAntiguos);
        _context.SaveChanges();

        Console.WriteLine($"Se eliminaron {ticketsAntiguos.Count} tickets antiguos.");
    }
}