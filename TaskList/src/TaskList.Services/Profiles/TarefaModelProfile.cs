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
                .ForMember(d => d.DataConclusao, s => s.MapFrom(m => m.DataConclusao))
                .ForMember(d => d.DataRemocao, s => s.MapFrom(m => m.DataRemocao))
                .ForMember(d => d.DataEdicao, s => s.MapFrom(m => m.DataEdicao))
                .ForMember(d => d.DataCriacao, s => s.MapFrom(m => m.DataCriacao))
                .ForAllOtherMembers(d => d.Ignore());

            CreateMap<TarefaModel, Tarefa>()
                .ForMember(d => d.Id, s => s.MapFrom(m => m.Id))
                .ForMember(d => d.Titulo, s => s.MapFrom(m => m.Titulo))
                .ForMember(d => d.Descricao, s => s.MapFrom(m => m.Descricao))
                .ForMember(d => d.Conteudo, s => s.MapFrom(m => m.Conteudo))
                .ForMember(d => d.DataConclusao, s => s.MapFrom(m => m.DataConclusao))
                .ForMember(d => d.DataEdicao, s => s.MapFrom(m => m.DataEdicao))
                .ForMember(d => d.DataRemocao, s => s.MapFrom(m => m.DataRemocao))
                .ForMember(d => d.DataCriacao, s => s.MapFrom(m => m.DataCriacao))
                .ForAllOtherMembers(d => d.Ignore());

        }
    }
}