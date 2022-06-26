using MarketPlaces.Entity.Models;
using System.Collections.Generic;

namespace MarketPlacesApi.Models
{
    public class Response
    {
        public List<Card>  Cards { get; set; }
        public string Message { get; set; }
    }
}
