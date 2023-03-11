using StoreStats.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreStatsApi.Test.Contexts
{
    class TestEntryDbStore : TestDbSet<Entry>
    {
        public override Entry Find(params object[] keyValues)
        {
            return this.SingleOrDefault(entry => entry.Id == (int)keyValues.Single());
        }

        public override Task<Entry> FindAsync(params object[] keyValues)
        {
            return Task.FromResult(this.SingleOrDefault(entry => entry.Id == (int)keyValues.Single()));
        }

    }
}