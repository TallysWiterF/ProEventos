using Microsoft.AspNetCore.Mvc;
using ProEventos.Domain;
using ProEventos.Persistence.Contexto;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly ProEventosContext _context;

        public EventosController(ProEventosContext context) => _context = context;

        [HttpGet]
        public IEnumerable<Evento> Get() => _context.Eventos;

        [HttpGet("{id}")]
        public Evento? GetById(int id) => _context.Eventos.FirstOrDefault(x => x.Id == id);

    }
}