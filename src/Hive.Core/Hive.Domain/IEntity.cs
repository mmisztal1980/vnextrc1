using System;

namespace Hive.Domain
{
    /// <summary>
    /// Entity is identified by it's Id and tracks it's creation date.
    /// Additionally the entity is mutable via it's IMutable interface.
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public interface IEntity<TId> : IMutable
        where TId : IComparable
    {
        TId Id { get; }

        DateTimeOffset CreatedDateUtc { get; }

        DateTimeOffset ModifiedDateUtc { get; }
    }
}