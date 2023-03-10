using StoreStats.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreStats.Data.Models
{
    public interface IStoreStatsDbContext
    {
        DbSet<Store> Stores { get; }
        DbSet<Entry> Entries { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();

        void MarkAsModified(Store item);
        void MarkAsModified(Entry item);
        void Dispose();
        void LoadEntriesForStore(Store store, DateTime startDate, DateTime endDate);
    }
}
