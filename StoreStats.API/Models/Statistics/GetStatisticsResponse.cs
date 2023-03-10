using StoreStats.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreStats.API.Models
{
    public class GetStatisticsResponse : BaseResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<Statistic> Statistics { get; set; }
        public GetStatisticsResponse(Store store)
        {
            Id = store.Id;
            Name = store.Name;
            City = store.City;
            Country = store.Country;
            Status = true;
        }

        public void GetStatistics(Store store)
        {
            Statistics = store.Entries
                .GroupBy(x => x.EntryDate.Date)
                .Select(x => new Statistic { Date = x.Key, Count = x.Count() })
                .OrderBy(x => x.Date)
                .ToList();
        }
    }
}