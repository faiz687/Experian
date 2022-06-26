using MarketPlaces.Data.Interfaces;
using MarketPlaces.Entity.Context;
using MarketPlaces.Entity.Models;

namespace MarketPlaces.Data.Repositories
{
    public class ApplicantRepository : BaseRepository<Applicant> , IApplicantRepository
    {
        public ApplicantRepository(MarketPlacesContext context) : base(context) 
        {

        }
    }
}
