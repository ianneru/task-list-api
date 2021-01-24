using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskList.Infrastructure.Data;
using TaskList.Infrastructure.Repositories.Interfaces;

namespace TaskList.Infrastructure.Repositories.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        
        public ITarefaRepository TarefaRepository { get; }

        public IUsarioRepository UsuarioRepository { get; }

        public UnitOfWork(AppDbContext context,
            IServiceProvider serviceProvider)
        {
            _context = context;
            
            TarefaRepository = serviceProvider.GetRequiredService<ITarefaRepository>();

            UsuarioRepository = serviceProvider.GetRequiredService<IUsarioRepository>();
        }
        
        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void RejectChanges()
        {
            foreach (var entry in _context.ChangeTracker.Entries().Where(e => e.State != EntityState.Unchanged))
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}