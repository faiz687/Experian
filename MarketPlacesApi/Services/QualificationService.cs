using MarketPlacesApi.Helpers;
using MarketPlacesApi.Interfaces;
using MarketPlacesApi.Models;
using Microsoft.Extensions.Logging;
using System;

namespace MarketPlacesApi.Services
{
    public class QualificationService : IQualificationService
    {
        private readonly ILogger<QualificationService> _logger;

        public QualificationService(ILogger<QualificationService> logger)
        {
            _logger = logger;
        }

        public Result<string> IsApplicantEligible(ApplicantDetailDto applicantDetailDto)
        {
            var result = new Result<string> { Success = false };
            try
            {
                if (applicantDetailDto != null)
                {
                    //age check
                    if (applicantDetailDto.DateOfBirth.HasValue)
                    {
                        if (!MarketPlacesHelper.IsApplicantAbove18(applicantDetailDto.DateOfBirth.Value))
                        {
                            return new Result<string> { value = "no credit cards are available", Success = false };
                        }
                    }
                    else
                    {
                        return new Result<string> { value = "Date of Birth is required to determine eligibility", Success = false };
                    }

                    //additional checks in future??
                    result.Success = true;
                    return result;
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An Error occured while Checking applicant eligibility with error message :  {ex.Message}");
                return result;
            }
        }
    }
}
