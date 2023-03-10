using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreStats.API.Controllers;
using StoreStats.API.Models;
using StoreStats.Data.Models;
using StoreStatsApi.Test.Contexts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public async Task DeleteStore_ShouldReturnOk()
        {
            var controller = new StoresController(GetTestDbContext());

            var result = await controller.DeleteStore(4) as OkNegotiatedContentResult<DeleteStoreResponse>;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<DeleteStoreResponse>));
            Assert.AreEqual(true, result.Content.Status);
        }

        [TestMethod]
        public async Task DeleteStore_ShouldReturnNotFound()
        {
            var controller = new StoresController(GetTestDbContext());

            var result = await controller.DeleteStore(99) as NotFoundResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task PutStore_ShouldReturnStatusCode()
        {
            var controller = new StoresController(GetTestDbContext());
            var item = GetPutStoreDto();

            var result = await controller.PutStore(4, item) as OkNegotiatedContentResult<PutStoreResponse>;

            Assert.IsNotNull(result);
            Assert.AreEqual(true, result.Content.Status);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<PutStoreResponse>));
        }

        [TestMethod]
        public async Task PutStore_DifferentIds_ShouldReturnBadRequest()
        {
            var controller = new StoresController(GetTestDbContext());
            var item = GetPutStoreDto();

            var result = await controller.PutStore(5, item) as BadRequestResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public async Task PutStoreDto_ValidationFailed_ShouldReturnBadRequest()
        {
            var controller = new StoresController(GetTestDbContext());
            var item = GetPutStoreDto();
            controller.ModelState.AddModelError("test", "test");


            var result = await controller.PutStore(4, item) as InvalidModelStateResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(InvalidModelStateResult));
        }

        [TestMethod]
        public void PutStore_NoName_ValidationFailes()
        {
            var sut = GetPutStoreDto();
            sut.Name = null;
            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();

            var isModelStateValid = Validator.TryValidateObject(sut, context, results, true);

            Assert.IsFalse(isModelStateValid);
        }

        [TestMethod]
        public async Task PostStore_ShouldReturnCreatedAt()
        {
            var controller = new StoresController(GetTestDbContext());
            CreateStoreDto item = GetCreateStoreDto();
            item.Name = null;

            var result = await controller.PostStore(item) as CreatedAtRouteNegotiatedContentResult<PostStoreResponse>;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(CreatedAtRouteNegotiatedContentResult<PostStoreResponse>));
            
        }

        [TestMethod]
        public void CreateStoreDto_NoName_ValidationFails()
        {
            var sut = GetCreateStoreDto();
            sut.Name = null;
            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();

            var isModelStateValid = Validator.TryValidateObject(sut, context, results, true);

            Assert.IsFalse(isModelStateValid);
        }

        [TestMethod]
        public async Task PostStore_ValidationFails_ShouldReturnBadRequest()
        {
            var controller = new StoresController(GetTestDbContext());
            CreateStoreDto item = GetCreateStoreDto();

            controller.ModelState.AddModelError("test", "test");

            var result = await controller.PostStore(item) as InvalidModelStateResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(InvalidModelStateResult));
        }

        private PutStoreDto GetPutStoreDto()
        {
            return new PutStoreDto { Id = 4, Name = "Store #4", City = "Toruń", Country = "Poland" };
        }

        private static CreateStoreDto GetCreateStoreDto()
        {
            return new CreateStoreDto() { City = "Katowice", Country = "Poland", Name = "Store #5" };
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
