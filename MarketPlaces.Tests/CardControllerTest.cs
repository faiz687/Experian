using AutoMapper;
using MarketPlaces.Entity.Models;
using MarketPlacesApi;
using MarketPlacesApi.Controllers;
using MarketPlacesApi.Interfaces;
using MarketPlacesApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MarketPlaces.Tests
{
    public class CardControllerTest
    {
        private readonly CardController _cardController;
        private readonly Mock<IMapper> _mapper = new Mock<IMapper>();
        private readonly Mock<ILogger<CardController>> _logger = new Mock<ILogger<CardController>>();
        private readonly Mock<IQualificationService> _qualificationService = new Mock<IQualificationService>();
        private readonly Mock<ICardService> _cardService = new Mock<ICardService>();
        private readonly Mock<IApplicantService> _applicantService = new Mock<IApplicantService>();

        public CardControllerTest()
        {
            _cardController = new CardController(_logger.Object, _qualificationService.Object,
                _cardService.Object, _applicantService.Object, _mapper.Object);
        }

        [Fact]
        public async Task FindCard_ShouldReturnNoCards_WhenBelowAge()
        {
            //Arrange
            var applicantDetailDto = new ApplicantDetailDto
            { 
                FirstName = "Tom",
                LastName = "Holland",
                AnnualIncome = 90000,
                DateOfBirth = new DateTime(2020,01,01).Date
            };

            var result = new Result<string> { Success = false, value = "no credit cards are available" };
        
            _qualificationService.Setup(x => x.IsApplicantEligible(applicantDetailDto)).Returns(result);

            //Act
            var response = await _cardController.FindCard(applicantDetailDto);

            //Assert
            var okResponseObject = Assert.IsType<OkObjectResult>(response);
            var _response = Assert.IsType<Response>(okResponseObject.Value);
            Assert.Equal(result.value, _response.Message);
        }

        [Fact]
        public async Task FindCard_ShouldReturnBarclaysCard_WhenIncomeAbove30000()
        {
            //Arrange
            var applicantDetailDto = new ApplicantDetailDto
            {
                FirstName = "Tom",
                LastName = "Holland",
                AnnualIncome = 90000,
                DateOfBirth = new DateTime(2000, 01, 01).Date
            };

            var result = new Result<List<Card>> 
            { 
                  value = new List<Card>
                  {
                          new Card
                          { 
                              APR = 10,
                              Name =  "Barclays",
                              PromotionalMessage = "Welcome to Barclays"
                          }
                  } ,
                  Success = true               
            };

            var applicantResult = new Result<string> { Success = true };

            _qualificationService.Setup(x => x.IsApplicantEligible(applicantDetailDto)).Returns(applicantResult);

            _cardService.Setup(x => x.FindCards(applicantDetailDto)).ReturnsAsync(result);

            //Act
            var response = await _cardController.FindCard(applicantDetailDto);

            //Assert
            var okResponseObject = Assert.IsType<OkObjectResult>(response);
            var _response = Assert.IsType<Response>(okResponseObject.Value);
            Assert.Equal("You are eligible for the following cards", _response.Message);
            Assert.Single(_response.Cards);
            Assert.Equal("Barclays",result.value[0].Name);
            Assert.Equal(10,result.value[0].APR);
        }

        [Fact]
        public async Task FindCard_ShouldReturnVanquisCard_WhenIncomeBelow30000()
        {
            //Arrange
            var applicantDetailDto = new ApplicantDetailDto
            {
                FirstName = "Tom",
                LastName = "Holland",
                AnnualIncome = 29999,
                DateOfBirth = new DateTime(2000, 01, 01).Date
            };

            var result = new Result<List<Card>>
            {
                value = new List<Card>
                { 
                    new Card
                    {
                        APR = 11,
                        Name =  "Vanquis",
                        PromotionalMessage = "Welcome to Vanquis"
                    }
                },
                Success = true
            };

            var applicantResult = new Result<string> { Success = true };

            _qualificationService.Setup(x => x.IsApplicantEligible(applicantDetailDto)).Returns(applicantResult);

            _cardService.Setup(x => x.FindCards(applicantDetailDto)).ReturnsAsync(result);

            //Act
            var response = await _cardController.FindCard(applicantDetailDto);

            //Assert
            var okResponseObject = Assert.IsType<OkObjectResult>(response);
            var _response = Assert.IsType<Response>(okResponseObject.Value);
            Assert.Equal("You are eligible for the following cards", _response.Message);
            Assert.Single(_response.Cards);
            Assert.Equal("Vanquis", result.value[0].Name);
            Assert.Equal(11, result.value[0].APR);
        }
    }
}
