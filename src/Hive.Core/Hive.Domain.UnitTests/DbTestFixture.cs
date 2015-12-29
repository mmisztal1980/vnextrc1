using System;

namespace Hive.Domain.UnitTests
{
    public abstract class DbTestFixture<TContext, TMigrationConfiguration> : IDisposable
        //where TContext : DbContext, IDbContext
        //where TMigrationConfiguration : DbMigrationsConfiguration<TContext>, IDbMigrationConfiguration<TContext>, new()
    {
        static DbTestFixture()
        {
            //Effort.Provider.EffortProviderConfiguration.RegisterProvider();
            //Database.SetInitializer<TContext>(new CreateDatabaseIfNotExists<TContext>());
        }

        protected DbTestFixture(string connectionStringName, TContext context)
        {
            Context = context;
            //var migrator = new DbMigrator(new TMigrationConfiguration());
            //
            //// downgrade
            //migrator.Update("0");
            //
            //// update to latest
            //migrator.Update();
            //
            //Context = (TContext)Activator.CreateInstance(typeof(TContext), connectionStringName);
        }

        //protected DbTestFixture(DbConnection dbConnection, TContext context)
        //{
        //    Context = context;
        //    //Context = (TContext)Activator.CreateInstance(typeof(TContext), dbConnection);
        //    //TMigrationConfiguration migrationConfiguration = new TMigrationConfiguration();
        //    //migrationConfiguration.Seed(Context);
        //}

        protected TContext Context { get; private set; }

        public void Dispose()
        {
            //Context.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}