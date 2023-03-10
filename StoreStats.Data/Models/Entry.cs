using System;

namespace StoreStats.Data.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public virtual Store Store { get; set; }
        public int StoreId { get; set; }
    }
}
