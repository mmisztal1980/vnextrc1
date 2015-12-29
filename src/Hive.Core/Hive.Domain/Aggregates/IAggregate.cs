using System;
using System.Collections.Generic;

namespace Hive.Domain.Aggregates
{
    public interface IAggregate<TAggregate, TId> : IDisposable
        where TAggregate : class, IAggregateRoot<TId>
        where TId : IComparable
    {
        IEnumerable<IDomainEvent> Changes { get; }

        void Apply(IDomainEvent @event);
    }
}