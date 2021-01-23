namespace TaskList.Infrastructure.CrossCutting.Validators.Interfaces
{
    public interface IUpdateValidator<in TDomainModel> : IValidator<TDomainModel>
    {
    }
}