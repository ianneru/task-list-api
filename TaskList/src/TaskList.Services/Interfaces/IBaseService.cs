using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TaskList.Services.Interfaces
{
    public interface IBaseService<TDomainModel,TModel,in TDomainId>  
        where TDomainModel : TDomainId
        where TModel : class
    {
        // Read methods
        ValueTask<TDomainModel> GetByIdAsync(TDomainId id);
        IAsyncEnumerable<TDomainModel> GetAllAsync();
        ValueTask<TDomainModel> Get(Expression<Func<TModel, bool>> predicate);
        ValueTask<int> Count(Expression<Func<TModel, bool>> predicate = default);

        //Write methods
        ValueTask<TDomainModel> AddAsync(TModel domainModel);
        Task AddRangeAsync(IEnumerable<TModel> domainModels);
        Task UpdateAsync(TModel obj);
        Task RemoveAsync(TDomainId id);
        Task RemoveAsync(TModel obj);
    }
}