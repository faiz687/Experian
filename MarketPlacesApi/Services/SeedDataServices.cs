using MarketPlacesApi.Data;
using MarketPlacesApi.Interfaces;
using MarketPlacesApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPlacesApi.Services
{
    public class SeedDataServices : ISeedDataService
    {
        public async Task Initialize(MarketPlacesContext context)
        {
            context.Database.Migrate();

            if (!context.Cards.Any())
            {
                context.Cards.Add(new Card() { Name = "Barclays", APR = 10, PromotionalMessage = "Welcome to Barclays" });
                context.Cards.Add(new Card() { Name = "Vanquis", APR = 11, PromotionalMessage =  "Welcome to Vanquis" });
                context.Cards.Add(new Card() { Name = "HSBC", APR = 12, PromotionalMessage = "Welcome to HSBC" });
                context.Cards.Add(new Card() { Name = "NatWest", APR = 13, PromotionalMessage =  "Welcome to NatWest"});
            }

            await context.SaveChangesAsync();
        }
    }
}
