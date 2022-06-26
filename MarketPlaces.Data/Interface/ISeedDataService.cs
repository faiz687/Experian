using MarketPlaces.Entity.Context;
using System.Threading.Tasks;

namespace MarketPlaces.Data.Interfaces
{
    public interface ISeedDataService
    {
        Task Initialize(MarketPlacesContext context);
    }
}
