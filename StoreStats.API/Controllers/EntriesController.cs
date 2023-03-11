using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using StoreStats.API.Models;
using StoreStats.Data.Models;

namespace StoreStats.API.Controllers
{
    public class EntriesController : ApiController
    {
        private readonly IStoreStatsDbContext db = new StoreStatsDbContext();
        public EntriesController() { }
        public EntriesController(IStoreStatsDbContext dbContext)
        {
            db = dbContext;
        }

        // POST: api/Entries
        [ResponseType(typeof(CreateEntryResponse))]
        public async Task<IHttpActionResult> PostEntry(CreateEntryDto entry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var dbEntry = entry.ToEntry();
            db.Entries.Add(dbEntry);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = dbEntry.Id }, new CreateEntryResponse());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}