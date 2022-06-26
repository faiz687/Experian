using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPlacesApi.Helpers
{
    public static class MarketPlacesHelper
    {
        public static bool IsApplicant18(DateTime DateOfBirth)
        {
            if (CalculateAge(DateOfBirth) >= 18)
            {
                return true;
            }

            return false;
        }

        public static int CalculateAge(DateTime DateOfBirth)
        {
            var age = 0;

            age = DateTime.Now.Year - DateOfBirth.Year;

            if (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear)
            {
                age -= 1;
            }

            return age;
        }
    }
}
