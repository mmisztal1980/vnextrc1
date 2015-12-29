using System;

namespace Hive.Domain
{
    /// <summary>
    /// Base DomainCommand.
    /// Ensures that the TimeStamp & CorrelationId are always set.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class DomainCommand<T> : IDomainEvent
        where T : class
    {
        protected DomainCommand()
            : this(Guid.NewGuid())
        {
        }

        protected DomainCommand(Guid correlationId)
        {
            TimeStamp = DateTime.UtcNow;
            CorrelationId = correlationId;
        }

        public Guid CorrelationId { get; private set; }

        public DateTimeOffset TimeStamp { get; private set; }
    }
}