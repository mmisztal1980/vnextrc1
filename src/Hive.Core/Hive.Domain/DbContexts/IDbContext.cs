using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace Hive.Domain.DbContexts
{
    public interface IDbContext : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        DbSet<TEntity> Set<TEntity>() where TEntity : class, IMutable;
        void SetEntityState<TEntity>(TEntity entity, EntityState state) where TEntity : class, IMutable;
    }

    public interface IDbContext<TDataStore>
        where TDataStore : class, IDataStore, new()
    {}
}