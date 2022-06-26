using MarketPlaces.Data.Interfaces;
using MarketPlaces.Entity.Models;
using MarketPlacesApi.Enum;
using MarketPlacesApi.Interfaces;
using MarketPlacesApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPlacesApi.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<Result<List<Card>>> FindCards(ApplicantDetailDto applicantDetailDto)
        {
            Result<List<Card>> result = new Result<List<Card>>();
            result.value = new List<Card>();

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

            result.Success = false;
            return result;
        }
    }
}
