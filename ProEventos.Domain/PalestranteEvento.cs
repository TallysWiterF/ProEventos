namespace ProEventos.Domain;
public class PalestranteEvento
{
    public int PalestranteId { get; set; }
    public Palestrante Palestrante { get; set; } = new Palestrante();
    public int EventoId { get; set; }
    public Evento Evento { get; set; } = new Evento();
}