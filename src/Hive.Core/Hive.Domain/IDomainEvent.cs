using System;

namespace Hive.Domain
{
    /// <summary>
    /// Base DomainEvent interface, enforcing adoption of the CorrelationId as well as a timestamp of all events.
    /// </summary>
    public interface IDomainEvent
    {
        /// <summary>
        /// The CorrelationId of the event.
        /// </summary>
        Guid CorrelationId { get; }

        /// <summary>
        /// Utc occurence timestamp
        /// </summary>
        DateTimeOffset TimeStamp { get; }
    }

    /// <summary>
    /// DomainEvent with the ability to mutate a TMutable which implements an IMutable interface
    /// </summary>
    /// <typeparam name="TMutable"></typeparam>
    public interface IDomainEvent<in TMutable> : IDomainEvent
        where TMutable : class
    {
        /// <summary>
        /// Mutates the mutable. Provides a part of the anticorruption layer if applicable.
        /// </summary>
        /// <param name="mutable"></param>
        void Mutate(TMutable mutable);
    }
}