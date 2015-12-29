namespace Hive.Domain
{
    /// <summary>
    /// An entity implementing IMutable should only change it's state in response to a IDomainEvent
    /// </summary>
    public interface IMutable
    {
        void Mutate(IDomainEvent @event);
    }
}