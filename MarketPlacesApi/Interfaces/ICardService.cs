using MarketPlaces.Entity.Models;
using MarketPlacesApi.Models;
using System.Collections.Generic;

namespace MarketPlacesApi.Interfaces
{
    public interface ICardService
    {
        Result<List<Card>> FindCards(ApplicantDetailDto applicantDetail);
    }
}
