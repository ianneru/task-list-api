using Ardalis.GuardClauses;
using System.Threading.Tasks;
using TaskList.Core.Events;
using TaskList.Core.Interfaces;
using TaskList.SharedKernel.Interfaces;

namespace TaskList.Core.Services
{
    public class ItemCompletedEmailNotificationHandler : IHandle<TarefaCompletedEvent>
    {
        private readonly IEmailSender _emailSender;

        public ItemCompletedEmailNotificationHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        // configure a test email server to demo this works
        // https://ardalis.com/configuring-a-local-test-email-server
        public async Task Handle(TarefaCompletedEvent domainEvent)
        {
            Guard.Against.Null(domainEvent, nameof(domainEvent));

            await _emailSender.SendEmailAsync("test@test.com", "test@test.com", $"{domainEvent.TarefaConcluida.Titulo} was completed.", domainEvent.TarefaConcluida.ToString());
        }
    }
}
