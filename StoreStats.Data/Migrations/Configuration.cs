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

            context.Entries.AddOrUpdate(new[]
            {
                new Entry { Id = 1, StoreId = 1, EntryDate = new DateTime(2023,03,10,11,20,59) },
                new Entry { Id = 2, StoreId = 1, EntryDate = new DateTime(2023,03,10,11,15,05) },
                new Entry { Id = 3, StoreId = 4, EntryDate = new DateTime(2023,03,10,08,15,23) },
                new Entry { Id = 4, StoreId = 4, EntryDate = new DateTime(2023,03,09,08,20,59) },
                new Entry { Id = 5, StoreId = 4, EntryDate = new DateTime(2023,03,09,11,20,59) },
                new Entry { Id = 6, StoreId = 4, EntryDate = new DateTime(2023,03,09,11,20,59) },
                new Entry { Id = 7, StoreId = 4, EntryDate = new DateTime(2023,03,08,11,20,59) },
                new Entry { Id = 8, StoreId = 4, EntryDate = new DateTime(2023,03,07,11,20,59) },
                new Entry { Id = 9, StoreId = 4, EntryDate = new DateTime(2023,03,10,11,20,59) },
            });
        }
    }
}
