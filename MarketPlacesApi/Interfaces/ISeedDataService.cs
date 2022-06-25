using MarketPlacesApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPlacesApi.Interfaces
{
    public interface ISeedDataService
    {
        Task Initialize(MarketPlacesContext context);
    }
}
