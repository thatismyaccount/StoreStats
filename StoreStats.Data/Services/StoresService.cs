using StoreStats.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreStats.Data.Services
{
    public class StoresService : IStoresService
    {
        private readonly IStoreStatsDbContext db;
        public StoresService(IStoreStatsDbContext dbContext)
        {
            db = dbContext;
        }

        public async Task<GetStoreResponse> GetStoreAsync(int id)
        {
            Store store = await db.Stores.FindAsync(id);
            if(store == null)
            {
                return null;
            }

            var response = new GetStoreResponse(store);
            return response;
        }


        public async Task<PutStoreResponse> PutStoreAsync(int id, PutStoreDto store)
        {
            var dbStore = store.ToStore();

            db.MarkAsModified(dbStore);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return new PutStoreResponse(dbStore);
        }

        public async Task<PostStoreResponse> PostStoreAsync(CreateStoreDto store)
        {
            var dbStore = store.ToStore();

            db.Stores.Add(dbStore);
            await db.SaveChangesAsync();

            return new PostStoreResponse(dbStore);
        }

        public async Task<DeleteStoreResponse> DeleteStoreAsync(int id)
        {
            Store store = await db.Stores.FindAsync(id);
            if (store == null)
            {
                return null;
            }

            db.Stores.Remove(store);
            await db.SaveChangesAsync();

            return new DeleteStoreResponse(store);
        }

        private bool StoreExists(int id)
        {
            return db.Stores.Count(e => e.Id == id) > 0;
        }
    }
}
