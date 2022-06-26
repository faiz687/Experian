using MarketPlaces.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketPlaces.Entity.Context
{
    public class MarketPlacesContext : DbContext
    {
        public MarketPlacesContext(DbContextOptions<MarketPlacesContext> options) : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<ApplicantCard> ApplicantCards { get; set; }
    }
}
