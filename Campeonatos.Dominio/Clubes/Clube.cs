namespace Campeonatos.Dominio.Clubes
{
    public class Clube
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public ICollection<Jogador> Jogadores { get; set; }

    }
}
