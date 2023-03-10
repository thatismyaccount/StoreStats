using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreStats.API.Models
{
    public class IsoDateConverter : IsoDateTimeConverter
    {
        public IsoDateConverter() => this.DateTimeFormat = "yyyy-MM-dd";
    }
}