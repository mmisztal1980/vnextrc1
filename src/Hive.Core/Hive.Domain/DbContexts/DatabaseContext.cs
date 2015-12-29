using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;

namespace Hive.Domain.DbContexts
{
    public abstract class DatabaseContext<TDataStore> : DbContext, IDbContext<TDataStore>
        where TDataStore : class, IDataStore, new()
    {
        protected DatabaseContext()
            : base()
        { }

        protected DatabaseContext(DbContextOptions options)
            : base(options)
        {
            
        }

        public void SetEntityState<TEntity>(TEntity entity, EntityState state)
            where TEntity : class, IMutable
        {
            base.Entry(entity).State = state;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var store = new TDataStore();

            store.Configure(optionsBuilder);

            base.OnConfiguring(optionsBuilder);
        }
    }
}