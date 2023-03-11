using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreStats.API.Controllers;
using StoreStats.API.Models;
using StoreStats.Data.Models;
using StoreStatsApi.Test.Contexts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace StoreStatsApi.Test
{
    [TestClass]
    public class TestEntriesController
    {

        [TestMethod]
        public async Task PostStore_ShouldReturnCreatedAt()
        {
            var controller = new EntriesController(GetTestDbContext());
            var item = GetCreateEntryDto();

            var result = await controller.PostEntry(item) as CreatedAtRouteNegotiatedContentResult<CreateEntryResponse>;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(CreatedAtRouteNegotiatedContentResult<CreateEntryResponse>));
        }

        //[TestMethod]
        //public void CreateStoreDto_NoName_ValidationFails()
        //{
        //    var item = GetCreateEntryDto();

        //    var context = new ValidationContext(item, null, null);
        //    var results = new List<ValidationResult>();

        //    var isModelStateValid = Validator.TryValidateObject(item, context, results, true);

        //    Assert.IsFalse(isModelStateValid);
        //}

        [TestMethod]
        public async Task PostStore_ValidationFails_ShouldReturnBadRequest()
        {
            var controller = new EntriesController(GetTestDbContext());
            var item = GetCreateEntryDto();

            controller.ModelState.AddModelError("model", "invalid");

            var result = await controller.PostEntry(item) as InvalidModelStateResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(InvalidModelStateResult));
        }

        private static CreateEntryDto GetCreateEntryDto()
        {
            return new CreateEntryDto() { StoreId = 4, EntryDate = new DateTime(2023, 03, 11, 20, 09, 17) };
        }

        private static TestStoreStatsDbContext GetTestDbContext()
        {
            var db = new TestStoreStatsDbContext();
            db.Entries.Add(new Entry { Id = 1, StoreId = 1, EntryDate = new DateTime(2023, 03, 10, 11, 20, 59) });
            db.Entries.Add(new Entry { Id = 2, StoreId = 1, EntryDate = new DateTime(2023, 03, 10, 11, 15, 05) });
            db.Entries.Add(new Entry { Id = 3, StoreId = 4, EntryDate = new DateTime(2023, 03, 10, 08, 15, 23) });
            db.Entries.Add(new Entry { Id = 4, StoreId = 4, EntryDate = new DateTime(2023, 03, 09, 08, 20, 59) });
            db.Entries.Add(new Entry { Id = 5, StoreId = 4, EntryDate = new DateTime(2023, 03, 09, 11, 20, 59) });
            db.Entries.Add(new Entry { Id = 6, StoreId = 4, EntryDate = new DateTime(2023, 03, 09, 11, 20, 59) });
            db.Entries.Add(new Entry { Id = 7, StoreId = 4, EntryDate = new DateTime(2023, 03, 08, 11, 20, 59) });
            db.Entries.Add(new Entry { Id = 8, StoreId = 4, EntryDate = new DateTime(2023, 03, 07, 11, 20, 59) });
            db.Entries.Add(new Entry { Id = 9, StoreId = 4, EntryDate = new DateTime(2023, 03, 10, 11, 20, 59) });
            return db;                        
        }                                     
    }                                         
}                                             
                                              