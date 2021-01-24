using AutoMapper;
using TaskList.Domain.Entities;
using TaskList.Domain.ViewModels;

namespace TaskList.Services.Profiles
{
    public class UsuarioModelProfile : Profile
    {
        public UsuarioModelProfile()
        {
            CreateMap<Usuario, UsuarioModel>()
                .ForMember(d => d.Id, s => s.MapFrom(m => m.Id))
                .ForMember(d => d.Username, s => s.MapFrom(m => m.Username))
                .ForMember(d => d.Password, s => s.MapFrom(m => m.Password))
                .ForAllOtherMembers(d => d.Ignore());

            CreateMap<UsuarioModel, Usuario>()
                .ForMember(d => d.Id, s => s.MapFrom(m => m.Id))
                .ForMember(d => d.Username, s => s.MapFrom(m => m.Username))
                .ForMember(d => d.Password, s => s.MapFrom(m => m.Password))
                .ForAllOtherMembers(d => d.Ignore());

        }
    }
}