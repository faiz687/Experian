using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPlacesApi.Enum
{
    public enum CardsEnum
    {
        NatWest,
        [Display(Name = "HSBC UK")]
        HSBC,
        Barclays,
        Vanquis,
    }
}
