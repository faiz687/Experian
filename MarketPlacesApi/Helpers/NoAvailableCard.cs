using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPlacesApi.Models
{
    public class Response
    {
        public List<Card>  Cards { get; set; }
        public string Message { get; set; }
    }
}
