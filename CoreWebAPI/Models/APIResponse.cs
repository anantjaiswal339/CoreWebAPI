using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAPI.Models
{
    public class APIResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public object ResponseData { get; set; }
    }
}
