using System;

namespace Hive.Domain.Aggregates
{
    /// <summary>
    /// Some of the entities in the domain are aggregate roots.
    /// The aggregate roots are the only entities accessible via the repositories
    /// </summary>
    public interface IAggregateRoot<TId> : IEntity<TId>
    where TId : IComparable
    {
    }
}