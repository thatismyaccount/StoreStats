using StoreStats.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreStats.Data.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IStoreStatsDbContext db;
        public StatisticsService(IStoreStatsDbContext dbContext)
        {
            db = dbContext;
        }
        public async Task<GetStatisticsResponse> GetStatisticsAsync(DateTime startDate, DateTime endDate, int id)
        {
            Store store = await db.Stores.FindAsync(id);

            if (store == null)
            {
                return null;
            }

            var response = new GetStatisticsResponse(store);

            db.LoadEntriesForStore(store, startDate, endDate);

            response.LoadStatistics(store);
            return response;
        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}
