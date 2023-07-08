using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contexto;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence;

public class EventoPersist : IEventoPersist
{
    private readonly ProEventosContext _context;

    public EventoPersist(ProEventosContext context)
    {
        _context = context;
        _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
    {
        IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lotes)
            .Include(e => e.RedesSociais);

        if (includePalestrantes)
            query = query.Include(e => e.PalestrantesEventos).ThenInclude(pe => pe.Palestrante);

        query = query.OrderBy(e => e.Id);

        return await query.ToArrayAsync();
    }

    public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
    {
        IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lotes)
            .Include(e => e.RedesSociais);

        if (includePalestrantes)
            query = query.Include(e => e.PalestrantesEventos).ThenInclude(pe => pe.Palestrante);

        query = query.OrderBy(e => e.Id).Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

        return await query.ToArrayAsync();
    }

    public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
    {
        IQueryable<Evento> query = _context.Eventos
            .Include(p => p.Lotes)
            .Include(p => p.RedesSociais);

        if (includePalestrantes)
            query = query.Include(p => p.PalestrantesEventos).ThenInclude(pe => pe.Palestrante);

        query = query.Where(p => p.Id == eventoId);

        return await query.FirstOrDefaultAsync();
    }
}
