using System;
using TaskList.SharedKernel;

namespace TaskList.Domain.ViewModels
{
    public class TarefaModel : BaseModel<Guid>
    {
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public bool Concluido { get; private set; }

        public DateTime DataConclusao { get; set; }

        public string Conteudo { get; set; }
    }
}
