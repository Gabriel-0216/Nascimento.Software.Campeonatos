using System.ComponentModel.DataAnnotations;

namespace Nascimento.Software.Campeonatos.Api.models.DTO.Identity.Request
{
    public class UserRegistrationDTO
    {
        public UserRegistrationDTO(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
