using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TaskList.Infrastructure.Repositories.Interfaces
{
    public interface IRepository<TDomainModel,in TId> where TDomainModel : TId
    {
        // Read methods
        ValueTask<TDomainModel> GetByIdAsync(TId id);
        IAsyncEnumerable<TDomainModel> GetAllAsync();
        ValueTask<TDomainModel> Get(Expression<Func<TDomainModel, bool>> predicate);
        ValueTask<int> Count(Expression<Func<TDomainModel, bool>> predicate = default);


        //Write methods
        ValueTask<TDomainModel> AddAsync(TDomainModel domainModel);
        Task AddRangeAsync(IEnumerable<TDomainModel> domainModels);
        Task UpdateAsync(TDomainModel obj);
        Task RemoveAsync(TId id);
        Task RemoveAsync(TDomainModel obj);
    }
}
