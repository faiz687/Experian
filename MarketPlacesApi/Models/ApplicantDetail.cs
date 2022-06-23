using System;
using System.ComponentModel.DataAnnotations;

namespace MarketPlacesApi.Models
{
    public class ApplicantDetail
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int AnnualIncome { get; set; }
    }
}