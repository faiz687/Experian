using System;

namespace MarketPlacesApi.Models
{
    public class ApplicantDetail
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int AnnualIncome { get; set; }
        public Card Result { get; set; }

    }
}