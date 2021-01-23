namespace TaskList.Infrastructure.CrossCutting.Validators.Interfaces
{
    public interface IDeleteValidator<in TDomainModel> : IValidator<TDomainModel>
    {
    }
}