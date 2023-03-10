using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreStats.API.Controllers;
using StoreStats.API.Models;
using StoreStats.Data.Models;
using StoreStatsApi.Test.Contexts;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace StoreStatsApi.Test
{
    [TestClass]
    public class TestStoresController
    {
        [TestMethod]
        public async Task GetStore_ShouldFindExistingStore()
        {
            var testDbContext = GetTestDbContext();
            var controller = new StoresController(testDbContext);

            var result = await controller.GetStore(1);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<GetStoreResponse>));
        }

        [TestMethod]
        public async Task GetStore_ShouldNotFindProduct()
        {
            var controller = new StoresController(GetTestDbContext());

            var result = await controller.GetStore(999);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task PutStore_ShouldReturnStatusCode()
        {
            var controller = new StoresController(GetTestDbContext());
            var item = GetTestStore();

            var result = await controller.PutStore(4, item) as OkNegotiatedContentResult<PutStoreResponse>;

            Assert.IsNotNull(result);
            Assert.AreEqual(true, result.Content.Status);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<PutStoreResponse>));
        }

        [TestMethod]
        public async Task PutStore_ShouldReturnBadRequest()
        {
            var controller = new StoresController(GetTestDbContext());
            var item = GetTestStore();

            var result = await controller.PutStore(5, item) as BadRequestResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        private PutStoreDto GetTestStore()
        {
            return new PutStoreDto { Id = 4, Name = "Store #4", City = "Toruń", Country = "Poland" };
        }

        private static TestStoreStatsDbContext GetTestDbContext()
        {
            var db = new TestStoreStatsDbContext();
            db.Stores.Add(new Store { Id = 1, Name = "Store #1", City = "Castle Douglas", Country = "Scotland" });
            db.Stores.Add(new Store { Id = 2, Name = "Store #2", City = "Newton Stewart", Country = "Scotland" });
            db.Stores.Add(new Store { Id = 3, Name = "Store #3", City = "Lockerbie", Country = "Scotland" });
            db.Stores.Add(new Store { Id = 4, Name = "Store #4", City = "Bydgoszcz", Country = "Poland" });
            return db;
        }
    }
}
