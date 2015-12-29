using System;
using System.ComponentModel.DataAnnotations;

namespace Hive.Domain
{
    public abstract class Entity<TId> : IEntity<TId>
        where TId : IComparable
    {
        protected Entity()
        {
            CreatedDateUtc = DateTime.UtcNow;
        }

        public DateTimeOffset CreatedDateUtc { get; set; }

        [Key]
        public TId Id { get; set; }

        public DateTimeOffset ModifiedDateUtc { get; set; }

        public abstract void Mutate(IDomainEvent @event);
    }
}