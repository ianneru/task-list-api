using System.Threading.Tasks;
using TaskList.SharedKernel;

namespace TaskList.SharedKernel.Interfaces
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(BaseDomainEvent domainEvent);
    }
}