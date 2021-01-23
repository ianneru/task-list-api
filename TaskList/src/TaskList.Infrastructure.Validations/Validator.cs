using FluentValidation;

namespace TaskList.Infrastructure.CrossCutting.Validators
{
    public abstract class Validator<TDomainModel> : AbstractValidator<TDomainModel>
    {
        public new void Validate(TDomainModel domainModel)
        {
            var result = base.Validate(domainModel);

            if (result.IsValid)
                return;

            throw new ValidationException(result.Errors);
        }
    }
}