using MarketPlaces.Entity.Models;
using MarketPlacesApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketPlacesApi.Interfaces
{
    public interface IApplicantService
    {
        Task<Result<string>> SaveApplicantWithResults(Applicant applicant, List<Card> cards = null);
    }
}