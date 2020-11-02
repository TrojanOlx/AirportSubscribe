using AirportSubscribe.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportSubscribe.Servers.Urls
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddAirportUrl.AddAipportUrlCommand, UrlModel>();
        }
    }
}
