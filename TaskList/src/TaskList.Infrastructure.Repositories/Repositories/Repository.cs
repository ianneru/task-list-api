using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaskList.Infrastructure.Data;
using TaskList.Infrastructure.Repositories.Extensions;
using TaskList.Infrastructure.Repositories.Interfaces;

namespace TaskList.Infrastructure.Repositories
{
    public abstract class Repository<TDomainModel, TDomainId, TDbContext> :
       IRepository<TDomainModel, TDomainId>,
       IDisposable
       where TDomainModel : class,TDomainId
       where TDbContext : AppDbContext
    {
        private readonly TDbContext _context;

        private readonly DbSet<TDomainModel> _dbSet;
        private readonly IMapper _mapper;

        protected Repository(IMapper mapper, TDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TDomainModel>();
            _mapper = mapper;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async ValueTask<TDomainModel> AddAsync(TDomainModel domainModel)
        {
            var entity = await _dbSet.AddAsync(domainModel);

            return entity.Entity;
        }

        public Task AddRangeAsync(IEnumerable<TDomainModel> domainModels)
        {
            return _dbSet.AddRangeAsync(domainModels);
        }

        public async ValueTask<TDomainModel> GetByIdAsync(TDomainId id)
        {
            var query = _dbSet.AsNoTracking();

            var entity = await query.FirstOrDefaultAsync(BuildIdPredicate(id));

            return entity;
        }

        public async ValueTask<TDomainModel> Get(Expression<Func<TDomainModel, bool>> predicate)
        {
            var query = _dbSet.AsNoTracking();

            var entity = await query.FirstOrDefaultAsync(predicate);
            
            return _mapper.Map<TDomainModel>(entity);
        }

        public async ValueTask<int> Count(Expression<Func<TDomainModel, bool>> predicate)
        {
            var query = _dbSet.AsNoTracking();

            if (predicate != default)
                query = query.Where(predicate);

            return await query.CountAsync();
        }

        public async IAsyncEnumerable<TDomainModel> GetAllAsync()
        {
            var query = _dbSet.AsNoTracking();

            await foreach (var entity in query.AsAsyncEnumerable())
                yield return entity;
        }

        public async Task UpdateAsync(TDomainModel obj)
        {
            var ids = typeof(TDomainId).GetProperties()
                .ToDictionary(property => property.Name, property => property.GetValue(obj));
            
            var id = (TDomainId)ChangeType(ids, typeof(TDomainId));

            var avoidingAttachedEntity = await _dbSet.AsNoTracking().FirstOrDefaultAsync(BuildIdPredicate(id));

            _context.Entry(avoidingAttachedEntity).State = EntityState.Detached;

            var entry = _context.Entry(obj);
            
            if (entry.State == EntityState.Detached) _context.Attach(obj);

            _context.Entry(obj).State = EntityState.Modified;
        }

        public async Task RemoveAsync(TDomainId id)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null) return;

            await RemoveAsync(entity);
        }

        public Task RemoveAsync(TDomainModel obj)
        {
            return Task.FromResult(_dbSet.Remove(obj));
        }

        public Task UpdateRangeAsync(IEnumerable<TDomainModel> entities)
        {
            _dbSet.UpdateRange(entities);

            return Task.CompletedTask;
        }

        public Task RemoveRangeAsync(IEnumerable<TDomainModel> entities)
        {
            _dbSet.RemoveRange(entities);

            return Task.CompletedTask;
        }

        private Expression<Func<TDomainModel, bool>> BuildIdPredicate(TDomainId id)
        {
            Expression<Func<TDomainModel, bool>> predicate = default;

            foreach (var property in typeof(TDomainId).GetProperties())
            {
                var value = property.GetValue(id);
                
                var parameter = Expression.Parameter(typeof(TDomainModel), typeof(TDomainModel).Name);
                
                var memberExpression = Expression.Property(parameter, property.Name);
                
                value = ChangeType(value, memberExpression.Type);
                
                var condition = Expression.Equal(memberExpression,
                    Expression.Convert(Expression.Constant(value), memberExpression.Type));

                var lambda = Expression.Lambda<Func<TDomainModel, bool>>(condition, parameter);
                
                predicate = predicate?.AndAlso(lambda) ?? lambda;
            }

            return predicate;
        }

        private object ChangeType(object value, Type desiredType)
        {
            if (value != default)
                return _mapper.Map(value, value.GetType(), desiredType);

            if (desiredType.IsGenericType && desiredType.GetGenericTypeDefinition() == typeof(Nullable<>))
                return default;

            return desiredType.IsValueType ? Activator.CreateInstance(desiredType) : default;
        }


  
    }
}
