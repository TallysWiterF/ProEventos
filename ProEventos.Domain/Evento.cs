namespace ProEventos.Domain;

public class Evento
{
    public int Id { get; set; }
    public string Local { get; set; } = string.Empty;
    public DateTime? DataEvento { get; set; }
    public string Tema { get; set; } = string.Empty;
    public int QtdPessoas { get; set; }
    public string ImagemURL { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public IEnumerable<Lote>? Lotes { get; set; } 
    public IEnumerable<RedeSocial>? RedesSociais { get; set; } 
    public IEnumerable<PalestranteEvento>? PalestrantesEventos { get; set; }
}