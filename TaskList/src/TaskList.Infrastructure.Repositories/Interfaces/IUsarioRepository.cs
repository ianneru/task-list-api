using System;
using TaskList.Domain.Entities;
using TaskList.Domain.ViewModels;
using TaskList.SharedKernel;

namespace TaskList.Infrastructure.Repositories.Interfaces
{
    public interface IUsarioRepository : IRepository<Usuario, BaseEntity<Guid>>
    {
    }
}