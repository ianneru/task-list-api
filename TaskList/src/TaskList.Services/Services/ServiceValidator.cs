using Microsoft.Extensions.DependencyInjection;
using System;
using TaskList.Infrastructure.CrossCutting.Validators.Interfaces;
using TaskList.Services.Interfaces;

namespace TaskList.Services.Services
{
    public class ServiceValidator<TDomainModel> : IServiceValidator<TDomainModel>
    {
        public ServiceValidator(IServiceProvider serviceProvider)
        {
            Save = serviceProvider.GetService<ISaveValidator<TDomainModel>>();
            Update = serviceProvider.GetService<IUpdateValidator<TDomainModel>>();
            Delete = serviceProvider.GetService<IDeleteValidator<TDomainModel>>();
        }

        public ISaveValidator<TDomainModel> Save { get; set; }

        public IUpdateValidator<TDomainModel> Update { get; set; }

        public IDeleteValidator<TDomainModel> Delete { get; set; }
    }
}