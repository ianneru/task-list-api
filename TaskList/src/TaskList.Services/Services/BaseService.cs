using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaskList.Infrastructure.Repositories.Interfaces;
using TaskList.Services.Interfaces;

namespace TaskList.Services.Services
{
    public abstract class BaseService<TDomainModel,TModel,TDomainId> : IBaseService<TDomainModel,TModel,TDomainId>
        where TDomainModel : class, TDomainId
        where TModel : class
    {
        private readonly IMapper _mapper;
        protected readonly IRepository<TDomainModel, TDomainId> Repository;

        protected readonly IServiceValidator<TDomainModel> Validator;

        protected BaseService(IMapper mapper,
            IRepository<TDomainModel, TDomainId> repository,
            IServiceValidator<TDomainModel> validator)
        {
            this._mapper = mapper;
            Repository = repository;
            Validator = validator;
        }

        public async ValueTask<TDomainModel> AddAsync(TModel model)
        {
            var domainModel = _mapper.Map<TDomainModel>(model);
            
            Validator.Save?.Validate(domainModel);

            return await Repository.AddAsync(domainModel);
        }

        public async Task AddRangeAsync(IEnumerable<TModel> models)
        {
            foreach (var model in models) 
            {
                var domainModel = _mapper.Map<TDomainModel>(model);
                Validator.Save?.Validate(domainModel);
            }

            var domainModels = _mapper.Map<IEnumerable<TDomainModel>>(models);

            await Repository.AddRangeAsync(domainModels);
        }

        public ValueTask<TDomainModel> GetByIdAsync(TDomainId id)
        {
            return Repository.GetByIdAsync(id);
        }

        public IAsyncEnumerable<TDomainModel> GetAllAsync()
        {
            return Repository.GetAllAsync();
        }

        public ValueTask<TDomainModel> Get(Expression<Func<TModel, bool>> predicate)
        {
            var pr = _mapper.Map<Expression<Func<TDomainModel, bool>>>(predicate);

            return Repository.Get(pr);
        }

        public ValueTask<int> Count(Expression<Func<TModel, bool>> predicate = default)
        {
            var pr = _mapper.Map<Expression<Func<TDomainModel, bool>>>(predicate);

            return Repository.Count(pr);
        }

        public async Task UpdateAsync(TModel model)
        {
            var domainModel = _mapper.Map<TDomainModel>(model);

            Validator.Update?.Validate(domainModel);

            await Repository.UpdateAsync(domainModel);
        }

        public async Task RemoveAsync(TDomainId id)
        {
            var entity = await GetByIdAsync(id);

            await RemoveAsync(entity);
        }

        public async Task RemoveAsync(TModel model)
        {
            var domainModel = _mapper.Map<TDomainModel>(model);

            Validator.Delete?.Validate(domainModel);

            await Repository.RemoveAsync(domainModel);
        }
    }
}