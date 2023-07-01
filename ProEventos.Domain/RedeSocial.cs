namespace ProEventos.Domain;
public class RedeSocial
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string URL { get; set; } = string.Empty;
    public int EventoId { get; set; }
    public Evento Evento { get; set; } = new Evento();
    public int? PalestranteId { get; set; }
    public Palestrante Palestrante { get; set; } = new Palestrante();
}