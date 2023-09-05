using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contexto;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public EventosController(IEventoService eventoService) => _eventoService = eventoService;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                Evento[] eventos = await _eventoService.GetAllEventosAsync(true);
                if (eventos is null)
                    return NotFound("Nenhum evento foi encontrado.");

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Evento evento = await _eventoService.GetEventoByIdAsync(id, true);
                if (evento is null)
                    return NotFound("Evento não encontrado.");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao tentar recuperar evento. Erro: {ex.Message}");
            }
        }

        [HttpGet("tema/{tema}")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            try
            {
                Evento[] eventos = await _eventoService.GetAllEventosByTemaAsync(tema, true);
                if (eventos is null)
                    return NotFound("Eventos por tema não encontrados.");

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
            try
            {
                Evento? eventos = await _eventoService.AddEvento(model);
                if (eventos is null)
                    return BadRequest("Erro ao tentar adicionar evento.");

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao tentar adicionar evento. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Evento model)
        {
            try
            {
                Evento? eventos = await _eventoService.UpdateEvento(id, model);
                if (eventos is null)
                    return BadRequest("Erro ao tentar atualizar evento.");

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao tentar atualizar evento. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _eventoService.DeleteEvento(id) ?
                    Ok("Evento deletado.") : BadRequest("Ocorreu um erro ao deletar o evento");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao tentar deletar evento. Erro: {ex.Message}");
            }
        }
    }
}