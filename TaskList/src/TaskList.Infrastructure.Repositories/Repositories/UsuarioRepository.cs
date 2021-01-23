using AutoMapper;
using System;
using TaskList.Domain.Entities;
using TaskList.Domain.ViewModels;
using TaskList.Infrastructure.Data;
using TaskList.Infrastructure.Repositories.Interfaces;
using TaskList.SharedKernel;

namespace TaskList.Infrastructure.Repositories.Repositories
{
    public class UsuarioRepository : Repository<Usuario, BaseEntity<Guid>, AppDbContext>, IUsarioRepository
    {
        public UsuarioRepository(IMapper mapper, AppDbContext context) : base(mapper, context)
        {
        }
    }
}