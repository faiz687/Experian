using AutoMapper;
using MarketPlaces.Entity.Models;
using MarketPlacesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaces.Data.MappingProfiles
{
    public class ApplicantProfile : Profile
    {
        public ApplicantProfile()
        {
            CreateMap<ApplicantDetailDto, Applicant>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(a => System.DateTime.Now))                                                             
                .ReverseMap();  
        }
    }
}
