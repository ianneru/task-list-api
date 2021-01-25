using System;
using TaskList.SharedKernel;

namespace TaskList.Domain.Entities
{
    public class Tarefa : BaseEntity<Guid>
    {
        public Tarefa()
        {
            DataCriacao = DateTime.Now;
        }

        public string Titulo { get; set; } = string.Empty;

        public string Descricao { get; set; }

        public DateTime? DataConclusao { get; set; }

        public string Conteudo { get; set; }

        public override string ToString()
        {
            string status = DataConclusao.HasValue ? "Tarefa concluída!" : "Tarefa não concluída.";

            return $"{Id}: Status: {status} - {Titulo} - {Descricao} - {Conteudo}";
        }
    }
}
