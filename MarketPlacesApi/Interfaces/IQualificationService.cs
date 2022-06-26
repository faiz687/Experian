using MarketPlacesApi.Models;

namespace MarketPlacesApi.Interfaces
{
    public interface IQualificationService
    {
        Result<string> IsApplicantEligible(ApplicantDetailDto applicantDetailDto);
    }
}
