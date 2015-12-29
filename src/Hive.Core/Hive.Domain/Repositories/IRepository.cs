using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Hive.Domain.Aggregates;

namespace Hive.Domain.Repositories
{
    public interface IRepository<TAggregate, TId> : IDisposable
        where TAggregate : class, IAggregateRoot<TId>
        where TId : IComparable
    {
        Task<int> Count();
        Task<int> Count(Expression<Func<TAggregate, bool>> predicate);
        Task<TAggregate> Insert(TAggregate aggregate);
        Task<TAggregate> Single(TId id);
        Task<TAggregate> Single(Expression<Func<TAggregate, bool>> predicate);
        Task<TAggregate[]> Get(Expression<Func<TAggregate, bool>> predicate, params Expression<Func<TAggregate, object>>[] includeProperties);
        Task<TAggregate[]> Get(Expression<Func<TAggregate, bool>> predicate, Expression<Func<TAggregate, object>> orderBySelector, params Expression<Func<TAggregate, object>>[] includeProperties);
        Task<TAggregate[]> Get(Expression<Func<TAggregate, bool>> predicate, int skip, int take, params Expression<Func<TAggregate, object>>[] includeProperties);
        Task<TAggregate> Update(TAggregate aggregate);
        Task<TId> Delete(TId id);
        Task<TId> Delete(TAggregate aggregate);
    }
}