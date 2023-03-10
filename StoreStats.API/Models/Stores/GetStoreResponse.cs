using StoreStats.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreStats.API.Models
{
    public class GetStoreResponse : BaseResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public GetStoreResponse(Store store)
        {
            Id = store.Id;
            Name = store.Name;
            City = store.City;
            Country = store.Country;
            Status = true;
        }
    }
}