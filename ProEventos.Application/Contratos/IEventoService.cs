using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application.Contratos;

public interface IEventoService : IEventoPersist
{
    Task<Evento?> AddEvento(Evento model);
    Task<Evento?> UpdateEvento(int eventoId, Evento model);
    Task<bool> DeleteEvento(int eventoId);
}
