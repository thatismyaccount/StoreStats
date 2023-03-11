using StoreStats.API.Models;
using StoreStats.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace StoreStats.API.Controllers
{
    [RoutePrefix("api/store/statistics")]
    public class StatisticsController : ApiController
    {
        private readonly IStoreStatsDbContext db = new StoreStatsDbContext();
        public StatisticsController()
        {

        }
        public StatisticsController(IStoreStatsDbContext dbContext)
        {
            db = dbContext;
        }



        // GET: api/store/5
        [Route("{id}")]
        [ResponseType(typeof(GetStatisticsResponse))]
        public async Task<IHttpActionResult> GetStatistics(int id, [FromUri]DateTime startDate, [FromUri] DateTime endDate)
        {
            Store store = await db.Stores.FindAsync(id);

            if (store == null)
            {
                return NotFound();
            }

            db.LoadEntriesForStore(store, startDate, endDate);

            var response = new GetStatisticsResponse(store);
            response.LoadStatistics(store);

            return Ok(response);
        }
    }
}
