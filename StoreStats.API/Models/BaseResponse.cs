﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreStats.API.Models
{
    public class BaseResponse
    {
        public string Message { get; set; }
        public bool Status { get; set; }
    }
}