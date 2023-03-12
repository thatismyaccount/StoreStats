using StoreStats.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreStats.Data.Services
{
    public class EntriesService : IEntriesService, IDisposable
    {
        private readonly IStoreStatsDbContext db;
        public EntriesService(IStoreStatsDbContext dbContext)
        {
            db = dbContext;
        }

        public async Task<CreateEntryResponse> PostEntryAsync(CreateEntryDto entry)
        {
            var dbEntry = entry.ToEntry();
            db.Entries.Add(dbEntry);
            await db.SaveChangesAsync();

            return new CreateEntryResponse();
        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}
