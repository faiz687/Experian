using AutoMapper;
using MarketPlaces.Entity.Models;
using MarketPlacesApi.Interfaces;
using MarketPlacesApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPlacesApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CardController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<CardController> _logger;
        private readonly IQualificationService _qualificationService;
        private readonly ICardService _cardService;
        private readonly IApplicantService _applicantService;

        public CardController(ILogger<CardController> logger, IQualificationService qualificationService, ICardService cardService, IApplicantService applicantService)
        {
            _applicantService = applicantService;
            _cardService = cardService;
            _qualificationService = qualificationService;
            _logger = logger;
        }

        [HttpPost(Name = nameof(FindCard))]
        public async Task<IActionResult> FindCard([FromBody] ApplicantDetailDto applicantDetailDto)
        {
            try
            {
                if (ModelState.IsValid && applicantDetailDto != null)
                {
                    var applicantEligibilityResult = _qualificationService.IsApplicantEligible(applicantDetailDto);

                    if (!applicantEligibilityResult.Success)
                    {
                        Response response = new Response { Message = applicantEligibilityResult.value };
                        return Ok(response);
                    }

                    var applicantCardsResult = await _cardService.FindCards(applicantDetailDto);

                    if (applicantCardsResult.Success && applicantCardsResult.value.Any())
                    {
                        Response response = new Response
                        {
                            Cards = applicantCardsResult.value,
                            Message = "You are eligible for the following cards"
                        };

                        //save data
                        var applicant = _mapper.Map<Applicant>(applicantDetailDto);
                        var applicantDbResult = _applicantService.SaveApplicantWithResults(applicant, applicantCardsResult.value);
                        
                        return Ok(response);
                    }
                }

                return BadRequest();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An Error occured while finding card for applicant with message {ex.Message}");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
