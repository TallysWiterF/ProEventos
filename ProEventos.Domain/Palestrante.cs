namespace ProEventos.Domain;

public class Palestrante
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string MiniCurriculo { get; set; } = string.Empty;
    public string ImagemURL { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public IEnumerable<RedeSocial>? RedesSocials { get; set; }
    public IEnumerable<PalestranteEvento>? PalestrantesEventos { get; set; }
}

