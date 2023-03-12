using StoreStats.Data.Models;
using System;
using System.Threading.Tasks;

namespace StoreStats.Data.Services
{
    public interface IStatisticsService
    {
        Task<GetStatisticsResponse> GetStatisticsAsync(DateTime startDate, DateTime endDate, int id);
    }
}