using Newtonsoft.Json;
using System;

namespace StoreStats.Data.Models
{
    public class Statistic
    {
        [JsonConverter(typeof(IsoDateConverter))]
        public DateTime Date { get; set; }
        public int Count { get; set; }

    }
}