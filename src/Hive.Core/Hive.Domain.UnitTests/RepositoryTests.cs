namespace Hive.Domain.UnitTests
{
    //public class RepositoryTests : DbTestFixture<TestContext, TestContextMigrationsConfiguration>
    //{
    //    public RepositoryTests()
    //        : base(Effort.DbConnectionFactory.CreateTransient())
    //    {
    //        Context.ShouldNotBeNull();            
    //    }

    //    [Fact]
    //    public async void Count_Default_CountEqualToAmountOfSeededEntities()
    //    {
    //        // Arrange
    //        var respository = new StudentRepository(Context);

    //        // Act
    //        var result = await respository.Count();

    //        // Assert
    //        result.ShouldEqual(4);
    //    }

    //    [Fact]
    //    public async void Count_Predicate_CountEqualToAmountOfSeededEntities()
    //    {
    //        // Arrange
    //        var respository = new StudentRepository(Context);

    //        // Act
    //        var result = await respository.Count(x => true);

    //        // Assert
    //        result.ShouldEqual(4);
    //    }

    //    [Fact]
    //    public async void Get_Predicate_AllEntitiesMatchingPredicate()
    //    {
    //        // Arrange
    //        var respository = new StudentRepository(Context);

    //        // Act
    //        var result = await respository.Get(x => x.LastName.Equals("Doe"));

    //        // Assert
    //        result.Count().ShouldEqual(2);
    //    }
    //}
}
