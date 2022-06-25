using System;
using System.ComponentModel.DataAnnotations;

namespace MarketPlacesApi.Models
{
    public class ApplicantDetailDto
    {
        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public long?  AnnualIncome { get; set; }
    }
}