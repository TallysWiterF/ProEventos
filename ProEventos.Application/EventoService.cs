using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Application;

public class EventoService : IEventoService
{
    private readonly IGeralPersist _geralPersist;
    private readonly IEventoPersist _eventoPersist; 

    public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
    {
        _geralPersist = geralPersist;
        _eventoPersist = eventoPersist;
    }

    public Task<Evento> AddEvento(Evento model)
    {
        throw new NotImplementedException();
    }

    public Task<Evento> DeleteEvento(int eventoId)
    {
        throw new NotImplementedException();
    }

    public Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
    {
        throw new NotImplementedException();
    }

    public Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
    {
        throw new NotImplementedException();
    }

    public Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
    {
        throw new NotImplementedException();
    }

    public Task<Evento> UpdateEvento(int eventoId, Evento model)
    {
        throw new NotImplementedException();
    }
}
