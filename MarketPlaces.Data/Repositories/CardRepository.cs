using MarketPlaces.Data.Interfaces;
using MarketPlaces.Entity.Context;
using MarketPlaces.Entity.Models;

namespace MarketPlaces.Data.Repositories
{
    public class CardRepository : BaseRepository<Card> , ICardRepository
    {
        public CardRepository(MarketPlacesContext context) : base(context) 
        { 

        }
    }
}
