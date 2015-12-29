using System;

namespace Hive.Domain
{
    public interface ISoftDeletableEntity<TId> : IEntity<TId>
        where TId : IComparable
    {
        bool IsDeleted { get; }

        DateTimeOffset DeletedDateUtc { get; }
    }
}