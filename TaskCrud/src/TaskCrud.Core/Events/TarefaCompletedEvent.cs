using TaskList.Core.Entities;
using TaskList.SharedKernel;

namespace TaskList.Core.Events
{
    public class TarefaCompletedEvent : BaseDomainEvent
    {
        public Tarefa TarefaConcluida { get; set; }

        public TarefaCompletedEvent(Tarefa tarefaConcluida)
        {
            TarefaConcluida = tarefaConcluida;
        }
    }
}