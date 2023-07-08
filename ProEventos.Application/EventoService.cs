using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

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

    public async Task<Evento?> AddEvento(Evento model)
    {
        try
        {
            _geralPersist.Add(model);
            if (await _geralPersist.SaveChangesAsync())
                return await _eventoPersist.GetEventoByIdAsync(model.Id);

            return null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Evento?> UpdateEvento(int eventoId, Evento model)
    {
        try
        {
            Evento evento = await _eventoPersist.GetEventoByIdAsync(eventoId);
            if (evento != null)
            {
                model.Id = evento.Id;

                _geralPersist.Update(model);
                if (await _geralPersist.SaveChangesAsync())
                    return await _eventoPersist.GetEventoByIdAsync(model.Id);
            }

            return null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> DeleteEvento(int eventoId)
    {
        try
        {
            Evento evento = await _eventoPersist.GetEventoByIdAsync(eventoId);
            if (evento is null)
                throw new Exception("Evento para delete não encontrado");

            _geralPersist.Delete(evento);
            return await _geralPersist.SaveChangesAsync();

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Evento[]?> GetAllEventosAsync(bool includePalestrantes = false)
    {
        try
        {
            Evento[]? eventos = await _eventoPersist.GetAllEventosAsync(includePalestrantes);

            if (eventos is null)
                return null;

            return eventos;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Evento[]?> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
    {
        try
        {
            Evento[]? eventos = await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);

            if (eventos is null)
                return null;

            return eventos;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Evento?> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
    {
        try
        {
            Evento? evento = await _eventoPersist.GetEventoByIdAsync(eventoId, includePalestrantes);

            return evento;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
