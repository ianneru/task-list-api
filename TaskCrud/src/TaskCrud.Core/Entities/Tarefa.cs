using System;
using TaskList.Core.Events;
using TaskList.Core.Interfaces;
using TaskList.SharedKernel;

namespace TaskList.Core.Entities
{
    public class Tarefa : BaseEntity
    {
        public string Titulo { get; set; } = string.Empty;

        public string Descricao { get; set; }
        
        public bool Concluido { get; private set; }

        public DateTime DataConclusao { get; set; }

        public string Conteudo { get; set; }

        public void MarkComplete()
        {
            Concluido = true;

            Events.Add(new TarefaCompletedEvent(this));
        }

        public override string ToString()
        {
            string status = Concluido ? "Tarefa concluída!" : "Tarefa não concluída.";

            return $"{Id}: Status: {status} - {Titulo} - {Descricao} - {Conteudo}";
        }
    }
}
