using TaskList.Infrastructure.CrossCutting.Validators.Interfaces;

namespace TaskList.Services.Interfaces
{
    public interface IServiceValidator<TDomainModel>
    {
        ISaveValidator<TDomainModel> Save { get; set; }

        IUpdateValidator<TDomainModel> Update { get; set; }

        IDeleteValidator<TDomainModel> Delete { get; set; }
    }
}