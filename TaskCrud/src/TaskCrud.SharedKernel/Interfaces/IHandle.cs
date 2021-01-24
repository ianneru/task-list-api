using System.Threading.Tasks;
using TaskList.SharedKernel;

namespace TaskList.SharedKernel.Interfaces
{
    public interface IHandle<in T> where T : BaseDomainEvent
    {
        Task Handle(T domainEvent);
    }
}