using StoreStats.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreStats.API.Models
{
    public class StoreDto
    {
        [Required]
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public Store ToStore()
        {
            return new Store
            {
                Name = Name,
                City = City,
                Country = Country
            };
        }
    }
}
