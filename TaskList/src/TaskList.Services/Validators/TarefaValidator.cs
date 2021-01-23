using FluentValidation;
using TaskList.Domain.Entities;
using TaskList.Infrastructure.CrossCutting.Validators;
using TaskList.Infrastructure.CrossCutting.Validators.Interfaces;

namespace TaskList.Services.Validators
{
    public class TarefaValidator : Validator<Tarefa>,
        ISaveValidator<Tarefa>,
        IUpdateValidator<Tarefa>
    {
        public TarefaValidator()
        {
            RuleFor(x => x.Id).NotNull();
            
            RuleFor(x => x.Titulo)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);
            
            RuleFor(x => x.Descricao)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.DataCriacao)
                .NotNull();
        }
    }
}