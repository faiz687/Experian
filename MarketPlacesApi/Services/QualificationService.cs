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
                    if (!MarketPlacesHelper.IsApplicant18(applicantDetailDto.DateOfBirth.Value))
                    {
                        return new Result<string> { value = "Sorry, We do not have any Cards for you.", Success = false };
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
