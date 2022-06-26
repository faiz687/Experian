using System;
using System.Collections.Generic;

namespace MarketPlaces.Entity.Models
{
    public class ApplicantDetail
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedDate { get; set; }
        public int AnnualIncome { get; set; }
        public List<ApplicantCard> applicantCards { get; set; }
    }
}