using MarketPlaces.Data.Interfaces;
using MarketPlaces.Entity.Models;
using MarketPlacesApi.Enum;
using MarketPlacesApi.Interfaces;
using MarketPlacesApi.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPlacesApi.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly ILogger<CardService> _logger;

        public CardService(ICardRepository cardRepository, ILogger<CardService> logger)
        {
            _logger = logger;
            _cardRepository = cardRepository;
        }

        public async Task<Result<List<Card>>> FindCards(ApplicantDetailDto applicantDetailDto)
        {
            Result<List<Card>> result = new Result<List<Card>>();
            result.value = new List<Card>();
            result.Success = false;
            try
            {
                if (applicantDetailDto != null && applicantDetailDto.AnnualIncome != null)
                {
                    var allCards = await _cardRepository.GetAll();

                    Card card;

                    if (applicantDetailDto.AnnualIncome > 30000)
                    {
                        card = allCards.FirstOrDefault(a => a.Name == CardsEnum.Barclays.ToString());
                    }
                    else
                    {
                        card = allCards.FirstOrDefault(a => a.Name == CardsEnum.Vanquis.ToString());
                    }

                    if (card != null)
                    {
                        result.Success = true;
                        result.value.Add(card);
                        return result;
                    }
                }

                return result;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An Error occured while finding card with error message :  {ex.Message}");
                return result;
            }
        }
    }
}
