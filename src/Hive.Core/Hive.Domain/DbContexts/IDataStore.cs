using Microsoft.Data.Entity;

namespace Hive.Domain.DbContexts
{
    public interface IDataStore
    {
        void Configure(DbContextOptionsBuilder optionsBuilder);
    }
}
