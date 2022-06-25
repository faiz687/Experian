using AutoMapper;
using MarketPlacesApi.Helpers;
using MarketPlacesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPlacesApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CardController : ControllerBase
    {
        //private readonly IFoodRepository _foodRepository;
        private readonly IUrlHelper _urlHelper;
        private readonly IMapper _mapper;
        private readonly ILogger<CardController> _logger;

        public CardController(ILogger<CardController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = nameof(FindCard))]
        public ActionResult<Card> FindCard([FromBody] ApplicantDetailDto applicantDetailDto)
        {       
            if (ModelState.IsValid && applicantDetailDto != null)
            {
                if (!CardHelper.IsApplicantAbove18(applicantDetailDto.DateOfBirth.Value))
                {
                    return new JsonResult(new Response { Message = "no credit cards are available" });
                }



        
                

       
            }
            else
            {
                return BadRequest();
            }
    
            return Ok(new Card { });
        }
    }
}
