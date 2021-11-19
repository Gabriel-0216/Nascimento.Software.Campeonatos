using System.ComponentModel.DataAnnotations;

namespace Nascimento.Software.Campeonatos.Api.models.DTO.Identity.Request
{
    public class UserLoginRequest
    {
        public UserLoginRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
