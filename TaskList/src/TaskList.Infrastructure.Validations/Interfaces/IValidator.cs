namespace TaskList.Infrastructure.CrossCutting.Validators.Interfaces
{
    public interface IValidator<in TDomainModel>
    {
        void Validate(TDomainModel domainModel);
    }
}