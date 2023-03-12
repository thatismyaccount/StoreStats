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
using StoreStats.Data.Models;
using StoreStats.Data.Services;

namespace StoreStats.API.Controllers
{
    public class EntriesController : ApiController
    {
        private readonly IEntriesService _service;
        public EntriesController() { }
        public EntriesController(IEntriesService service)
        {
            _service = service;
        }

        // POST: api/Entries
        [ResponseType(typeof(CreateEntryResponse))]
        public async Task<IHttpActionResult> PostEntry(CreateEntryDto entry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.PostEntryAsync(entry);

            return CreatedAtRoute("Entries", new { id = 0 }, response);
        }
    }
}