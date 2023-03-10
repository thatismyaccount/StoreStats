using StoreStats.Data.Models;
using System.Data.Entity;

namespace StoreStats.Data.Models
{
    public class StoreStatsDbContext : DbContext, IStoreStatsDbContext
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<Entry> Entries { get; set; }

        public StoreStatsDbContext() : base($"name={nameof(StoreStatsDbContext)}")
        { }

        public void MarkAsModified(Store item)
        {
            Entry(item).State = EntityState.Modified;
        }

        public void MarkAsModified(Entry item)
        {
            Entry(item).State = EntityState.Modified;
        }
    }
}
