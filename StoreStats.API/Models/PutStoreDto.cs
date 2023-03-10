using StoreStats.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreStats.API.Models
{
    public class PutStoreDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public Store ToStore()
        {
            return new Store
            {
                Id = Id,
                Name = Name,
                City = City,
                Country = Country
            };
        }
    }
}