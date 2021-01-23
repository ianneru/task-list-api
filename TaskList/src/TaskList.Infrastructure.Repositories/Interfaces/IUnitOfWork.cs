using System.Threading.Tasks;

namespace TaskList.Infrastructure.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        ITarefaRepository TarefaRepository { get; }
        IUsarioRepository UsuarioRepository { get; }
        
        Task<int> CommitAsync();

        void RejectChanges();

        void Dispose();
    }
}