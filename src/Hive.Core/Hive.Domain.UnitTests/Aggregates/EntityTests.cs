using System;
using Hive.Domain.UnitTests.DbContexts;
using Xunit;

namespace Hive.Domain.UnitTests.Aggregates
{
    /// <summary>
    /// These tests verify that Entities are mutable thanks to <see cref="IMutable"/>,
    /// using <see cref="IDomainEvent"/>. The IDomainEvents are the constructs responsible 
    /// for mutating an IMutable entity in the end. 
    /// The IDomainEvents can be a part of the anticorruption layer as demonstrated inside some of the test cases.
    /// </summary>
    //public class EntityTests : DbTestFixture<TestContext, TestContextMigrationsConfiguration>
    //{
    //    public EntityTests()
    //        //: base(Effort.DbConnectionFactory.CreateTransient())
    //    {
    //        //Context.ShouldNotBeNull();            
    //    }

    //    [Fact]
    //    public void Mutate_IDomainEvents_EntityMutated()
    //    {
    //        // Arrange
    //        var grade = 5;
    //        var student = Context.Students.Single(x => x.FirstName.Equals("John"));
    //        var @class = Context.Classes.Single(x => x.Name.Equals("Calculus"));

    //        // Act
    //        student.Mutate(Student.RegisterForClass(student.Id, @class.Id));
    //        student.Mutate(Student.CompleteClass(student.Id, @class.Id, grade));

    //        Context.SaveChanges();

    //        // Assert
    //        student.Registrations.Count.ShouldEqual(1);
    //        student.Registrations.First().Grade.ShouldEqual(grade);
    //    }

    //    [Fact]
    //    public void Mutate_IDomainEventWithInvalidStudentId_InvalidOperationException()
    //    {
    //        Assert.Throws<InvalidOperationException>(() =>
    //        {
    //            // Arrange
    //            var student = Context.Students.Single(x => x.FirstName.Equals("John"));
    //            var @class = Context.Classes.Single(x => x.Name.Equals("Calculus"));

    //            // Act
    //            student.Mutate(new Student.RegisterForClassCommand(234, @class.Id));
    //        });
    //    }

    //    [Fact]
    //    public void Mutate_IDomainEventDefaultClassId_ArgumentException()
    //    {
    //        Assert.Throws<ArgumentException>(() =>
    //        {
    //            // Arrange
    //            var student = Context.Students.Single(x => x.FirstName.Equals("John"));

    //            // Act
    //            student.Mutate(new Student.RegisterForClassCommand(student.Id, default(int)));
    //        });
    //    }
    //}
}