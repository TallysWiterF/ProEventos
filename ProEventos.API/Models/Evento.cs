namespace ProEventos.API.Models;

public class Evento
{
    public int EventoId { get; set; }
    public string Local { get; set; } = string.Empty;
    public string DataEvento { get; set; } = string.Empty;
    public string Tema { get; set; } = string.Empty;
    public int QtdPessoas { get; set; }
    public string Lote { get; set; } = string.Empty;
    public string ImagemURL { get; set; } = string.Empty;
}

