using MarketPlaces.Entity.Models;
using System.Collections.Generic;

namespace MarketPlacesApi.Models
{
    public class Response
    {
        public string Message { get; set; }
        public List<Card> Cards { get; set; } = new List<Card>();
    }
}
