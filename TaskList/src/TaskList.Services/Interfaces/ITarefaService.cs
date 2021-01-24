using System;
using TaskList.Domain.Entities;
using TaskList.Domain.ViewModels;
using TaskList.SharedKernel;

namespace TaskList.Services.Interfaces
{
    public interface ITarefaService : IBaseService<Tarefa,TarefaModel, BaseEntity<Guid>>
    {

    }
}