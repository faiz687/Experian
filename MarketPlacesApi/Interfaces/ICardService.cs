using MarketPlaces.Entity.Models;
using MarketPlacesApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketPlacesApi.Interfaces
{
    public interface ICardService
    {
        Task<Result<List<Card>>> FindCards(ApplicantDetailDto applicantDetailDto);
    }
}