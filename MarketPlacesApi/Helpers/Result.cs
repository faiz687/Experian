using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPlacesApi.Models
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public T value { get; set; }
    }
}
