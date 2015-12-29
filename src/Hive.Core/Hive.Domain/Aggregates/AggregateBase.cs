using System;
using System.Collections.Generic;
using Hive.Domain.Repositories;

namespace Hive.Domain.Aggregates
{
    /// <summary>
    /// The Aggregate base
    /// </summary>
    /// <typeparam name="TAggregate">The type of the AggregateRoot held and mutated by the Aggregate</typeparam>
    /// <typeparam name="TId">The type of the AggregateRoot's identity</typeparam>
    public abstract class Aggregate<TAggregate, TId> : Disposable, IAggregate<TAggregate, TId>
        where TAggregate : class, IAggregateRoot<TId>, new()
        where TId : IComparable
    {
        private readonly IList<IDomainEvent> changes = new List<IDomainEvent>();
        private readonly IRepository<TAggregate, TId> repository;

        /// <summary>
        /// Load an existing aggregateRoot using the provided Id
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="id"></param>
        protected Aggregate(IRepository<TAggregate, TId> repository, TId id)
            : this(repository, false)
        {
            Condition.ArgumentNotDefault(id, nameof(id));

            State = repository.Single(id).Result;
        }

        /// <summary>
        /// Load an aggregate and create a new aggregate root
        /// </summary>
        /// <param name="repository"></param>
        protected Aggregate(IRepository<TAggregate, TId> repository)
            : this(repository, true)
        {
        }

        private Aggregate(IRepository<TAggregate, TId> repository, bool createNew)
        {
            Condition.ArgumentNotNull(repository, nameof(repository));

            this.repository = repository;

            State = createNew ? new TAggregate() : State;
        }

        protected TAggregate State { get; }
        protected abstract string LoggerName { get; }
        public IEnumerable<IDomainEvent> Changes => changes;

        public void Apply(IDomainEvent @event)
        {
            State.Mutate(@event);

            changes.Add(@event);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                changes.Clear();
            }
        }
    }
}