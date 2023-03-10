using StoreStats.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreStats.API.Models
{
    public class CreateEntryDto
    {
        [Required]
        public int StoreId { get; set; }
        [Required]
        public DateTime EntryDate { get; set; }

        public Entry ToEntry()
        {
            return new Entry
            {
                StoreId = StoreId,
                EntryDate = EntryDate
            };
        }
    }
}