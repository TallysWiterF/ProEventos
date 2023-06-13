using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly DataContext _context;

        public EventosController(DataContext context) => _context = context;

        [HttpGet]
        public IEnumerable<Evento> Get() => _context.Eventos;

        [HttpGet("{eventoId}")]
        public Evento? GetById(int eventoId) => _context.Eventos.FirstOrDefault(x => x.EventoId == eventoId);

    }
}