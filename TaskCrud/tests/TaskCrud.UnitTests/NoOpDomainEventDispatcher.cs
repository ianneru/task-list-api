using System.Threading.Tasks;
using TaskList.SharedKernel;
using TaskList.SharedKernel.Interfaces;

namespace TaskList.UnitTests
{
    public class NoOpDomainEventDispatcher : IDomainEventDispatcher
    {
        public Task Dispatch(BaseDomainEvent domainEvent)
        {
            return Task.CompletedTask;
        }
    }
}
