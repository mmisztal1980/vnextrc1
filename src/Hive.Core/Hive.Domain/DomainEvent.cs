using System;

namespace Hive.Domain
{
    /// <summary>
    /// Base DomainEvent.
    /// Ensures that the TimeStamp & CorrelationId are always set.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class DomainEvent<T> : IDomainEvent
        where T : class
    {
        protected DomainEvent()
            : this(Guid.NewGuid())
        {
        }

        protected DomainEvent(Guid correlationId)
        {
            TimeStamp = DateTime.UtcNow;
            CorrelationId = correlationId;
        }

        public Guid CorrelationId { get; }
        public DateTimeOffset TimeStamp { get; }
    }
}