using MarketPlacesApi.Helpers;
using MarketPlacesApi.Interfaces;
using MarketPlacesApi.Models;

namespace MarketPlacesApi.Services
{
    public class QualificationService : IQualificationService
    {
        public Result<string> IsApplicantEligible(ApplicantDetailDto applicantDetailDto)
        {
            var result = new Result<string>();

            if (applicantDetailDto != null)
            {
                //age check
                if (applicantDetailDto.DateOfBirth.HasValue)
                {
                    if (!MarketPlacesHelper.IsApplicantAbove18(applicantDetailDto.DateOfBirth.Value))
                    {
                        return new Result<string> { value = "Sorry, Your age does not meet the eligibility", Success = false };
                    }
                }
                else
                {
                    return new Result<string> { value = "Date of Birth is required to determine eligibility", Success = false };
                }

                //additional checks in future??

            }

            result.Success = true;
            return result;
        }
    }
}
