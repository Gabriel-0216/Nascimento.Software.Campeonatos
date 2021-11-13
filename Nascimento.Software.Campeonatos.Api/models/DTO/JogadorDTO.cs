namespace Nascimento.Software.Campeonatos.Api.models.DTO
{
    public class JogadorDTO
    {
        public string? Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public int NumCamisa { get; set; }
        public int ClubeId { get; set; }

    }
}
