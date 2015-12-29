using Microsoft.Data.Entity;

namespace Hive.Domain.DbContexts
{
    /// <summary>
    /// Configures the IDbContext to use the in-memory provider
    /// </summary>
    public class InMemoryDataStore : IDataStore
    {
        public void Configure(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase();
        }
    }
}
