namespace Hive.Domain.UnitTests.Aggregates
{
    public class StudentToClassRegistration : Entity<int>
    {
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public int Grade { get; set; }

        public override void Mutate(IDomainEvent @event)
        {
            throw new System.NotImplementedException();
        }
    }
}