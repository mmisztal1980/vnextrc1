using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Hive.Domain.Aggregates;
using Hive.Domain.DbContexts;
using Microsoft.Data.Entity;

namespace Hive.Domain.Repositories
{
    public abstract class Repository<TAggregate, TId> : Disposable, IRepository<TAggregate, TId>
        where TAggregate : class, IAggregateRoot<TId>
        where TId : IComparable
    {
        private readonly bool repositoryOwnsContext;

        protected Repository(IDbContext context)
            : this(context, true)
        {
        }

        protected Repository(IDbContext context, bool repositoryOwnsContext)
        {
            Condition.ArgumentNotNull(context, nameof(context));

            Context = context;
            DbSet = Context.Set<TAggregate>();

            this.repositoryOwnsContext = repositoryOwnsContext;
        }

        protected IDbContext Context { get; }
        protected DbSet<TAggregate> DbSet { get; }

        public async Task<int> Count()
        {
            return await DbSet.CountAsync();
        }

        public async Task<int> Count(Expression<Func<TAggregate, bool>> predicate)
        {
            Condition.ArgumentNotNull(predicate, nameof(predicate));

            return await DbSet.CountAsync(predicate);
        }

        public async Task<TId> Delete(TId id)
        {
            var entityToDelete = DbSet.Find(id);

            return await Delete(entityToDelete);
        }

        public async Task<TId> Delete(TAggregate aggregate)
        {
            var id = aggregate.Id;

            DbSet.Remove(aggregate);
            await Context.SaveChangesAsync();

            return id;
        }

        public async Task<TAggregate[]> Get(Expression<Func<TAggregate, bool>> predicate, params Expression<Func<TAggregate, object>>[] includeProperties)
        {
            Condition.ArgumentNotNull(predicate, nameof(predicate));

            var query = DbSet.Where(predicate);

            includeProperties?.ForEach(x => query.Include(x));

            return await query.ToArrayAsync();
        }

        public async Task<TAggregate[]> Get(Expression<Func<TAggregate, bool>> predicate, Expression<Func<TAggregate, object>> orderBySelector, params Expression<Func<TAggregate, object>>[] includeProperties)
        {
            Condition.ArgumentNotNull(predicate, nameof(predicate));
            Condition.ArgumentNotNull(orderBySelector, nameof(orderBySelector));

            var query = DbSet.Where(predicate)
                .OrderBy(orderBySelector);

            includeProperties?.ForEach(x => query.Include(x));

            return await query.ToArrayAsync();
        }

        public async Task<TAggregate[]> Get(Expression<Func<TAggregate, bool>> predicate, int skip, int take, params Expression<Func<TAggregate, object>>[] includeProperties)
        {
            Condition.ArgumentNotNull(predicate, nameof(predicate));
            Condition.Require<ArgumentException>(skip >= 0, "skip must be greater or equal 0");
            Condition.Require<ArgumentException>(take > 0, "take must be greater then 0");

            var query = DbSet.Where(predicate)
                .Skip(skip)
                .Take(take);

            includeProperties?.ForEach(x => query.Include(x));

            return await query.ToArrayAsync();
        }

        public async Task<TAggregate> Insert(TAggregate aggregate)
        {
            DbSet.Add(aggregate);

            await Context.SaveChangesAsync();

            return aggregate;
        }

        public async Task<TAggregate> Single(TId id)
        {
            return await Task.FromResult(DbSet.Find(id));
        }

        public async Task<TAggregate> Single(Expression<Func<TAggregate, bool>> predicate)
        {
            Condition.ArgumentNotNull(predicate, nameof(predicate));

            return await DbSet.SingleAsync(predicate);
        }

        public async Task<TAggregate> Update(TAggregate aggregate)
        {
            var result = DbSet.Find(aggregate.Id);

            result?.Execute(() => Context.SetEntityState(result, EntityState.Detached));

            Context.SetEntityState(aggregate, EntityState.Modified);

            await Context.SaveChangesAsync();

            return aggregate;
        }

        ~Repository()
        {
            Dispose(false);
        }

        public async Task<TAggregate[]> Get(Expression<Func<TAggregate, bool>> predicate, Expression<Func<TAggregate, object>> orderBySelector, int skip, int take, params Expression<Func<TAggregate, object>>[] includeProperties)
        {
            Condition.ArgumentNotNull(predicate, nameof(predicate));
            Condition.ArgumentNotNull(orderBySelector, nameof(orderBySelector));
            Condition.Require<ArgumentException>(skip >= 0, "skip must be greater or equal 0");
            Condition.Require<ArgumentException>(take > 0, "take must be greater then 0");

            var query = DbSet.Where(predicate)
                .OrderBy(orderBySelector)
                .Skip(skip)
                .Take(take);

            includeProperties?.ForEach(x => query.Include(x));

            return await query.ToArrayAsync();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if(repositoryOwnsContext) Context.Dispose();
            }
        }
    }
}