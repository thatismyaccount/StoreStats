namespace StoreStatsApi.Data.Migrations
{
    using StoreStats.Data.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StoreStatsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StoreStatsDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Stores.AddOrUpdate(new[]
            {
                new Store { Id = 1, Name = "Store #1", City = "Castle Douglas", Country = "Scotland" },
                new Store { Id = 2, Name = "Store #2", City = "Newton Stewart", Country = "Scotland" },
                new Store { Id = 3, Name = "Store #3", City = "Lockerbie", Country = "Scotland" },
                new Store { Id = 4, Name = "Store #4", City = "Bydgosz", Country = "Poland" }
            });
        }
    }
}
