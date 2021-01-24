namespace TaskList.Infrastructure.CrossCutting.Validators.Interfaces
{
    public interface ISaveValidator<in TDomainModel> : IValidator<TDomainModel>
    {
    }
}