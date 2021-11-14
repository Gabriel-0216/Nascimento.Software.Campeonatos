using AutoMapper;
using Campeonatos.Dominio.Clubes;
using Campeonatos.Dominio.Tabela;
using Nascimento.Software.Campeonatos.Api.models.DTO;
using Nascimento.Software.Campeonatos.Api.models.DTO.Subdominios;

namespace Nascimento.Software.Campeonatos.Api.models.Profiles
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<JogadorDTO, Jogador>().ReverseMap();
            CreateMap<ClubeDTO, Clube>().ReverseMap();
            CreateMap<ClubeCadastroDTO, Clube>().ReverseMap();
            CreateMap<PartidaDTO, Partidas>().ReverseMap();
            CreateMap<PartidaCadastroDTO, Partidas>().ReverseMap();
            CreateMap<GolsCadastroDTO, Artilharia>().ReverseMap();
            CreateMap<AssistenciasCadastroDTO, Assistencias>().ReverseMap();
            CreateMap<Amarelos, AmarelosCadastroDTO>().ReverseMap();
            CreateMap<Vermelhos, VermelhoCadastroDTO>().ReverseMap();
        }
    }
}
