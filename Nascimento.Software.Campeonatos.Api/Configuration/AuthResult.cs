namespace Nascimento.Software.Campeonatos.Api.Configuration
{
    public class AuthResult
    {
        public string? Token { get; set; }
        public bool Success { get; set; } = false;
        public List<string>? Errors { get; set; }
    }
}
