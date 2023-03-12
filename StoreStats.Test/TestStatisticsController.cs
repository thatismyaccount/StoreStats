using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreStats.API.Controllers;
using StoreStats.Data.Models;
using StoreStats.Data.Services;
using StoreStatsApi.Test.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace StoreStatsApi.Test
{
    [TestClass]
    public class TestStatisticsController
    {
        [TestMethod]
        public async Task GetStatistics_ShouldReturnOk()
        {
            var controller = CreateController();

            var result = await controller.GetStatistics(1, DateTime.MinValue, DateTime.MaxValue) as OkNegotiatedContentResult<GetStatisticsResponse>;
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<GetStatisticsResponse>));
        }

        [TestMethod]
        public async Task GetStatistics_ShouldReturnProperStatisticsObject()
        {
            var controller = CreateController();

            var result = await controller.GetStatistics(1, DateTime.MinValue, DateTime.MaxValue) as OkNegotiatedContentResult<GetStatisticsResponse>;
            
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<GetStatisticsResponse>));
            Assert.AreEqual("Store #1", result.Content.Name);
            Assert.AreEqual("Castle Douglas", result.Content.City);
            Assert.AreEqual("Scotland", result.Content.Country);
            Assert.AreEqual(true, result.Content.Status);
        }

        [TestMethod]
        public async Task GetStatistics_ShouldReturnProperStatisticsCollection()
        {
            var controller = CreateController();

            var result = await controller.GetStatistics(4, DateTime.MinValue, DateTime.MaxValue) as OkNegotiatedContentResult<GetStatisticsResponse>;

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<GetStatisticsResponse>));

            Assert.IsNotNull(result.Content.Statistics);
            Assert.AreEqual(4, result.Content.Statistics.Count);
        }

        [TestMethod]
        public async Task GetStatistics_ShouldNotFindProduct()
        {
            var testDbContext = GetTestDbContext();
            var statisticService = new StatisticsService(testDbContext);
            var controller = new StatisticsController(statisticService);

            var result = await controller.GetStatistics(999, DateTime.MinValue, DateTime.MaxValue);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        private static StatisticsController CreateController()
        {
            var testDbContext = GetTestDbContext();
            var statisticService = new StatisticsService(testDbContext);
            return new StatisticsController(statisticService);
        }

        private static TestStoreStatsDbContext GetTestDbContext()
        {
            var db = new TestStoreStatsDbContext();
            db.Stores.Add(new Store
            {
                Id = 1,
                Name = "Store #1",
                City = "Castle Douglas",
                Country = "Scotland",
                Entries = new List<Entry>
                {
                    new Entry { Id = 1, StoreId = 1, EntryDate = new DateTime(2023, 03, 10, 11, 20, 59) },
                    new Entry { Id = 2, StoreId = 1, EntryDate = new DateTime(2023, 03, 10, 11, 15, 05) }
                }
            });
            db.Stores.Add(new Store
            { 
                Id = 2, 
                Name = "Store #2", 
                City = "Newton Stewart", 
                Country = "Scotland" 
            });
            db.Stores.Add(new Store 
            { 
                Id = 3, 
                Name = "Store #3", 
                City = "Lockerbie", 
                Country = "Scotland" 
            });

            db.Stores.Add(new Store 
            { 
                Id = 4, 
                Name = "Store #4", 
                City = "Bydgoszcz", 
                Country = "Poland" ,
                Entries = new List<Entry>
                {
                    new Entry { Id = 1, StoreId = 1, EntryDate = new DateTime(2023, 03, 10, 11, 20, 59) },
                    new Entry { Id = 2, StoreId = 1, EntryDate = new DateTime(2023, 03, 10, 11, 15, 05) },
                    new Entry { Id = 3, StoreId = 4, EntryDate = new DateTime(2023, 03, 10, 08, 15, 23) },
                    new Entry { Id = 4, StoreId = 4, EntryDate = new DateTime(2023, 03, 09, 08, 20, 59) },
                    new Entry { Id = 5, StoreId = 4, EntryDate = new DateTime(2023, 03, 09, 11, 20, 59) },
                    new Entry { Id = 6, StoreId = 4, EntryDate = new DateTime(2023, 03, 09, 11, 20, 59) },
                    new Entry { Id = 7, StoreId = 4, EntryDate = new DateTime(2023, 03, 08, 11, 20, 59) },
                    new Entry { Id = 8, StoreId = 4, EntryDate = new DateTime(2023, 03, 07, 11, 20, 59) },
                    new Entry { Id = 9, StoreId = 4, EntryDate = new DateTime(2023, 03, 10, 11, 20, 59) },
                }
            });
            return db;
        }
    }
}
