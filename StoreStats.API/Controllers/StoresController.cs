using StoreStats.API.Models;
using StoreStats.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace StoreStats.API.Controllers
{
    public class StoresController : ApiController
    {
        private readonly IStoreStatsDbContext db = new StoreStatsDbContext();
        public StoresController()
        {

        }
        public StoresController(IStoreStatsDbContext dbContext)
        {
            db = dbContext;
        }

        // GET: api/store/5
        [ResponseType(typeof(GetStoreResponse))]
        public async Task<IHttpActionResult> GetStore(int id)
        {
            Store store = await db.Stores.FindAsync(id);
            if (store == null)
            {
                return NotFound();
            }

            return Ok(new GetStoreResponse(store));
        }

        // PUT: api/store/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStore(int id, PutStoreDto store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != store.Id)
            {
                return BadRequest();
            }

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
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(new PutStoreResponse(dbStore));
        }

        // POST: api/store
        [ResponseType(typeof(PostStoreResponse))]
        public async Task<IHttpActionResult> PostStore(CreateStoreDto store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbStore = store.ToStore();
            db.Stores.Add(dbStore);
            await db.SaveChangesAsync();

            return CreatedAtRoute("Stores", new { id = dbStore.Id }, new PostStoreResponse(dbStore));
        }

        // DELETE: api/store/5
        [ResponseType(typeof(DeleteStoreResponse))]
        public async Task<IHttpActionResult> DeleteStore(int id)
        {
            Store store = await db.Stores.FindAsync(id);
            if (store == null)
            {
                return NotFound();
            }

            db.Stores.Remove(store);
            await db.SaveChangesAsync();

            return Ok(new DeleteStoreResponse(store));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StoreExists(int id)
        {
            return db.Stores.Count(e => e.Id == id) > 0;
        }
    }
}
