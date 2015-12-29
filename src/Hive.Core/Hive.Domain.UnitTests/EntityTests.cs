using System;
using Hive.Domain.UnitTests.Aggregates;
using Xunit;

namespace Hive.Domain.UnitTests
{
    public class EntityTests
    {
        [Fact]
        public void Ctor_Default_CreatedDateIsSet()
        {
            var nowUtc = DateTime.UtcNow;

            var student = new Student();

            Assert.True((student.CreatedDateUtc - nowUtc).TotalSeconds < 1);
        }

        [Fact]
        public void Ctor_Default_IdIsDefault()
        {
            var student = new Student();

            Assert.True(student.Id.Equals(default(int)));
        }
    }
}