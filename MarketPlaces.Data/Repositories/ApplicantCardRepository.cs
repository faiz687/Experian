using MarketPlaces.Data.Interfaces;
using MarketPlaces.Entity.Context;
using MarketPlaces.Entity.Models;

namespace MarketPlaces.Data.Repositories
{
    public class ApplicantCardRepository : BaseRepository<ApplicantCard>, IApplicantCardRepository
    {
        public ApplicantCardRepository(MarketPlacesContext context) : base(context) 
        {

        }
    }
}
