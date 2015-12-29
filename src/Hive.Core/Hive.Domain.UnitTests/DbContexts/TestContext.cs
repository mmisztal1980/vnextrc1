using Hive.Domain.UnitTests.Aggregates;
using Microsoft.Data.Entity;

namespace Hive.Domain.UnitTests.DbContexts
{
    public class TestContext
        //: DatabaseContext<InMemoryDataStore>
    {
        //public TestContext(DbConnection connection)
        //    : base(connection, true)
        //{
        //}

        //public TestContext(string nameOrConnectionString)
        //    : base(nameOrConnectionString)
        //{
        //}

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<StudentToClassRegistration> Registrations { get; set; }
        public virtual DbSet<Student> Students { get; set; }
    }
}