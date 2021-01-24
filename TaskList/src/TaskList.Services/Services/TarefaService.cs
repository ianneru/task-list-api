using AutoMapper;
using System;
using TaskList.Domain.Entities;
using TaskList.Domain.ViewModels;
using TaskList.Infrastructure.Repositories.Interfaces;
using TaskList.Services.Interfaces;
using TaskList.SharedKernel;

namespace TaskList.Services.Services
{
    public class TarefaService : BaseService<Tarefa, TarefaModel, BaseEntity<Guid>>, ITarefaService
    {
        public TarefaService(IMapper mapper,IUnitOfWork unitOfWork,
            IServiceValidator<Tarefa> validator) : base(
            mapper,
            unitOfWork.TarefaRepository,
            validator)
        {
        }
    }
}