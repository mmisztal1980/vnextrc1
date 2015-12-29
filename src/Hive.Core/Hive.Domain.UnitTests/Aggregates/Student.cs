using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Hive.Domain.UnitTests.Aggregates
{
    public class Student : Entity<int>, IAggregateRoot<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<StudentToClassRegistration> Registrations { get; } = new Collection<StudentToClassRegistration>();

        public override void Mutate(IDomainEvent @event)
        {
            (@event as IDomainEvent<Student>)?.Mutate(this);            
        }

        #region IDomainEvents

        public static IDomainEvent CompleteClass(int studentId, int classId, int grade)
        {
            return new CompleteClassCommand(studentId, classId, grade);
        }

        public static IDomainEvent RegisterForClass(int studentId, int classId)
        {
            return new RegisterForClassCommand(studentId, classId);
        }

        public class CompleteClassCommand : DomainCommand<CompleteClassCommand>, IDomainEvent<Student>
        {
            public CompleteClassCommand(int studenId, int classId, int grade)
            {
                StudentId = studenId;
                ClassId = classId;
                Grade = grade;
            }

            public int ClassId { get; }
            public int Grade { get; }
            public int StudentId { get; }

            public void Mutate(Student mutable)
            {
                Condition.ArgumentNotDefault(mutable, nameof(mutable));

                Condition.Require<InvalidOperationException>(StudentId.Equals(mutable.Id));
                Condition.Require<ArgumentException>(!ClassId.Equals(default(int)));

                mutable.Registrations.Single(r => r.ClassId.Equals(ClassId)).Grade = Grade;
            }
        }

        public class RegisterForClassCommand : DomainCommand<StudentToClassRegistration>, IDomainEvent<Student>
        {
            public RegisterForClassCommand(int studentId, int classId)
            {
                StudentId = studentId;
                ClassId = classId;
            }

            public int ClassId { get; }
            public int StudentId { get; }

            public void Mutate(Student mutable)
            {
                Condition.ArgumentNotDefault(mutable, nameof(mutable));

                Condition.Require<InvalidOperationException>(StudentId.Equals(mutable.Id));
                Condition.Require<ArgumentException>(!ClassId.Equals(default(int)));

                mutable.Registrations.Add(new StudentToClassRegistration()
                {
                    ClassId = ClassId,
                    StudentId = StudentId
                });
            }
        }

        #endregion
    }
}
