using AutoMapper;
using TaskList.Domain.Entities;
using TaskList.Domain.ViewModels;

namespace TaskList.Services.Profiles
{
    public class TarefaModelProfile : Profile
    {
        public TarefaModelProfile()
        {
            CreateMap<Tarefa, TarefaModel>()
                .ForMember(d => d.Id, s => s.MapFrom(m => m.Id))
                .ForMember(d => d.Titulo, s => s.MapFrom(m => m.Titulo))
                .ForMember(d => d.Descricao, s => s.MapFrom(m => m.Descricao))
                .ForMember(d => d.Conteudo, s => s.MapFrom(m => m.Conteudo))
                .ForMember(d => d.Concluido, s => s.MapFrom(m => m.Concluido))
                .ForAllOtherMembers(d => d.Ignore());

            CreateMap<TarefaModel, Tarefa>()
                .ForMember(d => d.Id, s => s.MapFrom(m => m.Id))
                .ForMember(d => d.Titulo, s => s.MapFrom(m => m.Titulo))
                .ForMember(d => d.Descricao, s => s.MapFrom(m => m.Descricao))
                .ForMember(d => d.Conteudo, s => s.MapFrom(m => m.Conteudo))
                .ForMember(d => d.Concluido, s => s.MapFrom(m => m.Concluido))
                .ForAllOtherMembers(d => d.Ignore());

        }
    }
}