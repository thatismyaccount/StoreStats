using StoreStats.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreStatsApi.Test.Contexts
{
    public class TestStoreDbSet : TestDbSet<Store>
    {
        public override Store Find(params object[] keyValues)
        {
            return this.SingleOrDefault(product => product.Id == (int)keyValues.Single());
        }

        public override Task<Store> FindAsync(params object[] keyValues)
        {
            return Task.FromResult(this.SingleOrDefault(product => product.Id == (int)keyValues.Single()));
        }
    }
}
