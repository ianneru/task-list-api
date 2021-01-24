using System;
using TaskList.Domain.Entities;
using TaskList.SharedKernel;

namespace TaskList.Infrastructure.Repositories.Interfaces
{
    public interface ITarefaRepository : IRepository<Tarefa, BaseEntity<Guid>>
    {

    }
}
