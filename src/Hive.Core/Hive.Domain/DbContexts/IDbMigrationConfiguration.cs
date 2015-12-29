using Microsoft.Data.Entity;

namespace Hive.Domain.DbContexts
{
    public interface IDbMigrationConfiguration<TContext>
        where TContext : DbContext
    {
        void Seed(TContext context);
    }
}
