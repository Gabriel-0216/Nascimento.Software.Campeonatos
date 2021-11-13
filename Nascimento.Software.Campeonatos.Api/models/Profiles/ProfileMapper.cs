using AutoMapper;
using Campeonatos.Dominio.Clubes;
using Nascimento.Software.Campeonatos.Api.models.DTO;

namespace Nascimento.Software.Campeonatos.Api.models.Profiles
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<JogadorDTO, Jogador>().ReverseMap();
        }
    }
}
