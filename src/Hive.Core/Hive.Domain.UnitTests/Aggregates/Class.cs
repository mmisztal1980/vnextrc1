using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Hive.Domain.UnitTests.Aggregates
{
    public class Class : Entity<int>
    {
        public Class()
        {
            Registrations = new Collection<StudentToClassRegistration>();
        }

        public string Name { get; set; }
        public virtual ICollection<StudentToClassRegistration> Registrations { get; private set; }

        public override void Mutate(IDomainEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}