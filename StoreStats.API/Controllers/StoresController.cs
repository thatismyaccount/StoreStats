using StoreStats.Data.Models;
using StoreStats.Data.Services;
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
        private readonly IStoresService _service;
        public StoresController(IStoresService service)
        {
            _service = service;
        }

        // GET: api/store/5
        [ResponseType(typeof(GetStoreResponse))]
        public async Task<IHttpActionResult> GetStore(int id)
        {
            GetStoreResponse response = await _service.GetStoreAsync(id);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
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

            var response = await _service.PutStoreAsync(id, store);
            return Ok(response);
        }
        // POST: api/store
        [ResponseType(typeof(PostStoreResponse))]
        public async Task<IHttpActionResult> PostStore(CreateStoreDto store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.PostStoreAsync(store);

            return CreatedAtRoute("Stores", new { id = response.Id }, response);
        }

        // DELETE: api/store/5
        [ResponseType(typeof(DeleteStoreResponse))]
        public async Task<IHttpActionResult> DeleteStore(int id)
        {
            var response = await _service.DeleteStoreAsync(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}
