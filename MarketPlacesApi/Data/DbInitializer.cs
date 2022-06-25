using System;
using System.Linq;
using MarketPlacesApi.Models;
using Microsoft.Extensions.DependencyInjection;

namespace MarketPlacesApi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MarketPlacesContext context)
        {
            if (context.Cards.Any())
            {
                return;   // DB has been seeded
            }

            var cards = new Card[]
            {
                new Card
                {
                     Name =  "Barclaycard",
                     APR  =  10,
                     PromotionalMessage = "Welcome to Barclays"
                },
                new Card
                {
                     Name =  "Vanquiscard",
                     APR  =  11,
                     PromotionalMessage = "Welcome to Vanquis"
                },
                new Card
                {
                     Name =  "HSBC",
                     APR  =  12,
                     PromotionalMessage = "Welcome to HSBC"
                },
                new Card
                {
                     Name =  "NatWest",
                     APR  =  13,
                     PromotionalMessage = "Welcome to NatWest"
                },

            };

            foreach (Card card in cards)
            {
                context.Cards.Add(card);
            }
            context.SaveChanges();          
        }
    }
}
