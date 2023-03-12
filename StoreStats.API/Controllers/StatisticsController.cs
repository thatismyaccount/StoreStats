using StoreStats.Data.Models;
using StoreStats.Data.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace StoreStats.API.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    [RoutePrefix("api/store/statistics")]
    public class StatisticsController : ApiController
    {
        private readonly IStatisticsService service;

        //todo: move logic from controllers to services in data layer https://www.freecodecamp.org/news/an-awesome-guide-on-how-to-build-restful-apis-with-asp-net-core-87b818123e28/
        //todo: consider moving response models and dtos from StoreStats.API to StoreStats.Data
        //todo: register IServices in ioc so controllers can get it upon creation https://learn.microsoft.com/en-us/aspnet/web-api/overview/advanced/dependency-injection
        //todo: update controllers' tests so they work
        //
        public StatisticsController(IStatisticsService service)
        {
            this.service = service;
        }

        // GET: api/store/statistics/5
        [Route("{id}")]
        [ResponseType(typeof(GetStatisticsResponse))]
        public async Task<IHttpActionResult> GetStatistics(int id, [FromUri]DateTime startDate, [FromUri] DateTime endDate)
        {
            GetStatisticsResponse response = await service.GetStatisticsAsync(startDate, endDate, id);

            if(response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
