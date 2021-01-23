using AutoMapper;
using System;
using TaskList.Domain.Entities;
using TaskList.Infrastructure.Data;
using TaskList.Infrastructure.Repositories.Interfaces;
using TaskList.SharedKernel;

namespace TaskList.Infrastructure.Repositories.Repositories
{
    public class TarefaRepository : Repository<Tarefa, BaseEntity<Guid>, AppDbContext>, ITarefaRepository
    {
        public TarefaRepository(IMapper mapper, AppDbContext context) 
            : base(mapper, context)
        {
        }
    }
}
