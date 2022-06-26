using MarketPlaces.Data.Interfaces;
using MarketPlaces.Entity.Models;
using MarketPlacesApi.Helpers;
using MarketPlacesApi.Interfaces;
using MarketPlacesApi.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPlacesApi.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly ILogger<ApplicantService> _logger;

        public ApplicantService(IApplicantRepository applicantRepository, ILogger<ApplicantService> logger)
        {
            _applicantRepository = applicantRepository;
            _logger = logger;
        }

        public async Task<Result<string>> SaveApplicantWithResults(Applicant applicant, List<Card> cards = null)
        {
            var result = new Result<string>();

            try
            {
                if (cards != null && cards.Any())
                {
                    var applicantCards = new List<ApplicantCard>();

                    foreach (var card in cards)
                    {
                        var applicantCard = new ApplicantCard();
                        applicantCard.Applicant = applicant;
                        applicantCard.Card = card;

                        applicantCards.Add(applicantCard);
                    }

                    applicant.applicantCards = applicantCards;
                }

                await _applicantRepository.Add(applicant);

                result.Success = true;
                return result;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"An Error occured while Saving applicant details with error message :  {ex.Message}");
                result.Success = false;
                return result;
            }
        }
    }
}
