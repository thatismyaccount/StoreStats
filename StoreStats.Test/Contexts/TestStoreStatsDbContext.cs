using StoreStats.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreStatsApi.Test.Contexts
{
    public class TestStoreStatsDbContext : IStoreStatsDbContext
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<Entry> Entries { get; set; }

        public TestStoreStatsDbContext()
        {
            this.Stores = new TestStoreDbSet();
        }

        public int SaveChanges()
        {
            return 0;
        }

        public Task<int> SaveChangesAsync()
        {
            return Task.FromResult(0);
        }

        public void MarkAsModified(Store item) { }
        public void MarkAsModified(Entry item) { }
        public void Dispose() { }
    }
}
