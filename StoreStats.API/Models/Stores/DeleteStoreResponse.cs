using StoreStats.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreStats.API.Models
{
    public class DeleteStoreResponse : BaseResponse
    {
        public int Id { get; set; }

        public DeleteStoreResponse(Store store)
        {
            Id = store.Id;
            Status = true;
        }
    }
}